using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    Generator generator;
    GameManager gameManager;
    HUD_Manager hudManager;

    [Header("Basic")]
    public int totalRounds;
    public int round = 0;
    [Space]
    public int coins = 650;
    public int specialCoins = 20;
    public int newSpecialCoinsPerRound = 5;
    [Space]
    public bool roundFinished = true;
    public bool nextRound = false;
    [Space]
    public int idTile = 1;

    [Header("Zona Desierto")]
    public ParticleSystem sandStorm;
    [Range(0, 100)]
    public int sandStormProbavility;
    public int sandStormDuration;
    public Vector3 lastNodePosition;
    bool isActiveSandStorm = true;
    int startSandStormRound = -1;
    ParticleSystem instSandStorm;

    [Header("Zona Agua")]
    public GameObject waterFlag;
    public Material healthBarGreen;
    public Material healthBarYellow;
    public Material healthBarRed;
    int changeWaterRate = 3;
    public float newSpeed = 1;

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
        hudManager = HUD_Manager.instance;

        cardsScripts = new Card[cardsPos.Length];
        for (int i = 0; i < cardsPos.Length; i++)
        {
            cardsScripts[i] = cardsPos[i].GetComponent<Card>();
            cardsScripts[i].id = i;
        }
        /*
        enemiesPerRound1 = new int[totalRounds];
        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound1[i] = (i * i * 1) + 1;
        }

        enemiesPerRound2 = new int[totalRounds];
        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound2[i] = (i * 1) + 1;
            //enemiesPerRound2[i] = 0;
        }

        enemiesPerRound3 = new int[totalRounds];
        for (int i = 0; i < totalRounds; i++)
        {
            enemiesPerRound3[i] = (i / 2) + 1;
            enemiesPerRound3[i] = 0;
        }
        */
    }

    void Update()
    {
        if (enemiesLeft1 <= 0 && enemiesLeft2 <= 0  && enemiesLeft3 <= 0 && !roundFinished)
        {
            roundFinished = true;
            specialCoins += newSpecialCoinsPerRound;
            gameManager.doSpawnEnemies = false;

            if (activateDados && showCards)
            {
                showCards = false;
                cardSelected = false;
                dadosBackGround.gameObject.SetActive(true);

                // Towers cards
                int towerCardAmount = Random.Range(1, 7);
                int towerCardRarity = Random.Range(0, 3);

                foreach (var cardPos in cardsPos)
                {
                    cardPos.gameObject.SetActive(true);
                }
                foreach (var cardScript in cardsScripts)
                {
                    cardScript.NewTowerCard(towerCardAmount, towerCardRarity);
                }

                // Enemies cards

            }

            if (round % generator.expandRate == 0)
            {
                foreach (var newNode in generator.newMapNodes)
                {
                    if (newNode != null)
                    {
                        newNode.SetActive(true);
                    }
                }
            }
            else
            {
                hudManager.nextRoundButton.gameObject.SetActive(true);
            }

            if (generator.newMapNodes.Count == 0)
            {
                hudManager.nextRoundButton.gameObject.SetActive(true);
            }
        }
    }

    public void StartRound()
    {
        roundFinished = false;
        nextRound = true;
        Invoke("StopNextRound", 0.2f);
        gameManager.doSpawnEnemies = true;

        hudManager.nextRoundButton.gameObject.SetActive(false);
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

        if (round == 4)
        {
            generator.expandRate = 2;
        }
        if (round == 10)
        {
            generator.expandRate = 3;
        }
        if (round == 15)
        {
            generator.expandRate = 4;
        }
        if (round == 20)
        {
            generator.expandRate = 5;
        }

        
        if (round % cardsRate == 0)
        {
            showCards = true;
        }

        if (generator.zone == Generator.Zone.Hielo)
        {

        }
        
        if (generator.zone == Generator.Zone.Desierto)
        {
            if (!isActiveSandStorm)
            {
                int spawnSandStorm = Random.Range(0, 100);

                if (spawnSandStorm < sandStormProbavility && !isActiveSandStorm)
                {
                    startSandStormRound = round;
                    isActiveSandStorm = true;
                    instSandStorm = Instantiate(sandStorm, lastNodePosition, Quaternion.identity);
                    instSandStorm.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
                }
            }

            if (round == (startSandStormRound + sandStormDuration))
            {
                Destroy(instSandStorm);
                isActiveSandStorm = false;
            }
        }

        if (generator.zone == Generator.Zone.Atlantis)
        {
            if (round % changeWaterRate == 0)
            {
                int newSpeedRandom = Random.Range(0, 3);
                //newSpeedRandom = 2;

                switch (newSpeedRandom)
                {
                    case 0:
                        newSpeed = 0.5f;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarGreen;
                        break;
                    case 1:
                        newSpeed = 1;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarYellow;
                        break;
                    case 2:
                        newSpeed = 2;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarRed;
                        break;
                }
            }
        }

        round++;
    }

    void StopNextRound()
    {
        nextRound = false;
    }
}
