using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        camera = Camera.main.transform.GetComponent<Camera>();
    }
    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }
    private void Update()
    {
        /*if (enabled)
        {
            float distance = Vector3.Distance(camera.transform.position, transform.position);
            if (distance < 50.0f)
            {
                GetComponent<Renderer>().enabled = true;
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
        }*/
    }
}