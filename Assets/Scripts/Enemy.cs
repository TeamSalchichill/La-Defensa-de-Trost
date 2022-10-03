using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent nav;

    int speed;
    public int normalSpeed;

    [Header("States")]
    public int health = 100;
    public int armor = 0;
    [Space]
    public int iceEffect = 0;
    public int igniteEffect = 0;
    public int waterEffect = 0;
    public int ascentEffect = 0;
    public int bloodEffect = 0;
    public int transformationEffect = 0;

    [Header("States multiplier")]
    [Range(0, 1)]
    public int healthResistence = 100;
    [Range(0, 1)]
    public int armorResistence = 0;
    [Space]
    [Range(0, 1)]
    public int iceResistence = 0;
    [Range(0, 1)]
    public int igniteResistence = 0;
    [Range(0, 1)]
    public int waterResistence = 0;
    [Range(0, 1)]
    public int ascentResistence = 0;
    [Range(0, 1)]
    public int bloodResistence = 0;
    [Range(0, 1)]
    public int transformationResistence = 0;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.destination = target.position;

        nav.speed = normalSpeed;

        Destroy(gameObject, 120);
    }

    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Main Tower Target")
        {
            Destroy(gameObject);
        }
    }
}
