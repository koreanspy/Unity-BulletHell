using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyBehaviour behaviour;
    public EnemyDefinition definition;

    public ParticleSystem deathParticles;

    //Initialize position, behaviour and shot type
    public void Init(Vector3 spawnPosition, EnemyBehaviour enemyBehaviour, EnemyDefinition enemyDefinition)
    {
        Health = enemyDefinition.Health;
        Armor = enemyDefinition.Armor;

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

        EnemyPool.Instance.AddToPool(this);
    }
}
