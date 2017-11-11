using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class terrain : MonoBehaviour
{
    public bool Vegetation = true;
    public float VegetationRadius = 127.0f;
    public float VegetationPaddingX = 2.0f;
    public float VegetationPaddingY = 2.0f;
    public float Gravity = -9.8f;
    void Start ()
    {
        if (Vegetation)
        {
            vegetation.Create(VegetationPaddingX, VegetationPaddingY, VegetationRadius);
        }
    }
    void Update()
    {

    }
    public void Attract(Rigidbody _body)
    {
        Vector3 TargetDirection = (_body.position - transform.position).normalized;
        _body.rotation = Quaternion.FromToRotation(_body.transform.up, TargetDirection) * _body.rotation;
        _body.AddForce(TargetDirection * Gravity);
    }
    public Vector3 GetRotationVector(Transform _body)
    {
        return (_body.position - transform.position);
    }
    public Quaternion GetRotation(Transform _body)
    {
        Vector3 TargetDirection = (_body.position - transform.position).normalized;
        return Quaternion.FromToRotation(_body.up, TargetDirection) * _body.rotation;
    }
}
