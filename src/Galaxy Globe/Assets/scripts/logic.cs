using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logic : MonoBehaviour
{
    public int Found = 0;
    private GameObject guiScore;
    private int Total = 0;
    private int wait = 0;
    private int exit = 0;
    void Start ()
    {
        Total = GameObject.FindGameObjectsWithTag("Pickup").Length;
        guiScore = GameObject.FindGameObjectWithTag("GUI Score");
	}
	void Update ()
    {
        guiScore.GetComponent<Text>().text = "Found: " + Found + " / " + Total;
        if (wait < 500)
        {
            wait++;
        }
        else
        {
            if (exit == 0 & GameObject.FindGameObjectWithTag("GUI Intro").GetComponent<Text>().text != "")
            {
                GameObject.FindGameObjectWithTag("GUI Intro").GetComponent<Text>().text = "";
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            if (collider.gameObject.GetComponent<Renderer>().enabled)
            {
                collider.gameObject.GetComponent<Renderer>().enabled = false;
                Found++;
                GameObject.FindGameObjectWithTag("GUI Intro").GetComponent<Text>().text = "";
                if (Found == Total)
                {
                    exit = 1;
                    GameObject.FindGameObjectWithTag("GUI Intro").GetComponent<Text>().text = "Congrats! BB8 can now escape! You won! Press Escape to Exit.";
                }
            }
        }
    }
}
