using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        Invoke("AutoDestroy", 9);

        Destroy(gameObject, 10);
    }

    void AutoDestroy()
    {
        anim.SetTrigger("doDie");
    }
}
