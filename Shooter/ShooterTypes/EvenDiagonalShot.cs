using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DiagionalShotType", menuName = "ShotTypes/DiagonalShot", order = 1)]
public class EvenDiagonalShot : ShooterType
{
    public int numberOfBullets = 8;
    
    public int numberOfPoints = 5;  // Number of star points
    public float radius = 5f;       // Radius of the star
    public int bulletsPerPoint = 3;
    public override void Shoot(MonoBehaviour shooter, BulletDefinition definition, BulletBehaviour behaviour)
    {
        float angleStep = 360f / (numberOfPoints * 2);
        float angle = 0f;

        for (int i = 0; i < numberOfPoints * 2; i++)
        {
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            Vector2 starPoint = new Vector2(x, y);

            for (int j = 0; j < bulletsPerPoint; j++)
            {
                Vector2 bulletPosition = Vector2.Lerp(Vector2.zero, starPoint, (float)j / (bulletsPerPoint - 1));
                Bullet bullet = BulletPool.Instance.RequestBullet();
                BulletPool.Instance.RemoveFromPool(bullet);
                
                bullet.transform.rotation = Quaternion.Euler(0,0,angle);
                
                bullet.transform.position = bulletPosition;
                
                bullet.Init(definition, behaviour);
            }

            angle += angleStep;
        }
    }
}
