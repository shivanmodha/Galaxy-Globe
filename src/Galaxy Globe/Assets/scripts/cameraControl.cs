using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private Transform HeadEntity;
    public float WheelAmount = 0;
    public float MaxZoomOut = -3.0f;
    public float MinZoomIn = 2.0f;
    private void Start()
    {
        HeadEntity = GameObject.FindGameObjectWithTag("Player Body").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        WheelAmount += wheel;
        if (WheelAmount > MaxZoomOut && WheelAmount < MinZoomIn)
        {
            transform.Translate(Vector3.forward * wheel);
        }
        else
        {
            if (WheelAmount < MaxZoomOut)
            {
                WheelAmount = MaxZoomOut;
            }
            else if (WheelAmount > MinZoomIn)
            {
                WheelAmount = MinZoomIn;
            }
        }
    }
}
