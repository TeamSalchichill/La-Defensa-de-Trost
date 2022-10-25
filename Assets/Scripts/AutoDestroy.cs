using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int timeToDestroy = 180;

    void Start()
    {
        Invoke("AutoDestroyGO", timeToDestroy);
    }

    void AutoDestroyGO()
    {
        Destroy(gameObject);
    }
}
