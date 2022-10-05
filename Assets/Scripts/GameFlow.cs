using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    Generator generator;
    GameManager gameManager;

    public int round = 0;
    public int coins = 100;

    public int totalRounds;

    public int[] enemiesPerRound1;
    public int[] enemiesPerRound2;
    public int[] enemiesPerRound3;

    public int enemiesToSpawn1 = 0;
    public int enemiesLeft1 = 0;
    public int enemiesToSpawn2 = 0;
    public int enemiesLeft2 = 0;
    public int enemiesToSpawn3 = 0;
    public int enemiesLeft3 = 0;

    public bool roundFinished = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        generator = Generator.instance;
        gameManager = GameManager.instance;

        enemiesPerRound1 = new int[totalRounds];

        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound1[i] = (i * i) + 1;
        }

        enemiesPerRound2 = new int[totalRounds];

        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound2[i] = i + 1;
        }

        enemiesPerRound3 = new int[totalRounds];

        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound3[i] = (i / 2) + 1;
        }
    }

    void Update()
    {
        if (enemiesLeft1 <= 0 && enemiesLeft2 <= 0  && enemiesLeft3 <= 0 && !roundFinished)
        {
            roundFinished = true;

            gameManager.doSpawnEnemies = false;

            foreach (var newNode in generator.newMapNodes)
            {
                if (newNode != null)
                {
                    newNode.SetActive(true);
                }
            }
        }
    }

    public void StartRound()
    {
        roundFinished = false;

        foreach (GameObject newNode in generator.newMapNodes)
        {
            if (newNode != null)
            {
                newNode.SetActive(false);
            }
        }

        gameManager.doSpawnEnemies = true;

        enemiesToSpawn1 = enemiesPerRound1[round];
        enemiesLeft1 = enemiesPerRound1[round];
        enemiesToSpawn2 = enemiesPerRound2[round];
        enemiesLeft2 = enemiesPerRound2[round];
        enemiesToSpawn3 = enemiesPerRound3[round];
        enemiesLeft3 = enemiesPerRound3[round];

        round++;
    }
}
