using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyCreator : MonoBehaviour
{
    public EnemyCreateInfo[] enemys;
    public float maxTime;
    public float minTime;
    private float nowTime;
    public Transform enemyFather;
    public int minNum;
    public int maxNum;

    private int allChances;
    private void Start()
    {
        allChances= 0;
        foreach(var info in enemys)
        {
            allChances += info.ChanceToCreate;
        }
    }
    private void Update()
    {
        nowTime -= Time.deltaTime;
        if(nowTime<=0)
        {
            for (int i = 0; i < UnityEngine.Random.Range(minNum,maxNum); i++)
            {
                int t = UnityEngine.Random.Range(0, allChances);
                foreach(var enemy in enemys)
                {
                    if(t-enemy.ChanceToCreate<0)
                    {
                        CreateNewEnemy(enemy);
                    }
                }
            }
            nowTime= UnityEngine.Random.Range(minTime, maxTime);
        }
        
    }
    public void CreateNewEnemy(EnemyCreateInfo info)
    {
        Transform point = info.createPoint[UnityEngine.Random.Range(0, info.createPoint.Length)];
        var enemy = Instantiate(info.enemy, enemyFather);
        enemy.transform.position = point.position;
    }
}
[Serializable]
public class EnemyCreateInfo
{
    public Transform[] createPoint;
    public GameObject enemy;
    public int ChanceToCreate;
}