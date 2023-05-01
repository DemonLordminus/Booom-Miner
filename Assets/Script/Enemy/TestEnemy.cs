using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.XR;

public class TestEnemy : EnemyBase
{
    public GameObject player;
    private Rigidbody2D rb2d;
    public float speed;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float checkRadius;
    public float hitBackForce;
    private void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
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
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    public override void HitBack()
    {
        rb2d.AddForce((-player.transform.position + transform.position).normalized* hitBackForce, ForceMode2D.Impulse);
    }
}
