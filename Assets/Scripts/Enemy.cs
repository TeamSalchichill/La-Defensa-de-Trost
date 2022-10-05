using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum Type { Pequeño, Mediano, Grande }
    public Type type;

    GameFlow gameFlow;
    MainTower mainTower;

    public Transform target;
    public NavMeshAgent nav;

    [Header("States")]
    public int damage;
    public int gold;
    public int speed;
    public int normalSpeed;
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
        gameFlow = GameFlow.instance;
        mainTower = MainTower.instance;

        nav = GetComponent<NavMeshAgent>();
        nav.destination = target.position;

        nav.speed = normalSpeed;

        Destroy(gameObject, 120);
    }

    void Update()
    {
        if (health < 0)
        {
            gameFlow.coins += gold;

            switch (type)
            {
                case (Type.Pequeño):
                    gameFlow.enemiesLeft1--;
                    break;
                case (Type.Mediano):
                    gameFlow.enemiesLeft2--;
                    break;
                case (Type.Grande):
                    gameFlow.enemiesLeft3--;
                    break;
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Main Tower Target")
        {
            switch (type)
            {
                case (Type.Pequeño):
                    gameFlow.enemiesLeft1--;
                    break;
                case (Type.Mediano):
                    gameFlow.enemiesLeft2--;
                    break;
                case (Type.Grande):
                    gameFlow.enemiesLeft3--;
                    break;
            }

            mainTower.health--;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "TowerPath")
        {
            other.gameObject.GetComponentInParent<Tower>().health -= damage;
        }
        if (other.tag == "Damage")
        {
            health -= other.gameObject.GetComponentInParent<Tower>().healthDamage;
        }
    }
}
