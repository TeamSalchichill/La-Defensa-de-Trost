using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    GameManager gameManager;
    GameFlow gameFlow;

    public GameObject[] enemies;
    public List<GameObject> enemies1 = new List<GameObject>();
    public List<GameObject> enemies2 = new List<GameObject>();
    public List<GameObject> enemies3 = new List<GameObject>();

    int enemies1Count;
    int enemies2Count;
    int enemies3Count;

    void Start()
    {
        gameManager = GameManager.instance;
        gameFlow = GameFlow.instance;

        foreach (GameObject enemy in gameFlow.enemies)
        {
            switch (enemy.GetComponent<Enemy>().type)
            {
                case Enemy.Type.Pequeño:
                    enemies1.Add(enemy);
                    break;
                case Enemy.Type.Mediano:
                    enemies2.Add(enemy);
                    break;
                case Enemy.Type.Grande:
                    enemies3.Add(enemy);
                    break;
            }
        }

        enemies1Count = enemies1.Count;
        enemies2Count = enemies2.Count;
        enemies3Count = enemies3.Count;

        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    void SpawnEnemy()
    {
        int chooseEnemy1 = Random.Range(0, enemies1Count);
        int chooseEnemy2 = Random.Range(0, enemies2Count);
        int chooseEnemy3 = Random.Range(0, enemies3Count);

        if (gameManager.doSpawnEnemies)
        {
            if (gameFlow.enemiesToSpawn3 > 0)
            {
                gameFlow.enemiesToSpawn3--;
                Instantiate(enemies3[chooseEnemy3], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            else if(gameFlow.enemiesToSpawn1 > 0 || gameFlow.enemiesToSpawn2 > 0)
            {
                int enemyType = Random.Range(0, 2);

                switch (enemyType)
                {
                    case 0:
                        if (gameFlow.enemiesToSpawn1 > 0)
                        {
                            gameFlow.enemiesToSpawn1--;

                            Instantiate(enemies1[chooseEnemy1], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        }
                        else
                        {
                            gameFlow.enemiesToSpawn2--;
                            Instantiate(enemies2[chooseEnemy2], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        }
                        break;
                    case 1:
                        if (gameFlow.enemiesToSpawn2 > 0)
                        {
                            gameFlow.enemiesToSpawn2--;
                            Instantiate(enemies2[chooseEnemy2], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        }
                        else
                        {
                            gameFlow.enemiesToSpawn1--;
                            Instantiate(enemies1[chooseEnemy1], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        }
                        break;
                }
            }
        }
    }
}
