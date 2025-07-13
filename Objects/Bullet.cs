using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletDefinition bulletDefinition;
    [SerializeField] private BulletBehaviour bulletBehaviour;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Collider2D bulletCollider;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Material BulletMat;
    [SerializeField] private MaterialPropertyBlock matPropBlock;

    private LayerMask layerMask;
    private Collider2D colResult;

    private void Awake()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.material.enableInstancing = true;
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.flipY = true;
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        gameObject.layer = 9;

        //layerMask = LayerMask.GetMask("Player");

        /*
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        compositeCollider = gameObject.AddComponent<CompositeCollider2D>();
        
        boxCollider.enabled = false;
        compositeCollider.enabled = false;
        circleCollider.enabled = false;
        */
    }

    public void Init(Vector3 position, Vector3 rotation, BulletDefinition _definition, BulletBehaviour _behaviour)
    {
        spriteRenderer.sprite = _definition.bulletSprite;
        spriteRenderer.size = _definition.spriteSize;
        spriteRenderer.color = _definition.color;
        bulletBehaviour = _behaviour;
        bulletDefinition = _definition;
        spriteRenderer.material = _definition.material;
        layerMask = _definition.mask;

        //Eventually add layering support here so that player bullets don't appear on top of enemy bullets

        /*
        bulletCollider = _definition.colliderType switch
        {
            BulletDefinition.ColliderType.Box => boxCollider,
            BulletDefinition.ColliderType.Circle => circleCollider,
            BulletDefinition.ColliderType.Composite => compositeCollider,
            _ => circleCollider
        };
        switch (bulletCollider)
        {
            case BoxCollider2D box:
                box.size = _definition.hitboxSize;
                box.offset = _definition.hitboxOffset;
                boxCollider.enabled = true;
                break;
            case CircleCollider2D circle:
                circle.radius = _definition.hitboxRadius;
                circle.offset = _definition.hitboxOffset;
                circleCollider.enabled = true;
                break;
            case CompositeCollider2D composite:
                break;
        }
        */
        //bulletCollider.isTrigger = true;
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
        bulletBehaviour.StartBullet(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
        
        /*if (rb.linearVelocity != Vector2.zero)
        {
            // Get the angle from the velocity vector
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            // Apply the rotation to the sprite
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }*/
        //rewriting collision to use Physics.Cast
        //Apparently is faster, dont know
        if (colResult)
        {
            colResult.GetComponent<Entity>().Damage(1);
            colResult = null;
            CleanAndAddToPool();
            
            Debug.Log("Collided with player");
        }
    }
    private void FixedUpdate()
    {
        if (bulletBehaviour != null)
        {
            bulletBehaviour.UpdateBullet(this);
        }
    }

    public void LateUpdate()
    {
        if (bulletDefinition == null) { return; }
        //DebugDrawBox((Vector2)transform.position + new Vector2(.05f, .05f), (Vector2)transform.position + new Vector2(-.05f, -.05f), UnityEngine.Color.red, 0f);
        //colResult = Physics2D.OverlapArea((Vector2)transform.position + new Vector2(.05f, .05f), (Vector2)transform.position + new Vector2(-.05f, -.05f), layerMask);

#if UNITY_EDITOR
        DebugDrawCircle((Vector2)transform.position + bulletDefinition.hitboxOffset, bulletDefinition.hitboxRadius, UnityEngine.Color.red, 0f);
#endif
        colResult = Physics2D.OverlapCircle((Vector2)transform.position + bulletDefinition.hitboxOffset, 0.1f, layerMask);
    }

    void Activate()
    {
        bulletBehaviour?.Activate(this);
    }

    void DebugDrawBox(Vector2 pointA, Vector2 pointB, UnityEngine.Color color, float duration = 0.1f)
    {
        Vector2 topLeft = new Vector2(pointA.x, pointB.y);
        Vector2 topRight = pointB;
        Vector2 bottomLeft = pointA;
        Vector2 bottomRight = new Vector2(pointB.x, pointA.y);

        Debug.DrawLine(bottomLeft, topLeft, color, duration);
        Debug.DrawLine(topLeft, topRight, color, duration);
        Debug.DrawLine(topRight, bottomRight, color, duration);
        Debug.DrawLine(bottomRight, bottomLeft, color, duration);
    }

    void DebugDrawCircle(Vector2 center, float radius, UnityEngine.Color color, float duration = 0.1f, int segments = 36)
    {
        float angleStep = 360f / segments;

        for (int i = 0; i < segments; i++)
        {
            float startAngle = Mathf.Deg2Rad * (i * angleStep);
            float endAngle = Mathf.Deg2Rad * ((i + 1) * angleStep);

            Vector2 startPoint = center + new Vector2(Mathf.Cos(startAngle), Mathf.Sin(startAngle)) * radius;
            Vector2 endPoint = center + new Vector2(Mathf.Cos(endAngle), Mathf.Sin(endAngle)) * radius;

            Debug.DrawLine(startPoint, endPoint, color, duration);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Entity), out var _entity))
        {
            Entity entity = _entity as Entity;
            if (entity != null)
            {
                entity.Damage(1);
            }
        }

        *//*
        if (other.gameObject.CompareTag("BulletDestroy"))
        {
            CleanAndAddToPool();
        }
        *//*
    }*/

    private void OnBecameInvisible()
    {
        CleanAndAddToPool();
    }

    private void CleanAndAddToPool()
    {
        //bulletCollider.enabled = false;
        layerMask = 0;
        gameObject.layer = LayerMask.NameToLayer("Default");
        bulletBehaviour = null;
        bulletDefinition = null;
        spriteRenderer.sprite = null;
        spriteRenderer.size = new Vector2(0, 0);
        BulletPool.Instance?.AddToPool(this);
    }
}
