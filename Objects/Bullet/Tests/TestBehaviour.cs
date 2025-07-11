using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "Bullets/Behaviours/TestBehaviour", order = 1)]
public class TestBehaviour : BulletBehaviour
{
    public override void StartBullet(Bullet bullet)
    {
        //apply forwards
        bullet.rb.linearVelocity = -bullet.transform.up * 8.5f;
    }

    public override void UpdateBullet(Bullet bullet)
    {
        //float angle = Mathf.Atan2(-bullet.rb.velocity.y, bullet.rb.velocity.x) * Mathf.Rad2Deg;

        // Apply the rotation to the GameObject
        //bullet.rb.rotation = -angle + 90;
    }
}
