using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public float score;
    public float nowTime;
    public float maxTime;
    public Miner miner;
    public float minerHealth => miner.health;
    public Action OnGameOver;
    public Action OnScoreChange;
    public Action OnMinerHealthChange;
    private void Start()
    {
        nowTime = maxTime;
    }
    public void Update()
    {
        nowTime -= Time.deltaTime;
    }
}
