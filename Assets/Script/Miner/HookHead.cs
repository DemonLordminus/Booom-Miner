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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCanCatch)
        {

            if (collision.gameObject.TryGetComponent<Mine>(out catchMine))
            {
                isCanCatch = false;
                onCatch?.Invoke();
                offset = catchMine.transform.position - attachPoint.position;
            }
        }
    }
    private void Update()
    {
        if (catchMine != null)
        {
            catchMine.transform.position = attachPoint.position + offset;
        }
    }

    public event Action onCatch;
}
