using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolocate : MonoBehaviour
{
    public Vector3 offsetPos;
    public Quaternion offsetRot;

    public bool isSpawn;

    void Start()
    {
        if (!isSpawn)
        {
            transform.rotation = offsetRot;
        }
        transform.position += offsetPos;
        
    }
}
