using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SpriteSizeTest : MonoBehaviour
{
    public ShooterType shooterType;
    public BulletDefinition bulletDefinition;
    public BulletBehaviour bulletBehaviour;
    public SpriteRenderer sprite;
    public Collider2D collider;

    public void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            shooterType.Shoot(this, bulletDefinition, bulletBehaviour);
        }
    }
}
