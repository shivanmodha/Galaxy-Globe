using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class terrain : MonoBehaviour
{
    private GameObject[] grass;
    private Camera camera;
	void Start ()
    {
        grass = vegetation.Create();
        camera = Camera.main.transform.GetComponent<Camera>();
    }
    void Update()
    {
        /*for (int i = 0; i < grass.Length; i++)
        {
            float distance = Vector3.Distance(camera.transform.position, grass[i].transform.position);
            if (distance < 50.0f)
            {
                grass[i].GetComponent<Renderer>().enabled = true;
            }
            else
            {
                grass[i].GetComponent<Renderer>().enabled = false;
            }
        }*/
    }
}
