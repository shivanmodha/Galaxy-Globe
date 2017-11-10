using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{
    private Camera camera;
    private Renderer renderer;
    private void Start()
    {
        camera = Camera.main.transform.GetComponent<Camera>();
        renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        /*float distance = Vector3.Distance(camera.transform.position, transform.position);
        if (distance < 50.0f)
        {
            //renderer.enabled = true;
        }
        else
        {
            //renderer.enabled = false;
        }*/
    }
}