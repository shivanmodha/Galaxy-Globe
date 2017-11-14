﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float Sensitivity = 250.0f;
    public float Walk = 6.0f;
    public float Sprint = 10.0f;
    public float JumpForce = 220.0f;
    private Transform Body;
    private Transform Head;
    private Transform HeadEntity;
    private Transform BodyEntity;
    private Transform Eyes;
    private float LookRotationY = 0;
    private Vector3 moveAmount;
    private Vector3 SmoothVelocity;
    private Rigidbody Character;
    private int Grounded = 0;
    private bool started = false;
    private void Start()
    {
        Character = GetComponent<Rigidbody>();
        Eyes = Camera.main.transform;
        Body = GameObject.FindGameObjectWithTag("Player Body").GetComponent<Transform>();
        Head = GameObject.FindGameObjectWithTag("Player Head").GetComponent<Transform>();
        HeadEntity = GameObject.FindGameObjectWithTag("Player Head Entity").GetComponent<Transform>();
        BodyEntity = GameObject.FindGameObjectWithTag("Player Body Entity").GetComponent<Transform>();
    }
    private void Update()
    {
        Head.Rotate(Vector3.forward * Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity);
        LookRotationY -= Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
        LookRotationY = Mathf.Clamp(LookRotationY, -10.0f, 90.0f);
        HeadEntity.localEulerAngles = Vector3.up * LookRotationY;
        Vector3 MoveDirection = new Vector3(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), 0).normalized;
        Vector3 TargetMove = MoveDirection * Walk;
        moveAmount = Vector3.SmoothDamp(moveAmount, TargetMove, ref SmoothVelocity, 0.25f);
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded == 0)
            {
                Character.AddForce(transform.up * JumpForce);
                Grounded = 1;
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 LocalSpace = Head.TransformDirection(moveAmount);
        Character.MovePosition(Character.position + LocalSpace * Time.fixedDeltaTime);
        Vector3 LookDirection = Eyes.TransformDirection(moveAmount);
        Debug.DrawRay(Character.position, LocalSpace);
        Body.Rotate(LookDirection);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DetectCollision(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        //DetectCollision(collision);
    }
    private void DetectCollision(Collision collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Terrain" || hitTag == "Player Jump Point" || hitTag == "Start Plane")
        {
            /*if (Grounded == 2)
            {
                Grounded = 0;
            }
            else if (Grounded == 1)
            {
                Grounded = 2;
            }*/
            Grounded = 0;
            if (!started)
            {
                GameObject.FindGameObjectWithTag("Start Plane").GetComponent<Renderer>().enabled = false;
                started = true;
            }
        }
    }
}