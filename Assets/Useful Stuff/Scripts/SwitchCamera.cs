using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    int i = 0;
    private void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }
    public void MainCameraView()
    {
        i++;
        if (i == 1)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            
            cam1.GetComponent<AudioListener>().enabled = false;
            cam2.GetComponent<AudioListener>().enabled = true;
            cam3.GetComponent<AudioListener>().enabled = false;
        }
        if (i  == 2)
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;

            cam1.GetComponent<AudioListener>().enabled = false;
            cam2.GetComponent<AudioListener>().enabled = false;
            cam3.GetComponent<AudioListener>().enabled = true;
            
        }
        if (i == 3)
        {
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;

            cam1.GetComponent<AudioListener>().enabled = true;
            cam2.GetComponent<AudioListener>().enabled = false;
            cam3.GetComponent<AudioListener>().enabled = false;
            i = 0;
        }
    }
}
