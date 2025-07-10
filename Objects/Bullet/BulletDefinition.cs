using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletDefinition", menuName = "Bullets/BulletDefinition", order = 1)]
public class BulletDefinition : ScriptableObject
{
    //Legacy, remove whenever
    public enum ColliderType
    {
        Circle,
        Box,
        Composite
    }

    public LayerMask mask;

    public Sprite bulletSprite;
    public Color color = Color.white;
    public Material material;
    public Vector2 spriteSize;
    public float hitboxRadius;
}
