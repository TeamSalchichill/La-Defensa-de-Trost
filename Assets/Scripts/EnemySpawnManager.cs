using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    GameManager gameManager;

    public GameObject enemy;

    void Start()
    {
        gameManager = GameManager.instance;

        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    void SpawnEnemy()
    {
        if (gameManager.doSpawnEnemies)
        {
            Instantiate(enemy, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
