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
    [Label("矿石在每一关的个数")]public int[] number;
    [Label("矿石的贴图")] public Sprite mineSprite;
    [Label("矿石的尺寸")]public Vector2 mineSize;
    [Label("矿石的颜色")] public Color mineColor;
}

[Serializable]
public class MineInfo
{
    [Label("矿石名字")] public string mineName;
    [Range(0, 1f)] public float weightPercent;//百分比
    [Label("价值")]public float value;
    public MineInfo(MineInfo old)
    {
        mineName= old.mineName;
        weightPercent= old.weightPercent;
        value= old.value;
    }
}