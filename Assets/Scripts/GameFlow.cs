using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    Generator generator;
    GameManager gameManager;

    public int round = 0;
    public int coins = 100;

    public int totalRounds;

    public bool roundFinished = true;
    public bool nextRound = false;

    [Header("Enemy waves")]
    public float spawnRate;

    public GameObject[] enemies;
    public int[] enemiesPerRound1;
    public int[] enemiesPerRound2;
    public int[] enemiesPerRound3;

    public int enemiesToSpawn1 = 0;
    public int enemiesLeft1 = 0;
    public int enemiesToSpawn2 = 0;
    public int enemiesLeft2 = 0;
    public int enemiesToSpawn3 = 0;
    public int enemiesLeft3 = 0;

    [Header("Dados")]
    public bool activateDados;

    public Vector2[] cardsPos;
    public Button[] towerCardsLevel1;
    public Button[] towerCardsLevel2;
    public Button[] towerCardsLevel3;
    public Button[] enemyCardsLevel1;
    public Button[] enemyCardsLevel2;
    public Button[] enemyCardsLevel3;
    public Image blockCard;

    public int cardsRate;

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
            enemiesPerRound3[i] = 0;
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
        nextRound = true;
        Invoke("StopNextRound", 0.2f);

        foreach (GameObject newNode in generator.newMapNodes)
        {
            if (newNode != null)
            {
                newNode.SetActive(false);
            }
        }

        enemiesToSpawn1 = enemiesPerRound1[round];
        enemiesLeft1 = enemiesPerRound1[round];
        enemiesToSpawn2 = enemiesPerRound2[round];
        enemiesLeft2 = enemiesPerRound2[round];
        enemiesToSpawn3 = enemiesPerRound3[round];
        enemiesLeft3 = enemiesPerRound3[round];

        round++;

        if (round % cardsRate == 0 && activateDados)
        {
            int rarity1 = Random.Range(0, 3);
            int numCards1 = Random.Range(0, 6);

            switch (rarity1)
            {
                case 0:
                    for (int i = 0; i < numCards1; i++)
                    {
                        int choose = Random.Range(0, towerCardsLevel1.Length);

                        towerCardsLevel1[choose].transform.position = cardsPos[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < numCards1; i++)
                    {
                        int choose = Random.Range(0, towerCardsLevel2.Length);

                        towerCardsLevel2[choose].transform.position = cardsPos[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < numCards1; i++)
                    {
                        int choose = Random.Range(0, towerCardsLevel3.Length);

                        towerCardsLevel3[choose].transform.position = cardsPos[i];
                    }
                    break;
            }

            //Invoke("StartRoundDelay", 5);
        }
        else
        {
            gameManager.doSpawnEnemies = true;
        }
    }

    void StopNextRound()
    {
        nextRound = false;
    }

    public void ShowCards()
    {
        foreach (var card in towerCardsLevel1)
        {
            card.transform.position = new Vector2(1000, 1000);
        }
        foreach (var card in towerCardsLevel2)
        {
            card.transform.position = new Vector2(1000, 1000);
        }
        foreach (var card in towerCardsLevel3)
        {
            card.transform.position = new Vector2(1000, 1000);
        }

        int rarity2 = Random.Range(0, 3);
        int numCards2 = Random.Range(0, 6);

        switch (rarity2)
        {
            case 0:
                for (int i = 0; i < numCards2; i++)
                {
                    int choose = Random.Range(0, enemyCardsLevel1.Length);

                    enemyCardsLevel1[choose].transform.position = cardsPos[i];
                }
                break;
            case 1:
                for (int i = 0; i < numCards2; i++)
                {
                    int choose = Random.Range(0, enemyCardsLevel2.Length);

                    enemyCardsLevel2[choose].transform.position = cardsPos[i];
                }
                break;
            case 2:
                for (int i = 0; i < numCards2; i++)
                {
                    int choose = Random.Range(0, enemyCardsLevel3.Length);

                    enemyCardsLevel3[choose].transform.position = cardsPos[i];
                }
                break;
        }
    }

    public void HideCards()
    {
        foreach (var card in enemyCardsLevel1)
        {
            card.transform.position = new Vector2(1000, 1000);
        }
        foreach (var card in enemyCardsLevel2)
        {
            card.transform.position = new Vector2(1000, 1000);
        }
        foreach (var card in enemyCardsLevel3)
        {
            card.transform.position = new Vector2(1000, 1000);
        }
    }

    void StartRoundDelay()
    {
        gameManager.doSpawnEnemies = true;
    }
}
