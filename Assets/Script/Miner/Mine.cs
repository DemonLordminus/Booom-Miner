using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public MineInfo mineInfo;
    public float weightPercent => mineInfo.weightPercent;

    public void GetMine()
    {
        DataManager.Instance.score += mineInfo.value;
        //Debug.Log("ÍÚµ½¿óÁË");
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
