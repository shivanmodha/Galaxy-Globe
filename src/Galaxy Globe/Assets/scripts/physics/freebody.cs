using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class freebody : MonoBehaviour
{
    source GravitySource;
    Rigidbody RigidBody;
    private void Awake()
    {
        GravitySource = GameObject.FindGameObjectWithTag("Gravity Source").GetComponent<source>();
        RigidBody = GetComponent<Rigidbody>();
        RigidBody.useGravity = false;
        RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void FixedUpdate()
    {
        GravitySource.Attract(RigidBody);
    }
}
