using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class terrain : MonoBehaviour
{
    private Dictionary<string, GameObject> GrassPatches;
    private Camera CameraHandle;
    private string cKey = "NULL";
    private string oKey = "NULL";
    private int cX, cY, cZ;
    private int oX, oY, oZ;
	void Start ()
    {
        GrassPatches = vegetation.Create();
        CameraHandle = Camera.main.transform.GetComponent<Camera>();
    }
    void Update()
    {
        //Debug.Log(CameraHandle.transform.position - new Vector3(0.0f, 128.3f, 0.0f));
        Vector3 check = CameraHandle.transform.position - new Vector3(0.0f, 1.0f, 0.0f);
    }
}
