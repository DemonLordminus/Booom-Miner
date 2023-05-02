using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IHurt
{
    public float healthPoint;
    public float maxHealth;
    public float damage;
    protected GameObject player;
    protected Rigidbody2D rb2d;
    public virtual void GetDamaged(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0) 
        {
            Death();
        }

    }
    private void Start()
    {
        player = DataManager.Instance.miner.gameObject;
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Miner miner;
        if(collision.gameObject.TryGetComponent<Miner>(out miner))
        {
            miner.GetDamaged(damage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Miner miner;
        if (collision.gameObject.TryGetComponent<Miner>(out miner))
        {
            miner.GetDamaged(damage);
        }
    }
    public virtual void Death()
    {
        Destroy(gameObject);
    }
    public virtual void HitBack(float hitBackForce, Transform giveForceTransform,bool isPlayerGive= false) { }
}
