using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static EnemyData;

public class EnemyAttackTest : MonoBehaviour,EnemyAction
{
    private GameObject player;
    private Rigidbody2D rb2d;

    public float keepDistance;
    public float speed;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float checkRadius;
    public float maxSpeed;
    //private bool isBackToGround;
    public int maxNoLimitFrame;
    public bool isCanFly;
    private int noLimitFrame;
    public float mass;
    public float damage;
    public float noSpeedDis;
    public float offSetHeight;
    public float crashTime;
    public float crashSpeed;
    private float nowCrashTime;
    public bool isNowCrashing;
    public EnemyState state;
    private Vector3 crashPos;
    public float CrashingSpeed;
    public enum EnemyState
    {
        empty,
        straightToPlayer,
        keepDistance,
        keepDistanceAndCrashed,
        keepDistanceAndFire,
        avoidPlayerAttack,
        tringToGetToTheHeight
    }
    public bool isOnGround()
    {
        var coll = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);
        return coll != null;
    }

    void EnemyAction.EnemyStart()
    {
        player = DataManager.Instance.miner.gameObject;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void EnemyAction.EnemyUpdate()
    {

        switch (state)
        {
            case EnemyState.empty:
                break;
            case EnemyState.straightToPlayer:
                StarightToPlayer();
                break;
            case EnemyState.keepDistance:
                KeepDistance();
                break;
            case EnemyState.keepDistanceAndCrashed:
                KeepDistanceAndCrashed();
                break;
            case EnemyState.keepDistanceAndFire:
                break;
            case EnemyState.avoidPlayerAttack:
                break;
            case EnemyState.tringToGetToTheHeight:
                break;
            default:
                break;
        }

    }
    void StarightToPlayer()
    {
        SpeedLimit();
        Vector3 dis = (player.transform.position - transform.position);
        if (dis.x * transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        if (isOnGround() || isCanFly)
        {
            var disDelta = dis.magnitude - keepDistance;
            rb2d.velocity += (Vector2)(dis.normalized * speed * Time.deltaTime);
        }

    }
    void KeepDistance()
    {
        SpeedLimit();
        Vector3 dis = (player.transform.position - transform.position);
        if (dis.x * transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        if (isOnGround() || isCanFly)
        {
            var disDelta = dis.magnitude - keepDistance;
            if (disDelta > 0)
            {
                rb2d.velocity += (Vector2)(dis.normalized * speed * Time.deltaTime);
            }
            else if (disDelta > -noSpeedDis)
            {
                rb2d.velocity = Vector2.zero;
            }
            else
            {
                rb2d.velocity -= (Vector2)(dis.normalized * speed * Time.deltaTime);
            }
            //rb2d.MovePosition(dis.normalized * speed*Time.deltaTime + transform.position);
        }
    }
    void SpeedLimit()
    {
        if (noLimitFrame > 0)
        {
            noLimitFrame--;
        }
        else
        {
            rb2d.velocity = Mathf.Clamp(rb2d.velocity.magnitude, -maxSpeed, maxSpeed) * rb2d.velocity.normalized;  
        }
    }
    void KeepDistanceAndCrashed()
    {
        if (!isNowCrashing)
        {
            if (nowCrashTime <= 0)
            {
                SpeedLimit();
                Vector3 dis = (player.transform.position - transform.position);
                if (dis.x * transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                }
                if (isOnGround() || isCanFly)
                {
                    var disDelta = dis.magnitude - keepDistance;
                    if (disDelta > 0)
                    {
                        rb2d.velocity += (Vector2)(dis.normalized * speed * Time.deltaTime);
                    }
                    else
                    {
                        nowCrashTime = crashTime;
                        rb2d.velocity = Vector2.zero;
                    }

                    //rb2d.MovePosition(dis.normalized * speed*Time.deltaTime + transform.position);
                }
            }
            else
            {
                nowCrashTime -= Time.deltaTime;
                if (nowCrashTime <= 0)
                {
                    crashPos = player.transform.position;
                    isNowCrashing = true;
                }
            }
        }
        else
        {
            noLimitFrame = maxNoLimitFrame;
            Vector3 dis = (crashPos - transform.position);
            if (dis.x * transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
            if (isOnGround() || isCanFly)
            {
                var disDelta = dis.magnitude;
                if (disDelta > 0)
                {
                    rb2d.velocity += (Vector2)(dis.normalized * crashSpeed * Time.deltaTime);
                }
            }
        }
    }
    public void HitBack(float hitBackForce, Transform giveForceTransform, bool isPlayerGive = false)
    {
        if(isNowCrashing)
        {
            isNowCrashing = false;
            state = EnemyState.keepDistance;
            rb2d.velocity = Vector2.zero;
        }  
        noLimitFrame = maxNoLimitFrame;
        rb2d.AddForce((-giveForceTransform.transform.position + transform.position).normalized * hitBackForce / mass, ForceMode2D.Impulse);
    }
    public void HitBack(float hitBackForce, Vector3 giveForceVector, bool isPlayerGive = false)
    {
        noLimitFrame = maxNoLimitFrame;
        rb2d.AddForce((-giveForceVector + transform.position).normalized * hitBackForce / mass, ForceMode2D.Impulse);
    }

    void EnemyAction.GiveDamage(Miner miner)
    {
        miner.GetDamaged(damage);
    }
    private void OnDrawGizmosSelected()
    {
        if(state==EnemyState.keepDistance || state==EnemyState.keepDistanceAndCrashed)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position,keepDistance);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, keepDistance+noSpeedDis);
        }
    }
}

