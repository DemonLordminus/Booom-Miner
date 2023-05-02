using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIneCreator : MonoBehaviour
{
    public MineInfoSO mineInfoSO;
    [Label("四个生成区域的顶点")]public Transform[] createArea;
    public GameObject minePrefab;
    public Transform mineFather;
    [Label("从零开始的关卡序号")]public int levelIndex;
    public List<Mine> mineInstances;

    private void Start()
    {
        RandomCreateMine();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < 3; i++)
        {
            Gizmos.DrawLine(createArea[i].position, createArea[i + 1].position);
        }
        Gizmos.DrawLine(createArea[3].position, createArea[0].position);
    }

    [EditorButton("随机生成矿石")]
    public void RandomCreateMine()
    {
        float minY, maxY, minX, maxX;
        minY = Mathf.Min(createArea[0].position.y, createArea[1].position.y, createArea[2].position.y, createArea[3].position.y);
        maxY = Mathf.Max(createArea[0].position.y, createArea[1].position.y, createArea[2].position.y, createArea[3].position.y);
        minX = Mathf.Min(createArea[0].position.x, createArea[1].position.x, createArea[2].position.x, createArea[3].position.x);
        maxX = Mathf.Max(createArea[0].position.x, createArea[1].position.x, createArea[2].position.x, createArea[3].position.x);
        foreach (var info in mineInfoSO.mineinfoInSO)
        {
            int p = 0;
            for (int i = 0; i < info.number[levelIndex]; i++)
            {
                if (p >= 100)
                {
                    Debug.LogError("生成不下了");
                    break;
                }
                Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                var cols = Physics2D.OverlapCapsuleAll(pos, info.mineSize*1.1f, CapsuleDirection2D.Horizontal, 0);
                foreach(var col in cols)
                {
                    Mine mine;
                    if(col.gameObject.TryGetComponent<Mine>(out mine))
                    {
                        p++;
                        i--;
                        continue;
                    }
                }
                mineInstances.Add(CreateNewMineFromSO(info, minePrefab,mineFather,pos));
            }
        }
    }
    public Mine CreateNewMineFromSO(MineInfoInSO info, GameObject minePrefab, Transform parent, Vector3 pos)
    {
        var newMine = Instantiate(minePrefab, parent);
        newMine.transform.position = pos;
        Mine mineScr;
        if (!newMine.TryGetComponent<Mine>(out mineScr))
        {
            mineScr = newMine.AddComponent<Mine>();
        }
        mineScr.mineInfo = new MineInfo(info.mineInfo);
        newMine.transform.localScale = info.mineSize;
        SpriteRenderer render;
        if (!newMine.TryGetComponent<SpriteRenderer>(out render))
        {
            render = newMine.AddComponent<SpriteRenderer>();
        }
        render.sprite = info.mineSprite;
        render.color = info.mineColor;

        return mineScr;
    }
}
