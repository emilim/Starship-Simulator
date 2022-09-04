using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    [SerializeField]
    float gravityAcceleration;

    private Rigidbody rocket;
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rocket.AddForce(new Vector3(0, -gravityAcceleration * rocket.mass, 0));
    }
}
