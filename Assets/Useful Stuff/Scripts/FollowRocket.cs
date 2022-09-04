using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{
    public GameObject rocket;
    Vector3 positionCam;
    int x = 12;
    int y = 31;
    int z = -1;
    void Update()
    {
        positionCam = new Vector3(rocket.transform.position.x + x, rocket.transform.position.y + y, rocket.transform.position.z + z);
        transform.position = positionCam;
    }
}
