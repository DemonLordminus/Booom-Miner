using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public void Fire(Vector2 targetVector, float speed)
    {
        LookAt2DTool.LookAt2DWithDirection(transform,targetVector, 90);
        rb2d.velocity = targetVector*speed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
