using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ShotType : ScriptableObject
{
    public float ShootTime;

    public float ShotDelay;

    public Player player;

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

    //We're just going to call Destroy for now
    //If it affects performance down the line then I'll refactor it into a 4 object pool.

    //Eh looking back on it now, we should just have all of the spellcards instanced and just swap between them
    public virtual void CleanUp()
    {
        for (int i = 0; i < Emitters.Length; i++)
        {
            Destroy(Emitters[i]);
        }
    }
}
