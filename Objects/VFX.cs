using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public virtual void PlayVFX(Vector3 _position)
    {
        this.transform.position = _position;
    }

    public virtual void CleanAndAddToPool()
    {

    }

    
}
