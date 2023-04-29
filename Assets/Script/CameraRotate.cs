using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform car;
    private void Update()
    {
        transform.rotation = car.transform.rotation;   
    }
}
