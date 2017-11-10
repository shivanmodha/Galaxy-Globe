using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class environment : MonoBehaviour
{
    public Vector3 Rotation = new Vector3(0, 0, 0);
    private source GravitySource;
    void Start ()
    {
        GravitySource = GameObject.FindGameObjectWithTag("Gravity Source").GetComponent<source>();
    }
	void Update ()
    {
        transform.rotation = GravitySource.GetRotation(transform);
        transform.Rotate(Rotation);
    }
}