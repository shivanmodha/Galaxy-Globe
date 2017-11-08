using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private float CLAMP_Y_MIN = 0.0f;
    private float CLAMP_Y_MAX = 60.0f;
    public Transform lookAt;
    public float Distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    private Rigidbody Object;
    private source GravitySource;
    private void Start()
    {        
        Object = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        GravitySource = GameObject.FindGameObjectWithTag("Gravity Source").GetComponent<source>();
    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        Vector3 rotation = GravitySource.GetRotation(Object);
        CLAMP_Y_MIN = Vector3.Angle(rotation, new Vector3(0, 1, 0));
        CLAMP_Y_MAX = CLAMP_Y_MIN + 60.0f;
        currentY = Mathf.Clamp(currentY, CLAMP_Y_MIN, CLAMP_Y_MAX);
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt.position);
        
        lookAt.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityX);
    }
    //    public float MouseSensitivityX = 250.0f;
    //    public float MouseSensitivityY = 250.0f;
    //    public float MoveSpeed = 6.0f;
    //    Transform CameraT;
    //    float verticalLookRotation = 0;

    //    Vector3 moveAmount;
    //    Vector3 SmoothVelocity;
    //    Rigidbody rigidbody;
    //    private void Awake()
    //    {
    //        rigidbody = GetComponent<Rigidbody>();
    //    }
    //    void Start()
    //    {
    //        CameraT = Camera.main.transform;
    //    }
    //    void Update()
    //    {
    //        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivityX);
    //        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivityY;
    //        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60.0f, 60.0f);
    //        CameraT.localEulerAngles = Vector3.left * verticalLookRotation;

    //        Vector3 MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    //        Vector3 TargetMove = MoveDirection * MoveSpeed;

    //        moveAmount = Vector3.SmoothDamp(moveAmount, TargetMove, ref SmoothVelocity, 0.15f);
    //    }
    //    private void FixedUpdate()
    //    {
    //        Vector3 LocalSpace = transform.TransformDirection(moveAmount);
    //        rigidbody.MovePosition(rigidbody.position + LocalSpace * Time.fixedDeltaTime);
    //    }
}
