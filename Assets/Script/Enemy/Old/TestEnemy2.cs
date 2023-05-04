using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TestEnemy2 : EnemyBase
{
    public float speed;
    public float mass;
    public float maxSpeed;
    private void Update()
    {
       Vector3 dis = (player.transform.position - transform.position);
        LookAt2DTool.LookAt2DWithWorldPosition(transform, player.transform.position,-90);
        rb2d.velocity += (Vector2)(dis.normalized * speed * Time.deltaTime);
        rb2d.velocity = Mathf.Clamp(rb2d.velocity.magnitude, -maxSpeed, maxSpeed)*rb2d.velocity.normalized;
    }
    public override void HitBack(float hitBackForce, Transform giveForceTransform,bool isPlayerGive = false)
    {
        
        //rb2d.velocity = Vector2.zero;
        rb2d.AddForce((-giveForceTransform.transform.position + transform.position).normalized * hitBackForce/mass, ForceMode2D.Impulse);
        //Debug.Log("test");
    }
}
