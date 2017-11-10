using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vegetation : MonoBehaviour
{
    public static Dictionary<string, GameObject> Create()
    {
        float width = 2.0f;
        float height = 2.0f;
        float scale = 40.0f;
        float length = 30.0f;
        Mesh grassMesh = Resources.Load<Mesh>("grass");
        grassMesh.RecalculateNormals();
        Texture2D grassTextureDiffuse = Resources.Load<Texture2D>("grass_diff");
        Dictionary<string, GameObject> _return = new Dictionary<string, GameObject>();
        int arrIdx = 0;
        for (float i = 0; i < 360.0f / width; i++)
        {
            for (float j = 0; j < 180.0f / height; j++)
            {
                GameObject grassObject = new GameObject("Grass <" + i + ", " + j + ">");
                MeshFilter meshFilter = grassObject.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = grassObject.AddComponent<MeshRenderer>();
                grassObject.AddComponent<grass>();
                meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
                meshFilter.mesh = grassMesh;
                meshRenderer.materials[0].mainTexture = grassTextureDiffuse;
                meshRenderer.enabled = true;
                grassObject.transform.localScale = new Vector3(scale * 1.5f, scale * 1.5f, Random.Range(length - 10.0f, length + 20.0f));
                grassObject.transform.Translate(new Vector3(0.0f, 127.0f, 0.0f));
                grassObject.transform.Rotate(new Vector3(-90.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), i * width);
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), j * height);

                string key = (int)grassObject.transform.position.x + ", " + (int)grassObject.transform.position.y + ", " + (int)grassObject.transform.position.z;
                try
                {
                    _return.Add(key, grassObject);
                }
                catch
                {
                }
            }
        }
        return _return;
    }
}