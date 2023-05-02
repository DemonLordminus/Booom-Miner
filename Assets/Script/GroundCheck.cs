using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;
    public float checkRadius;
    public bool isGravity;
    public float gravityScale;
    private Rigidbody2D rb2d;
    public bool isOnGround;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isOnGround = OnGroundCheck();
        if (isGravity && !isOnGround)
        {
            rb2d.MovePosition(transform.position + new Vector3(0, -gravityScale*Time.deltaTime));
        }
    }
    public bool OnGroundCheck()
    {
        var coll = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);
        return coll != null;
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
