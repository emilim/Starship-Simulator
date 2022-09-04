using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public GameObject toSpawn;
    void Awake()
    {
        Instantiate(toSpawn);
    }
}
