using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vegetation : MonoBehaviour
{
    public static GameObject[] Create()
    {
        float width = 2.0f;
        float height = 2.0f;
        float scale = 40.0f;
        Mesh grassMesh = Resources.Load<Mesh>("grass");
        grassMesh.RecalculateNormals();
        Texture2D grassTextureDiffuse = Resources.Load<Texture2D>("grass_diff");
        GameObject[] _return = new GameObject[(int)((360.0f / width) * (360.0f / height))];
        int arrIdx = 0;
        for (float i = 0; i < 360.0f / width; i++)
        {
            for (float j = 0; j < 360.0f / height; j++)
            {
                GameObject grassObject = new GameObject("Grass <" + i + ", " + j + ">");
                MeshFilter meshFilter = grassObject.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = grassObject.AddComponent<MeshRenderer>();
                grassObject.AddComponent<grass>();
                meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
                meshFilter.mesh = grassMesh;
                meshRenderer.materials[0].mainTexture = grassTextureDiffuse;
                grassObject.transform.localScale = new Vector3(scale, scale, scale);
                grassObject.transform.Translate(new Vector3(0.0f, 127.0f, 0.0f));
                grassObject.transform.Rotate(new Vector3(-90.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), i * width);
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), j * height);
                _return[arrIdx] = grassObject;
                arrIdx++;
            }
        }
        return _return;
    }
}