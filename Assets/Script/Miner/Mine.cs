using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [Range(0,1f)]public float weightPercent;//�ٷֱ�
    public float value;
    public List<float> rarity;
    public void GetMine()
    {
        Debug.Log("�ڵ�����");
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
