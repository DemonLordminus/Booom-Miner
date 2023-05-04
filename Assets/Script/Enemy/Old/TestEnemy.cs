using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestEnemy : EnemyBase
{

    public float speed;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float checkRadius;
    public float maxSpeed;
    //private bool isBackToGround;
    public int maxNonoLimitFrame;
    private int noLimitFrame;
    //public float hitBackForce;

    public bool isOnGround()
    {
        var coll = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);
        return coll != null;
    }
    private void Update()
    {
        Vector3 dis = (player.transform.position - transform.position);
        if (dis.x * transform.localScale.x>0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        if(isOnGround())
        {
            //rb2d.MovePosition(dis.normalized * speed*Time.deltaTime + transform.position);
            rb2d.velocity += (Vector2)(dis.normalized * speed * Time.deltaTime);
        }
        if(noLimitFrame--<0)
        {
            rb2d.velocity = Mathf.Clamp(rb2d.velocity.magnitude, -maxSpeed, maxSpeed) * rb2d.velocity.normalized;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    public override void HitBack(float hitBackForce,Transform giveForceTransform,bool isPlayerGive=false)
    {
        noLimitFrame = maxNonoLimitFrame;
        if(isPlayerGive)
        {
            rb2d.AddForce((-giveForceTransform.transform.position + transform.position+new Vector3(0,5,0)).normalized * hitBackForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce((-giveForceTransform.transform.position + transform.position).normalized * hitBackForce, ForceMode2D.Impulse);
        }
    }
}
