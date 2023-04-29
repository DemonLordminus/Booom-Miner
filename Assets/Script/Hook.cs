using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject hookHead;
    public GameObject hookBody;
    [Range(0f, 90f)] public float rotateMaxDegree;
    public float rotateTime;

    private float nowDegree,nowTime;
    private int t=1;        
    public void HookRotate()
    {
        //var rotateSpeed = (rotateMaxDegree/rotateTime)*Time.deltaTime;
        //var rate =Mathf.Abs(Mathf.Cos((nowDegree / rotateMaxDegree) * Mathf.PI));
        //Debug.Log(rate);
        //nowDegree += rotateSpeed * t * rate;
        //var rotateVector = new Vector2(Mathf.Sin((nowDegree+180f)*Mathf.Deg2Rad), Mathf.Cos((nowDegree + 180f) * Mathf.Deg2Rad));
        //LookAt2DTool.LookAt2DWithDirection(transform, rotateVector,-90);
        //if(Mathf.Abs(nowDegree)>rotateMaxDegree)
        //{
        //    t = -t;
        //}    
        if(nowTime>rotateTime*2)
        {
            nowTime = 0;
        }
        nowTime += Time.fixedDeltaTime;
        nowDegree = Mathf.Cos(nowTime * Mathf.PI * 2 / rotateTime) * rotateMaxDegree;
        var rotateVector = new Vector2(Mathf.Sin((nowDegree + 180f) * Mathf.Deg2Rad), Mathf.Cos((nowDegree + 180f) * Mathf.Deg2Rad));
        LookAt2DTool.LookAt2DWithDirection(transform, rotateVector, -90);
    }
    private void FixedUpdate()
    {
        HookRotate();
    }
}
    