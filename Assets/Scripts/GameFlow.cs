using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
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
    public int coins = 1000;
    public int specialCoins = 20;
    public int newSpecialCoinsPerRound = 5;
    [Space]
    public bool roundFinished = true;
    public bool nextRound = false;
    [Space]
    public int idTile = 1;

    [Header("Zona Desierto")]
    public ParticleSystem sandStorm;
    public GameObject sandStormGO;
    [Range(0, 100)]
    public int sandStormProbavility;
    public int sandStormDuration;
    public Vector3 lastNodePosition;
    bool isActiveSandStorm = true;
    int startSandStormRound = -1;
    ParticleSystem instSandStorm;
    GameObject instSandStormGO;

    [Header("Zona Agua")]
    public GameObject waterFlag;
    public Material healthBarGreen;
    public Material healthBarYellow;
    public Material healthBarRed;
    int changeWaterRate = 3;
    public float newSpeed = 1;

    public GameObject mareaInfo;
    public TextMeshProUGUI mareaInfoText;

    [Header("Enemy waves")]
    public float spawnRate;

    public GameObject[] enemies;
    public int[] enemiesPerRound1;
    public int[] enemiesPerRound2;
    public int[] enemiesPerRound3;

    public GameObject skeleton;

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

    public bool canExpand;

    [Header("Summary")]
    public float time = 0;

    public int kills1 = 0;
    public int kills2 = 0;
    public int kills3 = 0;

    public int towersBuild = 0;
    public int towersDestroyed = 0;
    public int heroChanges = 0;

    public int goldSpent = 0;
    public int specialGoldSpent = 0;

    public int miniObjetivesDestroyed = 0;

    [Header("Listas y arrays")]
    public GameObject[] groundTiles;
    public GameObject[] towers;
    public GameObject[] activeEnemies;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject instEnemy = Instantiate(enemies[i], new Vector3(0, 1.25f, 0), transform.rotation);

            instEnemy.SetActive(false);

            instEnemy.transform.position = new Vector3(0, -1000, 0);

            enemies[i] = instEnemy;
        }
    }

    void Start()
    {
        generator = Generator.instance;
        gameManager = GameManager.instance;
        hudManager = HUD_Manager.instance;

        InvokeRepeating("UpdateLists", 0.1f, 1);

        cardsScripts = new Card[cardsPos.Length];
        for (int i = 0; i < cardsPos.Length; i++)
        {
            cardsScripts[i] = cardsPos[i].GetComponent<Card>();
            cardsScripts[i].id = i;
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if ((enemiesLeft1 <= 0 && enemiesLeft2 <= 0  && enemiesLeft3 <= 0 && !roundFinished))
        {
            roundFinished = true;

            if (round == totalRounds && MainTower.instance.health > 0)
            {
                if (gameManager.levelSelectedPublic + 1 >= gameManager.levelMaxPublic && !gameManager.invitatePublic)
                {
                    DataManger.instance.SaveData(gameManager.levelSelectedPublic + 1);
                }
                
                if (generator.zone == Generator.Zone.Infierno)
                {
                    hudManager.panelEnd.SetActive(true);
                }
                else
                {
                    int minutes = (int)time / 60;
                    int seconds = (int)time % 60;

                    hudManager.summaryTextWin.text =
                    //"Tiempo: " + (int)gameFlow.time + " segundos" + "\n" +
                    "Tiempo: " + minutes + ":" + seconds + "\n" +
                    "Ronda: " + round + "\n" +
                    "Muertes enemigos enanos: " + kills1 + "\n" +
                    "Muertes enemigos medianos: " + kills2 + "\n" +
                    "Muertes enemigos bosses: " + kills3 + "\n" +
                    "Torres construidas: " + towersBuild + "\n" +
                    "Torres destruidas: " + towersDestroyed + "\n" +
                    "Monedas gastadas: " + goldSpent + "\n" +
                    "Cristales gastadas: " + specialGoldSpent + "\n" +
                    "Mini objetivos destruidos: " + miniObjetivesDestroyed + "\n"
                    ;

                    hudManager.winScreen.SetActive(true);

                    hudManager.CanExitInvoke();
                }

                return;
            }

            BackgroundMusic.instance.ChangeClip();

            specialCoins += newSpecialCoinsPerRound;
            gameManager.doSpawnEnemies = false;

            if (activateDados && showCards)
            {
                SoundManager.instance.SoundSelection(4, 0.5f);

                showCards = false;
                cardSelected = false;

                hudManager.dadosBackGround.gameObject.SetActive(true);

                // Towers cards
                int towerCardAmount = Random.Range(1, 7);
                int towerCardRarity = Random.Range(0, 3);

                hudManager.dicesImage.sprite = hudManager.dicesImages[towerCardAmount - 1];
                hudManager.dicesText.text = "Has conseguido " + towerCardAmount + " cartas";

                foreach (var cardPos in cardsPos)
                {
                    cardPos.gameObject.SetActive(true);
                }
                foreach (var cardScript in cardsScripts)
                {
                    cardScript.NewTowerCard(towerCardAmount, towerCardRarity);
                }
            }

            if ((round % generator.expandRate == 0 || round == 1) && round != totalRounds - 1)
            {
                generator.idRoundTile++;

                if (generator.newMapNodes.Count > 0)
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
            }
            else
            {
                hudManager.nextRoundButton.gameObject.SetActive(true);
            }

            if (generator.newMapNodes.Count == 0)
            {
                hudManager.nextRoundButton.gameObject.SetActive(true);
            }

            if (round >= totalRounds)
            {
                print("Has ganado");
            }
        }
    }

    public void StartRound()
    {
        CameraController.instance.CameraCanMove();

        BackgroundMusic.instance.ChangeClip();

        if (ColocatorManager.instance.heroBuild)
        {
            HUD_Manager.instance.towersButtonIcon[0].GetComponent<Button>().interactable = false;
        }

        if (round == totalRounds - 1 && generator.zone == Generator.Zone.Infierno)
        {
            generator.GenerateFinalBossMap();
        }

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

        if (round % cardsRate == 0)
        {
            showCards = true;
        }

        if ((round + 1) % 6 == 0)
        {
            mareaInfo.SetActive(true);
            Invoke("DisableMareaInfo", 4);

            mareaInfoText.text = "En la siguiente ronda tienes que defender una base aliada";
        }
        //if (round % 10 == 0 && round > 2)
        if (round + 1 < totalRounds)
        {
            if (enemiesPerRound3[round + 1] > 0)
            {
                mareaInfo.SetActive(true);
                Invoke("DisableMareaInfo", 4);

                mareaInfoText.text = "En la siguiente ronda viene un fuerte rival";
            }
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
                    instSandStormGO = Instantiate(sandStormGO, lastNodePosition, Quaternion.identity);
                    //instSandStormGO.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
                }
            }

            if (round == (startSandStormRound + sandStormDuration))
            {
                //instSandStormGO.GetComponent<BoxCollider>().enabled = false;
                Destroy(instSandStormGO);
                isActiveSandStorm = false;
            }
        }

        if (generator.zone == Generator.Zone.Atlantis)
        {
            if (round % changeWaterRate == 0)
            {
                int newSpeedRandom = Random.Range(0, 3);
                //newSpeedRandom = 2;
                mareaInfo.SetActive(true);
                Invoke("DisableMareaInfo", 4);

                if (round < 3)
                {
                    newSpeedRandom = Random.Range(0, 2);
                }

                switch (newSpeedRandom)
                {
                    case 0:
                        newSpeed = 0.5f;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarGreen;
                        mareaInfoText.text = "La marea te ayuda";
                        break;
                    case 1:
                        newSpeed = 1;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarYellow;
                        mareaInfoText.text = "La marea se ha calmado";
                        break;
                    case 2:
                        newSpeed = 1.75f;
                        waterFlag.GetComponent<MeshRenderer>().material = healthBarRed;
                        mareaInfoText.text = "La marea te perjudica";
                        break;
                }
            }
        }

        round++;
        MainTower.instance.restRounds--;
        MainTower.instance.restRounds = Mathf.Max(MainTower.instance.restRounds, 0);
        hudManager.hechizoText.text = MainTower.instance.restRounds.ToString();
    }

    void DisableMareaInfo()
    {
        mareaInfo.SetActive(false);
    }

    void StopNextRound()
    {
        nextRound = false;
    }

    void UpdateLists()
    {
        groundTiles = GameObject.FindGameObjectsWithTag("Ground");
        towers = GameObject.FindGameObjectsWithTag("Tower");


        GameObject[] activeEnemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> activeEnemiesList = new List<GameObject>();
        foreach (var item in activeEnemiesArray)
        {
            if (item.GetComponent<Enemy>())
            {
                activeEnemiesList.Add(item);
            }
        }

        activeEnemies = new GameObject[activeEnemiesList.Count];
        int aux = 0;
        foreach (var item in activeEnemiesList)
        {
            activeEnemies[aux] = item;
            aux++;
        }
    }

    public void MiniObjetiveDestroyed()
    {
        mareaInfo.SetActive(true);
        Invoke("DisableMareaInfo", 4);

        mareaInfoText.text = "Oh no, te han destruido la base aliada, has perdido 7 de vida, tienes que estar más atento soldado";
    }
}
