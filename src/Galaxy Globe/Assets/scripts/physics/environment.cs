using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class environment : MonoBehaviour
{
    public Vector3 Rotation = new Vector3(0, 0, 0);
    private terrain World;
    void Start ()
    {
        World = GameObject.FindGameObjectWithTag("Terrain").GetComponent<terrain>();
    }
	void Update ()
    {
        transform.rotation = World.GetRotation(transform);
        transform.Rotate(Rotation);
    }
}