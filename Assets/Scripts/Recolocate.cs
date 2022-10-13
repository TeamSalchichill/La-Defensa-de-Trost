using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolocate : MonoBehaviour
{
    public Vector3 offsetPos;
    public Quaternion offsetRot;

    public bool isSpawn;

    public bool oritateToPath =  false;

    void Start()
    {
        if (!isSpawn)
        {
            transform.rotation = offsetRot;
        }
        transform.position += offsetPos;

        Orientate();
    }

    public void Orientate()
    {
        if (oritateToPath)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position + new Vector3(2, 50, 0), transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            }
            if (!Physics.Raycast(transform.position + new Vector3(-2, 50, 0), transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
            {
                transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
            }
            if (!Physics.Raycast(transform.position + new Vector3(0, 50, 2), transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
            {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
            if (!Physics.Raycast(transform.position + new Vector3(0, 50, -2), transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
        }
    }
}
