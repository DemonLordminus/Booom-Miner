using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MineInfo", menuName = "Mine/MineInfo", order = 1)]
public class MineInfoSO : ScriptableObject
{
    public List<MineInfoInSO> mineinfoInSO;

}
[Serializable]
public class MineInfoInSO
{
    public MineInfo mineInfo;
    [Label("��ʯ��ÿһ�صĸ���")]public int[] number;
    [Label("��ʯ����ͼ")] public Sprite mineSprite;
    [Label("��ʯ�ĳߴ�")]public Vector2 mineSize;
    [Label("��ʯ����ɫ")] public Color mineColor;
}

[Serializable]
public class MineInfo
{
    [Label("��ʯ����")] public string mineName;
    [Range(0, 1f)] public float weightPercent;//�ٷֱ�
    [Label("��ֵ")]public float value;
    public MineInfo(MineInfo old)
    {
        mineName= old.mineName;
        weightPercent= old.weightPercent;
        value= old.value;
    }
}