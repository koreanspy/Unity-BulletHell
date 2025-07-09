using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Health;

    public int Armor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Damage(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        
    }
}
