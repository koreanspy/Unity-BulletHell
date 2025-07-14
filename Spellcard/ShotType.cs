using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;

public class ShotType : ScriptableObject
{
    public float ShootTime;

    public float ShotDelay;

    public Player player;

    public bool isShooting;

    //Might swap to tasks if I FIGURE OUT HOW TO USE THEM
    public Coroutine shootingCoroutine;

    public int Level;

    public BulletBehaviour[] bulletBehaviour;
    public BulletDefinition[] bulletDefinition;

    public GameObject EmitterPrefab;

    public GameObject EmitterAnchor;
    public GameObject[] Emitters;



    public virtual void Init(Player _player, int level)
    {
        player = _player;
        Level = level;
    }

    public virtual void Fire()
    {

    }

    public virtual void StopFire()
    {

    }

    public virtual void CardUpdate()
    {

    }

    public virtual void CleanUp()
    {
        for (int i = 0; i < Emitters.Length; i++)
        {
            Destroy(Emitters[i]);
        }
    }
}
