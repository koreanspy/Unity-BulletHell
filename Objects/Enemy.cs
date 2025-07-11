using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Animator Animator;

    public EnemyBehaviour behaviour;
    public EnemyDefinition definition;

    public ParticleSystem deathParticles;

    private void Awake()
    {
        SpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    }

    public void Init(Vector3 spawnPosition, EnemyBehaviour enemyBehaviour, EnemyDefinition enemyDefinition)
    {
        Health = enemyDefinition.Health;
        Armor = enemyDefinition.Armor;
        Animator.runtimeAnimatorController = enemyDefinition.Animator;
    }

    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathParticles.Play();
    }

    void CleanAnAddToPool()
    {
        Health = 0;
        Armor = 0;
        Animator.runtimeAnimatorController = null;

        EnemyPool.Instance.AddToPool(this);
    }
}
