using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float MouseSensitivityX = 250.0f;
    public float MouseSensitivityY = 250.0f;
    public float MoveSpeed = 6.0f;
    Transform CameraT;
    float verticalLookRotation = 0;

    Vector3 moveAmount;
    Vector3 SmoothVelocity;
    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        CameraT = Camera.main.transform;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60.0f, 60.0f);
        CameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 TargetMove = MoveDirection * MoveSpeed;

        moveAmount = Vector3.SmoothDamp(moveAmount, TargetMove, ref SmoothVelocity, 0.15f);
    }
    private void FixedUpdate()
    {
        Vector3 LocalSpace = transform.TransformDirection(moveAmount);
        rigidbody.MovePosition(rigidbody.position + LocalSpace * Time.fixedDeltaTime);
    }
}
