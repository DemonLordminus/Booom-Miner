using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Miner : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Label("矿车角速度")] public float minerSpeed;
    public Planet planet;
    public float degreeOnPlanet=0;
    public float height;

    private float jumpHeight;
    private float nowJumpForce;
    [SerializeField] private JumpState jumpState;
    //public int jumpUpFrame;
    public float jumpForce;
    private void OnEnable()
    {
        InputManager.Instance.OnJump += JumpStarted;
    }
    private void OnDisable()
    {
        InputManager.Instance.OnJump -= JumpStarted;
    }
    enum JumpState
    {
        onGround,
        jumpUp,
        jumpDown
    }
    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    public void CarMove()
    {
        //Vector2 newPos = (Vector2)transform.position + new Vector2(InputManager.Instance.miner.controlDir, 0);
        //Vector2 newPos = (Vector2)transform.position+planet.ChangeDegreeToPos(InputManager.Instance.miner.controlDir);
        degreeOnPlanet += InputManager.Instance.miner.controlDir* minerSpeed;
        Vector2 newPos = planet.ChangeDegreeToPos(degreeOnPlanet,height+ jumpHeight);
        rb2d.MovePosition(newPos);
        //Debug.Log($"真的在动,{newPos}");
    }
    private void FetchToPlanet()
    {
        //rb2d.AddForce((planet.pos-rb2d.position)*2f,ForceMode2D.Force);
        
    }
    private void KeepDirToPlanet()
    {
        LookAt2DTool.LookAt2DWithWorldPosition(transform, planet.pos,-90);
    }
    public void JumpStarted()
    {
        if(jumpState==JumpState.onGround && jumpForce>planet.fetchForce)
        {
            nowJumpForce = jumpForce;
            jumpState = JumpState.jumpUp;
            //StartCoroutine(JumpUp());
        }
    }
    private void JumpHandle()
    {
        if (jumpState == JumpState.jumpUp)
        {
            jumpHeight += nowJumpForce;
            nowJumpForce -= planet.fetchForce;
            if (nowJumpForce < 0f)
            {
                jumpState = JumpState.jumpDown;
            }
        }
        else if (jumpState == JumpState.jumpDown)
        {
            nowJumpForce -= planet.fetchForce;
            jumpHeight += nowJumpForce;
            if (jumpHeight < 0f)
            {
                jumpState = JumpState.onGround;
                jumpHeight = 0;
            }
        }
    }
        //private IEnumerator JumpUp()
        //{
        //while(true)
        //{
        //    if (jumpState == JumpState.jumpUp)
        //    {
        //        jumpHeight += nowJumpForce;
        //        nowJumpForce -= planet.fetchForce;
        //        if (nowJumpForce < 0f)
        //        {
        //            jumpState = JumpState.jumpDown;
        //        }
        //        yield return null; 
        //    }
        //    else if (jumpState == JumpState.jumpDown)
        //    {
        //        jumpHeight -= planet.fetchForce;
        //        if (jumpHeight < 0f)
        //        {
        //            jumpState= JumpState.onGround;
        //        }
        //        yield return null;
        //    }
        //}
        //}
    private void Update()
    {
        CarMove();
        //FetchToPlanet();
        JumpHandle();
        KeepDirToPlanet();
    }
}
