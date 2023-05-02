using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    private void Update()
    {
        var time = DataManager.Instance.nowTime;
        if (time>0)
        {
            timer.text = $"{time:0.}";
        }
        else
        {
            timer.text = "时间归零，游戏结束";
        }
        
        var hp = DataManager.Instance.minerHealth;
        if (hp>0)
        {
            health.text = $"{hp:0}";
        }
        else
        {
            health.text = "血量归零，游戏结束";
        }
        score.text= $"{DataManager.Instance.score}";
    }
}
