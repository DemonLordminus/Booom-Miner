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
            timer.text = "ʱ����㣬��Ϸ����";
        }
        
        var hp = DataManager.Instance.minerHealth;
        if (hp>0)
        {
            health.text = $"{hp:0}";
        }
        else
        {
            health.text = "Ѫ�����㣬��Ϸ����";
        }
        score.text= $"{DataManager.Instance.score}";
    }
}
