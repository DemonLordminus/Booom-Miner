using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fort : MonoBehaviour
{
    [Range(-360, 360f)] public float minFortDegree;
    [Range(-360, 360f)] public float maxFortDegree;
    public float rotateSpeed;
    public float nowDegree;
    public float targetDegree;
    public float bulletSpeed;
    public LineRenderer lineRenderer;
    public GameObject bulletPrefab;
    public Transform bulletFather;
    public float bullerFireTime;
    private float nowFireTime;
    public float bulletDamage;
    public float bulletForce;
    public bool isBulletCanGetOverEnemy;
    private void HandleFortRotate()
    {
        var nowVector = new Vector2(Mathf.Sin(nowDegree * Mathf.Deg2Rad), Mathf.Cos(nowDegree * Mathf.Deg2Rad));
        LookAt2DTool.LookAt2DWithDirection(transform, nowVector, 90);
    }
    private void InputHandle()
    {
        var inputVector = InputManager.Instance.battler.controlDir;
        if (inputVector != Vector2.zero)
        {
            targetDegree = (inputVector.x * 90) / ((Mathf.Abs(inputVector.x) + (Mathf.Abs(inputVector.y))));
            //nowDegree += InputManager.Instance.battler.controlDir*rotateSpeed*Time.fixedDeltaTime;
            if (targetDegree! != nowDegree)
            {

                int t = 1;
                if (targetDegree - nowDegree < 0)
                {
                    t = -1;
                }
                nowDegree += t * rotateSpeed * Time.fixedDeltaTime;
                if ((targetDegree - nowDegree) * t < 0)
                {
                    nowDegree = targetDegree;
                }
                nowDegree = Mathf.Clamp(nowDegree, minFortDegree, maxFortDegree);
            }
        }
    }
    private void ShowLine()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, transform.position + (Vector3)LookAt2DTool.GetFaceDirection(transform, 90) * 100f);
    }
    private void Fire()
    {
        var newBullet = Instantiate(bulletPrefab, bulletFather).GetComponent<Bullet>();
        newBullet.transform.position=transform.position;
        newBullet.Fire(LookAt2DTool.GetFaceDirection(transform, 90), bulletSpeed);
        newBullet.damage = bulletDamage;
        newBullet.bulletForce = bulletForce;
        newBullet.isCanGetOverEnemy = isBulletCanGetOverEnemy;
    }
    private void FireLoop()
    {
        nowFireTime += Time.deltaTime;
        if(nowFireTime>bullerFireTime)
        {
            Fire();
            nowFireTime= 0;
        }
    }
    private void Update()
    {
        ShowLine();
        HandleFortRotate();
        FireLoop();
    }
    private void FixedUpdate()
    {
        InputHandle();
    }
    
}
