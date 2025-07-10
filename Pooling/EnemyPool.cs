using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    [SerializeField]private List<Enemy> enemyPool;
    [SerializeField] private int poolSize = 100;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        for (int i = 0; i < poolSize - 1; i++)
        {
            Enemy _enemy = CreateNewEnemy();
            enemyPool.Add(_enemy);
        }
    }

    public Enemy CreateNewEnemy()
    {
        GameObject go = new GameObject("Enemy");
        go.transform.position = new Vector3(0, -40, 0);
        Enemy _enemy = go.AddComponent<Enemy>();
        go.transform.SetParent(transform);
        go.SetActive(false);
        return _enemy;
    }

    public void SpawnEnemy(Vector2 position, EnemyBehaviour enemyBehaviour, EnemyDefinition enemyDefinition)
    {
        foreach (Enemy enemy in enemyPool)
        {
            if(enemy == null)
            {
                Enemy _enemy = CreateNewEnemy();
                RemoveFromPool(_enemy);
                _enemy.Init(position, enemyBehaviour, enemyDefinition);
                return;
            }
            else
            {
                RemoveFromPool(enemy);
                enemy.Init(position, enemyBehaviour, enemyDefinition);
                return;
            }
        }
    }

    public void AddToPool(Enemy enemy)
    {
        enemy.transform.SetParent(transform);
        enemyPool.Add(enemy);
    }

    public void RemoveFromPool(Enemy enemy)
    {
        enemy.gameObject.transform.SetParent(null);
        enemyPool.Remove(enemy);
    }

    private void OnDestroy()
    {
        enemyPool.Clear();
    }
}
