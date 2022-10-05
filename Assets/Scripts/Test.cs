using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("1");
    }
    void OnCollisionStay(Collision collision)
    {
        print("2");
    }
    void OnCollisionExit(Collision collision)
    {
        print("3");
    }

    void OnTriggerEnter(Collider other)
    {
        print("4");
    }
    void OnTriggerStay(Collider other)
    {
        print("5");
    }
    void OnTriggerExit(Collider other)
    {
        print("6");
    }
    void OnParticleCollision(GameObject other)
    {
        print("7");
    }
}
