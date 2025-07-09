using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    //Maybe rewrite this to use ObjectPool instead of a list
    [SerializeField]private List<Bullet> bulletPool;
    public List<Bullet> activeBullets = new List<Bullet>();
    [SerializeField]private int poolSize = 1000;
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
            Bullet _bullet = CreateNewBullet();
            bulletPool.Add(_bullet);
        }

        Physics.simulationMode = SimulationMode.Script;
    }

    public Bullet CreateNewBullet()
    {
        GameObject go = new GameObject("Bullet");
        go.transform.position = new Vector3(0, -20, 0);
        Bullet _bullet = go.AddComponent<Bullet>();
        go.transform.SetParent(transform);
        //go.SetActive(false);
        return _bullet;
    }
    
    public Bullet RequestBullet()
    {
        foreach (Bullet bullet in bulletPool)
        {
            RemoveFromPool(bullet);
            return bullet;
        }
        return CreateNewBullet();
    }
    
    public void AddToPool(Bullet _bullet)
    {
        _bullet.transform.SetParent(transform);
        bulletPool.Add(_bullet);
        activeBullets.Remove(_bullet);
    }

    public void RemoveFromPool(Bullet _bullet)
    {
        _bullet.gameObject.transform.SetParent(null);
        bulletPool.Remove(_bullet);
        activeBullets.Add(_bullet);
    }

    private void OnDestroy()
    {
        bulletPool.Clear();
    }
}
