using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPool : MonoBehaviour
{
    public static VFXPool Instance;
    [SerializeField] private List<VFX> vfxPool;
    [SerializeField] private int poolSize = 100;

    /*
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
            vfxPool.Add(_bullet);
        }
        Physics.simulationMode = SimulationMode.Script;
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

    public Bullet CreateNewBullet()
    {
        GameObject go = new GameObject("Bullet");
        go.transform.position = new Vector3(0, -20, 0);
        Bullet _bullet = go.AddComponent<Bullet>();
        go.transform.SetParent(transform);
        //go.SetActive(false);
        return _bullet;
    }
    */

    public VFX CreateNewVFX()
    {
        GameObject go = new GameObject("VFX");
        go.transform.position = new Vector3(0, -20, 0);
        VFX vfx = go.AddComponent<VFX>();
        go.transform.SetParent(transform);
        return vfx;
    }

    public VFX RequestVFX()
    {
        foreach (VFX vfx in vfxPool)
        {
            RemoveFromPool(vfx);
            return vfx;
        }
        return CreateNewVFX();
    }

    public void AddToPool(VFX vfx)
    {
        vfx.transform.SetParent(this.transform, false);
        vfxPool.Add(vfx);
    }

    public void RemoveFromPool(VFX vfx)
    {
        vfx.transform.SetParent(null);
        vfxPool.Remove(vfx);
    }
}
