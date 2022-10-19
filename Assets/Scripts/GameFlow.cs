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
    public int coins = 250;
    public int specialCoins = 50;
    public int newSpecialCoinsPerRound = 5;

    public int totalRounds;

    public bool roundFinished = true;
    public bool nextRound = false;

    [Header("Zona Desierto")]
    public ParticleSystem sandStorm;
    [Range(0, 100)]
    public int sandStormProbavility;
    public int sandStormDuration;
    public Vector3 lastNodePosition;
    bool isActiveSandStorm = true;
    int startSandStormRound = -1;
    ParticleSystem instSandStorm;

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
    
    public Image[] cardsPos;
    public Card[] cardsScripts;

    public int cardsRate;

    public bool showCards = false;
    public bool cardSelected = true;

    public Image dadosBackGround;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        generator = Generator.instance;
        gameManager = GameManager.instance;

        cardsScripts = new Card[cardsPos.Length];
        for (int i = 0; i < cardsPos.Length; i++)
        {
            cardsScripts[i] = cardsPos[i].GetComponent<Card>();
            cardsScripts[i].id = i;
        }

        enemiesPerRound1 = new int[totalRounds];
        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound1[i] = (i * i * 3) + 1;
        }

        enemiesPerRound2 = new int[totalRounds];
        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound2[i] = (i * 3) + 1;
            //enemiesPerRound2[i] = 0;
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

            if (activateDados && showCards)
            {
                showCards = false;
                cardSelected = false;
                dadosBackGround.gameObject.SetActive(true);

                // Towers cards
                int towerCardAmount = Random.Range(1, 7);
                int towerCardRarity = Random.Range(0, 3);

                print("Cantidad: " + towerCardAmount);
                print("Rareza: " + towerCardRarity);

                foreach (var cardPos in cardsPos)
                {
                    //cardPos.enabled = true;
                    cardPos.gameObject.SetActive(true);
                }
                foreach (var cardScript in cardsScripts)
                {
                    cardScript.NewTowerCard(towerCardAmount, towerCardRarity);
                }

                // Enemies cards

            }

            specialCoins += newSpecialCoinsPerRound;

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
        if (round == (startSandStormRound + sandStormDuration))
        {
            Destroy(instSandStorm);
            isActiveSandStorm = false;
        }

        if (!isActiveSandStorm)
        {
            int spawnSandStorm = Random.Range(0, 100);

            if (spawnSandStorm < sandStormProbavility)
            {
                startSandStormRound = round;
                isActiveSandStorm = true;
                instSandStorm = Instantiate(sandStorm, lastNodePosition, Quaternion.identity);
                instSandStorm.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
            }
        }

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

        gameManager.doSpawnEnemies = true;

        if (round % cardsRate == 0)
        {
            showCards = true;
        }
    }

    void StopNextRound()
    {
        nextRound = false;
    }
}
