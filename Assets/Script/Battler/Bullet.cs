using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float damage;
    public float bulletForce;
    public bool isCanGetOverEnemy;
    public void Fire(Vector2 targetVector, float speed)
    {
        LookAt2DTool.LookAt2DWithDirection(transform,targetVector, 90);
        rb2d.velocity = targetVector*speed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase target;
        EnemyData test;
        if(collision.gameObject.TryGetComponent<EnemyBase>(out target))
        {
            target.HitBack(bulletForce,transform);
            target.GetDamaged(damage);
            if(!isCanGetOverEnemy)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.TryGetComponent<EnemyData>(out test))
        {
            test.HitBack(bulletForce, transform);
            test.GetDamaged(damage);
            if (!isCanGetOverEnemy)
            {
                Destroy(gameObject);
            }
        }
    }
}
