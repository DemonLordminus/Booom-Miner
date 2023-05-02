using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public HookHead hookHead;
    public GameObject hookBody;
    private HookState state;
    [Header("旋转")]
    [Range(0f, 90f)] public float rotateMaxDegree;
    public float rotateTime;
    private float nowDegree, nowTime;
    private int t = 1;
    [Header("伸长")]
    public float hookForwardSpeed;
    public AnimationCurve hookSpeedRate;
    public float timeSize;
    public float maxHookDis;
    [Header("缩回")]
    public float hookBackSpeed;
    public float percision;
    public AnimationCurve ropeAmimation;
    public float waveSize;
    public float timeSizeForBack;
    private float hookBackSpeedRate;
    private float nowHookLength;
    private float originLength;
    private LineRenderer lineRenderer;
    private List<Transform> points;
    private float startTime;
    public bool isReturnBackCanCatch;
    public bool isCanActiveGetBack;
    private Quaternion originHookHeadRotate;
    private float maxLength;
    private Vector3 orginPos;
    private Vector2 originDir;
    public bool isUseNewForward;
    //private Vector3 lastHookHeadPos;
    //private Rigidbody2D headRb;
    private void Start()
    {
        points = new List<Transform>();
        lineRenderer = hookBody.GetComponent<LineRenderer>();
        points.Add(transform);
        points.Add(hookHead.transform);
        originLength = (hookHead.transform.position - transform.position).magnitude;
        // headRb =hookHead.GetComponent<Rigidbody2D>();   
        hookHead.onCatch += WhenCatched;
        originHookHeadRotate = hookHead.transform.localRotation;
    }
    private void OnEnable()
    {
        InputManager.Instance.OnHook += HookInput;

    }
    private void OnDisable()
    {
        InputManager.Instance.OnHook -= HookInput;
    }
    private void HookRotate()
    {
        #region 废案
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
        #endregion
        if (nowTime > rotateTime * 2)
        {
            nowTime = 0;
        }
        nowTime += Time.fixedDeltaTime;
        nowDegree = Mathf.Cos(nowTime * Mathf.PI * 2 / rotateTime) * rotateMaxDegree;
        var rotateVector = new Vector2(Mathf.Sin((nowDegree + 180f) * Mathf.Deg2Rad), Mathf.Cos((nowDegree + 180f) * Mathf.Deg2Rad));
        LookAt2DTool.LookAt2DWithDirection(transform, rotateVector, -90);
    }
    private void HookForward()
    {
        if (startTime < timeSize)
        {
            startTime += Time.deltaTime;
        }
        else
        {
            startTime = timeSize;
        }
        if (nowHookLength >= maxHookDis)
        {
            hookHead.isCanCatch = isReturnBackCanCatch;
            SwitchFromForwardToBack();
        }
        var rate = hookSpeedRate.Evaluate(startTime / timeSize);
        nowHookLength += rate * hookForwardSpeed * Time.deltaTime;
    }
    //private void WhenCloser()
    //{
    //    //hookHead.GetBack((hookBackSpeed * Time.deltaTime * hookBackSpeedRate)*LookAt2DTool.GetFaceDirection(hookHead.transform,90));
    //    LookAt2DTool.LookAt2DWithWorldPosition(hookHead.transform, transform.position, -90);
    //}
    //private void WhenFurther()
    //{
    //    Debug.Log("离得更远");
    //    //hookHead.transform.position = transform.position+(Vector3)((originLength+nowHookLength) * LookAt2DTool.GetFaceDirection(hookHead.transform, 90));
    //    //HookPosUpdate();
    //    //hookHead.Follow();
    //}
    private void HookBack()
    {
        //if (startTime < timeSizeForBack)
        //{
        //    startTime += Time.deltaTime;

        //}
        //else
        //{
        //    startTime = timeSizeForBack;
        //}
        nowHookLength -= hookBackSpeed * Time.deltaTime * hookBackSpeedRate;
        //nowHookLength = (hookHead.transform.position - transform.position).magnitude - originLength;
        //if (hookHead.catchMine != null)
        //{
        //    hookHead.Follow();
        //}
        LookAt2DTool.LookAt2DWithWorldPosition(hookHead.transform, transform.position, -90);
        if(hookHead.catchMine!=null)
        {
            var t = nowHookLength / maxLength;
            hookHead.transform.position = Vector3.Lerp(transform.position,hookHead.minePos,t);
        }
        else
        {
            hookHead.transform.position += (hookBackSpeed * Time.deltaTime * hookBackSpeedRate) * (Vector3)LookAt2DTool.GetFaceDirection(hookHead.transform, -90); 
        }
        //hookHead.GetBack(-(hookBackSpeed * Time.deltaTime * hookBackSpeedRate) * LookAt2DTool.GetFaceDirection(hookHead.transform,-90));
        
        //else if (nowHookLength < maxLength)
        //{
        //    maxLength= nowHookLength;
        //    LookAt2DTool.LookAt2DWithWorldPosition(hookHead.transform, transform.position, -90);
        //    hookHead.catchMine.transform.Translate(-(hookBackSpeed * Time.deltaTime * hookBackSpeedRate) * LookAt2DTool.GetFaceDirection(hookHead.transform, 90));
        //}
        //lastHookHeadPos = transform.position;
        //if(nowHookLength<maxLength || hookHead.catchMine==null)//离得更近
        //{
        //    WhenCloser();
        //}    
        //else if(nowHookLength > maxLength)////离得更远
        //{
        //    WhenFurther();
        //}
        //else
        //{
        //    Debug.Log("距离没变");
        //}
        //hookHead.Follow();
        if (nowHookLength <= 0)
        {
            nowHookLength = 0;
            hookHead.transform.localRotation = originHookHeadRotate;
            if (hookHead.catchMine != null)
            {
                hookHead.catchMine.GetMine();
                hookHead.catchMine = null;
                //hookHead.transform.SetParent(transform);
            }
            state = HookState.rotate;
            hookHead.transform.position = transform.position + (Vector3)(originLength * LookAt2DTool.GetFaceDirection(hookHead.transform, 90));
        }
    }
    private void HookPosUpdate()
    {
        if(isUseNewForward)
        {
            hookHead.transform.position = orginPos + (Vector3)((originLength + nowHookLength)* originDir);
        }
        else
        {
            hookHead.transform.position = transform.position + (Vector3)((originLength + nowHookLength) * LookAt2DTool.GetFaceDirection(hookHead.transform, 90));
        }
    }
    public void HookInput()
    {
        if (state == HookState.rotate)
        {
            orginPos = transform.position;
            state = HookState.forward;
            startTime = 0;
            hookBackSpeedRate = 1;
            hookHead.isCanCatch = true;
            originDir = LookAt2DTool.GetFaceDirection(hookHead.transform);
        }
        else if (state == HookState.forward && isCanActiveGetBack)
        {
            SwitchFromForwardToBack();
            hookHead.isCanCatch = isReturnBackCanCatch;
        }
    }
    public void HookHandleInState()
    {
        switch (state)
        {
            case HookState.rotate:
                HookRotate();
                break;
            case HookState.forward:
                HookForward();
                HookPosUpdate();
                break;
            case HookState.back:
                HookBack();
                //HookPosUpdate();
                break;
            default:
                break;
        }
    }
    private void FixedUpdate()
    {
        HookHandleInState();
    }
    private void Update()
    {
        UpdateLine();
    }
    private void UpdateLine()
    {
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
    public void WhenCatched()
    {
        SwitchFromForwardToBack();
        hookHead.isCanCatch = false;
        hookBackSpeedRate = hookHead.catchMine.weightPercent;
    }
    enum HookState
    {
        rotate,
        forward,
        back
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxHookDis);
    }
    public void SwitchFromForwardToBack()
    {
        maxLength = nowHookLength;
        state = HookState.back;
        startTime = 0;
        if (hookHead.catchMine != null)
        {
            //hookHead.transform.SetParent(hookHead.catchMine.transform);
        }
        //lastHookHeadPos = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,hookHead.minePos);
    }
}
