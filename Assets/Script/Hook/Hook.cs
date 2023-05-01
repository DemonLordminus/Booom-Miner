using System.Collections;
using System.Collections.Generic;
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
    //private Rigidbody2D headRb;
    private void Start()
    {
        points=new List<Transform>();
        lineRenderer = hookBody.GetComponent<LineRenderer>();
        points.Add(transform);
        points.Add(hookHead.transform);
        originLength = (hookHead.transform.position - transform.position).magnitude;
        // headRb =hookHead.GetComponent<Rigidbody2D>();   
        hookHead.onCatch += WhenCatched;
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
        if(startTime<timeSize)
        {
            startTime += Time.deltaTime;

        }
        else
        {
            startTime = timeSize;
        }
        if (nowHookLength>=maxHookDis)
        {
            hookHead.isCanCatch= isReturnBackCanCatch; 
            state = HookState.back;
        }
        var rate = hookSpeedRate.Evaluate(startTime/timeSize);
        nowHookLength += rate * hookForwardSpeed * Time.deltaTime;


    }
    private void HookBack()
    {
        if (startTime < timeSizeForBack)
        {
            startTime += Time.deltaTime;

        }
        else
        {
            startTime = timeSizeForBack;
        }

        nowHookLength -= hookBackSpeed * Time.deltaTime * hookBackSpeedRate;
        if(nowHookLength<=0)
        {
            nowHookLength= 0;
            if(hookHead.catchMine!=null)
            {
                hookHead.catchMine.GetMine();
                hookHead.catchMine = null;
            }
            state = HookState.rotate;
        }
    }
    private void HookPosUpdate()
    {
        hookHead.transform.position= transform.position+(Vector3)((originLength+nowHookLength) * LookAt2DTool.GetFaceDirection(hookHead.transform, 90));
    }
    public void HookInput()
    {
        if(state==HookState.rotate)
        {
            state= HookState.forward;
            startTime = 0;
            hookBackSpeedRate = 1;
            hookHead.isCanCatch = true;
        }
        else if(state==HookState.forward) 
        {
            state = HookState.back;
            startTime = 0;
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
                HookPosUpdate();
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
        state = HookState.back; 
        startTime = 0;
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
        Gizmos.DrawWireSphere(transform.position,maxHookDis);
    }
}
    