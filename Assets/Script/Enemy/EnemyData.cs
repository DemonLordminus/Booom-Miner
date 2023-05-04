using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour,IHurt
{
    //public List<EnemyAction> actions;
    public Action OnStart;
    public Action OnUpdate;
    public Action<Miner> OnGivesDamage;
    public Action<float, Transform, bool> OnHitBack;

    public float healthPoint;
    public float maxHealth;


    private void Start()
    {
        //if (actions != null)
        //{

        //    foreach (var action in actions)
        //    {
        //        action.EnemyStart();
        //    }
        //}
        GetAcitons();
        OnStart?.Invoke();
    }
    private void Update()
    {
       OnUpdate?.Invoke();
    }


    public void GetAcitons()
    {
        var thisAcitons = GetComponents<EnemyAction>();
        foreach (var action in thisAcitons)
        {
            OnStart += action.EnemyStart;
            OnUpdate+= action.EnemyUpdate;
            OnGivesDamage += action.GiveDamage;
            OnHitBack+= action.HitBack;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Miner miner;
        if (collision.gameObject.TryGetComponent<Miner>(out miner))
        {
            //miner.GetDamaged(damage);
            OnGivesDamage?.Invoke(miner);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Miner miner;
        if (collision.gameObject.TryGetComponent<Miner>(out miner))
        {
            //miner.GetDamaged(damage);
            OnGivesDamage?.Invoke(miner);
        }
    }

    public void GetDamaged(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            Death();
        }

    }

    public void Death()
    {
         Destroy(gameObject);
    }
    public void HitBack(float hitBackForce, Transform giveForceTransform, bool isPlayerGive = false)
    {
        OnHitBack?.Invoke(hitBackForce,giveForceTransform,isPlayerGive);
    }
}
public interface EnemyAction
{
    void EnemyUpdate();
    void EnemyStart();
    public void HitBack(float hitBackForce, Transform giveForceTransform, bool isPlayerGive = false);
    public void GiveDamage(Miner miner);
}

