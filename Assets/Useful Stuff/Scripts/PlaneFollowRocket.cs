using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollowRocket : MonoBehaviour
{
    public GameObject rocket;
    Vector3 posPlane;
    void Update()
    {
        if (rocket != null)
            posPlane = new Vector3(rocket.transform.position.x, -50, rocket.transform.position.z);
        transform.position = posPlane;
    }
}
