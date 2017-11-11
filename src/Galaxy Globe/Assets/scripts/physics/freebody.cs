using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class freebody : MonoBehaviour
{
    public Vector3 Rotation = new Vector3(0, 0, 0);
    private terrain World;
    private Rigidbody RigidBody;
    private void Awake()
    {
        World = GameObject.FindGameObjectWithTag("Terrain").GetComponent<terrain>();
        RigidBody = GetComponent<Rigidbody>();
        RigidBody.useGravity = false;
        RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void FixedUpdate()
    {
        World.Attract(RigidBody);
        if (Rotation.x != 0 || Rotation.y != 0 || Rotation.z != 0)
        {
            transform.rotation = World.GetRotation(transform);
            transform.Rotate(Rotation);
        }
    }
}
