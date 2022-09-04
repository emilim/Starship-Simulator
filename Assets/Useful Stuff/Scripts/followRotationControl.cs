using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followRotationControl : MonoBehaviour
{
    public GameObject rocket;

    void Update()
    {
        if (rocket != null)
            transform.LookAt(rocket.transform);
    }
}
