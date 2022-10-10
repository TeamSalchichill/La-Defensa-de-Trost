using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolocate : MonoBehaviour
{
    public Vector3 offsetPos;
    public Quaternion offsetRot;

    void Start()
    {
        transform.position += offsetPos;
        transform.rotation = offsetRot;
    }
}
