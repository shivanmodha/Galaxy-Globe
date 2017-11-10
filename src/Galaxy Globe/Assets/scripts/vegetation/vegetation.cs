using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vegetation : MonoBehaviour
{
    public static void Create()
    {
        float width = 2.0f;
        float height = 2.0f;
        Texture2D grassTextureDiffuse = Resources.Load<Texture2D>("grass_diff");
        for (float i = 0; i < 360.0f / width; i++)
        {
            for (float j = 0; j < 180.0f / height; j++)
            {
                GameObject grassObject = Instantiate(Resources.Load<GameObject>("grass"));// new GameObject("Grass <" + i + ", " + j + ">");
                grassObject.name = "Grass <" + i + ", " + j + ">";
                grassObject.AddComponent<grass>();
                LODGroup l = grassObject.GetComponent<LODGroup>();
                Renderer[] Renderers = new Renderer[3];
                Renderers[0] = l.GetLODs()[0].renderers[0];
                Renderers[1] = l.GetLODs()[1].renderers[0];
                Renderers[2] = l.GetLODs()[2].renderers[0];
                Renderers[0].materials[0].mainTexture = grassTextureDiffuse;
                Renderers[1].materials[0].mainTexture = grassTextureDiffuse;
                Renderers[2].materials[0].mainTexture = grassTextureDiffuse;
                float rR = Random.Range(0.0f, 360.0f);
                grassObject.transform.Translate(new Vector3(0.0f, Random.Range(126.6f, 126.8f), 0.0f));
                grassObject.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f)), 0.0f);
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), i * width);
                grassObject.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), j * height);
                Renderers[0].transform.Rotate(new Vector3(0.0f, 0.0f, rR));
                Renderers[1].transform.Rotate(new Vector3(0.0f, 0.0f, rR));
                Renderers[2].transform.Rotate(new Vector3(0.0f, 0.0f, rR));
            }
        }
    }
}