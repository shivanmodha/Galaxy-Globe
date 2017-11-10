using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float MouseSensitivityX = 250.0f;
    public float MouseSensitivityY = 250.0f;
    public float MoveSpeed = 6.0f;
    private Transform CameraTransform;
    private float LookRotationY = 0;
    private Vector3 moveAmount;
    private Vector3 SmoothVelocity;
    private Rigidbody Body;
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }
    void Start()
    {
        CameraTransform = Camera.main.transform;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivityX);
        LookRotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivityY;
        LookRotationY = Mathf.Clamp(LookRotationY, -60.0f, 60.0f);
        CameraTransform.localEulerAngles = Vector3.left * LookRotationY;

        Vector3 MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 TargetMove = MoveDirection * MoveSpeed;

        moveAmount = Vector3.SmoothDamp(moveAmount, TargetMove, ref SmoothVelocity, 0.15f);
    }
    private void FixedUpdate()
    {
        Vector3 LocalSpace = transform.TransformDirection(moveAmount);
        Body.MovePosition(Body.position + LocalSpace * Time.fixedDeltaTime);
    }
}