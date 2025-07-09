using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBoss : MonoBehaviour
{
    public Spellcard spellCard;
    public Transform EmitterWorkspace;
    void Start()
    {
        spellCard.InitWorkspace(EmitterWorkspace);
        spellCard.Init(this);
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        spellCard.Update();
    }
}
