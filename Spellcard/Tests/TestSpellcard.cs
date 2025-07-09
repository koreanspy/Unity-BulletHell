using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

[CreateAssetMenu(fileName = "TestSpellcard", menuName = "Spellcard/TEST", order = 1)]
public class TestSpellcard : Spellcard
{
    private EventInstance ShotTwinkle;

    public GameObject EmitterAnchor;
    public GameObject[] Emitters = new GameObject[12];

    public BulletDefinition BulDef;
    public BulletBehaviour BulBeh;

    public float acceleration = 0.01f;
    private float rotationSpeed = 379181.9f;
    public float rotationStep = 0.225f;

    public AudioClip ShootSFX;

    public double DoubleFrame;

    public override void Init(TestBoss boss)
    {
        DoubleFrame = 2 / 60;
        ShotTwinkle = AudioManager.Instance.CreateInstance(FMODEvents.Instance.ShotTwinkle);

        EmitterAnchor = new GameObject("EmitterAnchor");
        EmitterAnchor.transform.parent = EmitterWorkspace;
        EmitterWorkspace.transform.localPosition = Vector3.zero;

        for (int i = 0; i < 8; i++)
        {
            Emitters[i] = new GameObject($"Emitter{i}");
            Emitters[i].transform.parent = EmitterAnchor.transform;
            float angle1 = i * Mathf.PI * 2 / 8;
            Vector2 position = new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * 1;
            Emitters[i].transform.position = position;

            Vector3 dirAway = Emitters[i].transform.position - EmitterAnchor.transform.position;
            float angle2 = Mathf.Atan2(dirAway.y, dirAway.x) * Mathf.Rad2Deg;
            Emitters[i].transform.rotation = Quaternion.Euler(0, 0, angle2 + 90f);
        }
        //set localPosition to zero AFTER instances to prevent weird scaling issues
        EmitterAnchor.transform.localPosition = Vector3.zero;
        boss.StartCoroutine(ShootGif());
    }


    public override void Update()
    {
        rotationSpeed += acceleration * (Time.deltaTime / 9f);

        float rotAmount = rotationStep * rotationSpeed;

        EmitterAnchor.transform.Rotate(0, 0, rotAmount);
    }

    private IEnumerator ShootGif()
    {
        //ShotTwinkle.start();
        while (EmitterAnchor)
        {
            for (int i = 0;i < 8;i++)
            {
                Bullet bullet1 = BulletPool.Instance.RequestBullet();
                Quaternion worldRot1 = Emitters[i].transform.rotation;
                bullet1.transform.position = Emitters[i].transform.position;
                bullet1.transform.rotation = worldRot1;
                bullet1.Init(BulDef, BulBeh);
            }
            
            //AudioManager.Instance.PlaySFXLength(ShootSFX, 0.05f, 1f, (float)DoubleFrame);

            //Apparently the most consistent timer is fucking 2 divided by 60???
            yield return new WaitForSeconds((float)DoubleFrame);
        }
    }
}
