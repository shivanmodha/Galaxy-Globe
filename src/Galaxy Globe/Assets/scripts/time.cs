using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    private Light Source;
    private GameObject SourceWrapper;
    private int direction = 3;
    private int wait = 0;
	void Start ()
    {
        SourceWrapper = GameObject.FindGameObjectWithTag("Terrain Light");
        Source = SourceWrapper.GetComponent<Light>();
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0;
	}
	void Update ()
    {
        SourceWrapper.transform.Rotate(new Vector3(0.05f * Time.deltaTime, 0.0f, 0.0f));
        Debug.DrawRay(new Vector3(0, 0, 0), SourceWrapper.transform.rotation.eulerAngles);
        if (direction == 0)
        {
            Source.intensity -= 0.001f * Time.deltaTime;
            if (Source.intensity < 0.5f)
            {
                RenderSettings.fogDensity += 0.0005f * Time.deltaTime;
                if (RenderSettings.fogDensity > 0.1f)
                {
                    direction = 2;
                }
            }
        }
        else if (direction == 2)
        {
            wait++;
            if (wait > 1000)
            {
                direction = 1;
                wait = 0;
            }
        }
        else if (direction == 1)
        {
            Source.intensity += 0.001f * Time.deltaTime;
            if (RenderSettings.fogDensity > 0.0f)
            {
                RenderSettings.fogDensity -= 0.0005f * Time.deltaTime;
            }
            if (Source.intensity >= 2.0f)
            {
                direction = 3;
            }
        }
        else if (direction == 3)
        {
            wait++;
            if (wait > 1000)
            {
                direction = 0;
                wait = 0;
            }
        }
	}
}
