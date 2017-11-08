using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class source : MonoBehaviour
{
    public static float Gravity = -9.8f;
    public void Attract(Rigidbody _body)
    {
        Vector3 TargetDirection = GetRotation(_body);
        _body.rotation *= Quaternion.FromToRotation(_body.transform.up, TargetDirection);
        _body.AddForce(TargetDirection * Gravity);
    }
    public Vector3 GetRotation(Rigidbody _body)
    {
        return (_body.position - transform.position).normalized;
    }
}
