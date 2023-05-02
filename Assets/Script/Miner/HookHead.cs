using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHead : MonoBehaviour
{
    public Transform attachPoint;
    public Mine catchMine;
    public bool isCanCatch;
    private Vector3 offset;
    private Vector3 lastPos;
    public Vector3 minePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCanCatch)
        {
            if (collision.gameObject.TryGetComponent<Mine>(out catchMine))
            {
                isCanCatch = false;
                onCatch?.Invoke();
                offset = catchMine.transform.position - attachPoint.position;
                minePos=transform.position;
            }
        }
    }
    private void Update()
    {
        //if (catchMine != null)
        //{
        //transform.position = transform.position - attachPoint.position + (catchMine.transform.position - offset);
        //}
        if (catchMine != null)
        {
            catchMine.transform.position = attachPoint.position + offset;
        }
    }


    //public void GetBack(Vector2 dir)
    //{
    //    if (catchMine != null)
    //    {
    //        catchMine.transform.Translate(-dir);
    //        //transform.position = transform.position - attachPoint.position + (catchMine.transform.position - offset);
    //    }
    //    else
    //    {
    //        transform.position -= (Vector3)dir;
    //    }
    //}
    //public void Follow()
    //{
    //    catchMine.transform.position = attachPoint.position + offset;
    //}
    public event Action onCatch;
}
