using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [Range(0,1f)]public float weightPercent;//百分比
    public float value;
    public List<float> rarity;
    public void GetMine()
    {
        Debug.Log("挖到矿了");
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Miner tmp;
        if(collision.gameObject.TryGetComponent<Miner>(out tmp))
        {
            GetMine();
        }
    }
}
