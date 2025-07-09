using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NullSpellcard", menuName = "Spellcard/NULL", order = 1)]
public class Spellcard : ScriptableObject
{

    public Transform EmitterWorkspace;

    public virtual void Init(TestBoss boss)
    {

    }

    public virtual void Update()
    {

    }

    public virtual void InitWorkspace(Transform input)
    {
        EmitterWorkspace = input;
    }

    public virtual void ActivateUI()
    {

    }
}
