using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMainTower : MonoBehaviour
{
    MainTower mainTower;

    public int health;

    void Start()
    {
        mainTower = MainTower.instance;
    }

    void Update()
    {
        if (health <= 0)
        {
            mainTower.health -= 7;

            GameFlow.instance.miniObjetivesDestroyed++;

            Destroy(gameObject);
        }
    }
}
