using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUD_Manager : MonoBehaviour
{
    public static HUD_Manager instance;
    Generator generator;
    GameManager gameManager;
    CameraController cameraController;
    ColocatorManager colocatorManager;
    GameFlow gameFlow;

    [Header("Sliders")]
    public Slider[] sliders = new Slider[6];
    [Space]
    public TextMeshProUGUI[] porcentajes = new TextMeshProUGUI[6];

    [Header("CanActivate")]
    public TextMeshProUGUI[] canActivate = new TextMeshProUGUI[3];

    [Header("Temporal messages")]
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI roundText;

    [Header("Tower Info")]
    public bool isShowInfo = false;
    public Tower activeTower;
    [Space]
    public GameObject fichaTecnica;
    public TextMeshProUGUI towerName;
    public Image icon;
    public TextMeshProUGUI towerDescription;
    public TextMeshProUGUI levelUpButton;
    public TextMeshProUGUI sellButton;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        generator = Generator.instance;
        gameManager = GameManager.instance;
        cameraController = CameraController.instance;
        colocatorManager = ColocatorManager.instance;
        gameFlow = GameFlow.instance;
    }

    void Update()
    {
        generator.probabilityStraight = (int)(sliders[0].value * 100);
        generator.probabilityNewWays = (int)(sliders[1].value * 100);
        generator.probabilityDeleteWay = (int)(sliders[2].value * 100);
        generator.probabilitySpecialTiles = (int)(sliders[3].value * 100);
        generator.probabilityObstacles = (int)(sliders[4].value * 100);
        generator.probabilityConectWays = (int)(sliders[5].value * 100);

        porcentajes[0].text = ((int)(sliders[0].value * 100)).ToString() + "%";
        porcentajes[1].text = ((int)(sliders[1].value * 100)).ToString() + "%";
        porcentajes[2].text = ((int)(sliders[2].value * 100)).ToString() + "%";
        porcentajes[3].text = ((int)(sliders[3].value * 100)).ToString() + "%";
        porcentajes[4].text = ((int)(sliders[4].value * 100)).ToString() + "%";
        porcentajes[5].text = ((int)(sliders[5].value * 100)).ToString() + "%";

        coinsText.text = "Monedas: " + gameFlow.coins.ToString();
        roundText.text = "Ronda: " + gameFlow.round.ToString();

        if (isShowInfo && (Input.GetButtonDown("Fire2") || Input.GetButton("Fire2")))
        {
            isShowInfo = false;

            fichaTecnica.SetActive(false);
        }

        if (activeTower != null)
        {
            towerDescription.text =
            " ----- STATS -----\n" +
            "Nivel: " + activeTower.level + "\n" +
            "Vida: " + activeTower.health + "\n" +
            "Armadura: " + activeTower.armor + "\n" +
            "Rango: " + activeTower.range + "\n" +
            "Velocidad de disparo: " + activeTower.fireRate + "\n" +
            "Velocidad de giro: " + activeTower.turnSpeed + "\n" +
            " ----- DA�OS -----\n" +
            "Vida: " + activeTower.healthDamage + "\n" +
            "Armadura: " + activeTower.armorDamage + "\n" +
            "Hielo: " + activeTower.iceDamage + "%" + "\n" +
            "Fuego: " + activeTower.igniteDamage + "%" + "\n" +
            "Agua: " + activeTower.waterDamage + "%" + "\n" +
            "Ascensi�n: " + activeTower.ascentDamage + "%" + "\n" +
            "Sangrado: " + activeTower.bloodDamage + "%" + "\n" +
            "Locura: " + activeTower.transformationDamage + "%" + "\n"
            ;

            levelUpButton.text = "Mejorar" + "\n" + "(" + activeTower.levelUpPrice + ")";
            sellButton.text = "Vender" + "\n" + "(" + (int)(activeTower.acumulateGold * 0.7f) + ")";
        }
    }

    public void AddCoins(int newCoins)
    {
        gameFlow.coins += newCoins;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AbleSpawn()
    {
        gameManager.doSpawnEnemies = !gameManager.doSpawnEnemies;
    }
    public void LockCamera()
    {
        cameraController.doMovement = !cameraController.doMovement;
    }
    public void BuildTower()
    {
        colocatorManager.canBuild = !colocatorManager.canBuild;
    }
    public void ChangeTower(int id)
    {
        if (colocatorManager.towerID == id)
        {
            colocatorManager.canBuild = false;
        }
        else
        {
            colocatorManager.towerID = id;
            colocatorManager.canBuild = true;
        }
    }

    public void MoveCameraW()
    {
        cameraController.gameObject.transform.Translate(new Vector3(-7, 0, 7), Space.World);
    }
    public void MoveCameraS()
    {
        cameraController.gameObject.transform.Translate(new Vector3(7, 0, -7), Space.World);
    }
    public void MoveCameraD()
    {
        cameraController.gameObject.transform.Translate(new Vector3(7, 0, 7), Space.World);
    }
    public void MoveCameraA()
    {
        cameraController.gameObject.transform.Translate(new Vector3(-7, 0, -7), Space.World);
    }

    public void ShowTowerInfo(Tower tower)
    {
        activeTower = tower;

        towerName.text = tower.towerName;
        //icon = tower.icon;
        towerDescription.text =
            " ----- STATS -----\n" +
            "Nivel: " + tower.level + "\n" +
            "Vida: " + tower.health + "\n" + 
            "Armadura: " + tower.armor + "\n" +
            "Rango: " + tower.range + "\n" +
            "Velocidad de disparo: " + tower.fireRate + "\n" +
            "Velocidad de giro: " + tower.turnSpeed + "\n" +
            " ----- DA�OS -----\n" +
            "Vida: " + tower.healthDamage + "\n" +
            "Armadura: " + tower.armorDamage + "\n" +
            "Hielo: " + tower.iceDamage + "%" + "\n" +
            "Fuego: " + tower.igniteDamage + "%" + "\n" +
            "Agua: " + tower.waterDamage + "%" + "\n" +
            "Ascensi�n: " + tower.ascentDamage + "%" + "\n" +
            "Sangrado: " + tower.bloodDamage + "%" + "\n" +
            "Locura: " + tower.transformationDamage + "%" + "\n"
            ;

        levelUpButton.text = "Mejorar" + "\n" + "(" + tower.levelUpPrice + ")";
        sellButton.text = "Vender" + "\n" + "(" + (int)(tower.acumulateGold * 0.7f) + ")";

        Invoke("CanDisableFichaTecnica", 0.2f);
        fichaTecnica.SetActive(true);
    }

    void CanDisableFichaTecnica()
    {
        isShowInfo = true;
    }

    public void LevelUp()
    {
        if (activeTower.level < 5 && gameFlow.coins >= activeTower.levelUpPrice)
        {
            gameFlow.coins -= activeTower.levelUpPrice;

            activeTower.level++;
            activeTower.acumulateGold += activeTower.levelUpPrice;
            activeTower.levelUpPrice = (int)(activeTower.levelUpPrice * activeTower.levelMultiplier);

            activeTower.healthMax = (int)(activeTower.healthMax * activeTower.levelMultiplier);
            activeTower.health = (int)(activeTower.health * activeTower.levelMultiplier);
            activeTower.armorMax = (int)(activeTower.armorMax * activeTower.levelMultiplier);
            activeTower.armor = (int)(activeTower.armor * activeTower.levelMultiplier);
            activeTower.range = (int)(activeTower.range * activeTower.levelMultiplier);
            activeTower.fireRate = (int)(activeTower.fireRate * activeTower.levelMultiplier);
            activeTower.turnSpeed = (int)(activeTower.turnSpeed * activeTower.levelMultiplier);

            activeTower.healthDamage = (int)(activeTower.healthDamage * activeTower.levelMultiplier);
            activeTower.armorDamage = (int)(activeTower.armorDamage * activeTower.levelMultiplier);
            activeTower.iceDamage = (int)(activeTower.iceDamage * activeTower.levelMultiplier);
            activeTower.igniteDamage = (int)(activeTower.igniteDamage * activeTower.levelMultiplier);
            activeTower.waterDamage = (int)(activeTower.waterDamage * activeTower.levelMultiplier);
            activeTower.ascentDamage = (int)(activeTower.ascentDamage * activeTower.levelMultiplier);
            activeTower.bloodDamage = (int)(activeTower.bloodDamage * activeTower.levelMultiplier);
            activeTower.transformationDamage = (int)(activeTower.transformationDamage * activeTower.levelMultiplier);

            if (activeTower.level == 5)
            {
                // Poner luz
            }
        }
    }
    public void SellTower()
    {
        gameFlow.coins += (int)(activeTower.acumulateGold * 0.7f);

        Destroy(activeTower.gameObject);

        activeTower = null;
        fichaTecnica.SetActive(false);
    }

    public void SelectTowerCard(int id)
    {
        switch (id)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
            case 10:

                break;
            case 11:

                break;
            case 12:

                break;
            case 13:

                break;
            case 14:

                break;
            case 15:

                break;
            case 16:

                break;
            case 17:

                break;
            case 18:

                break;
        }

        gameFlow.ShowCards();
    }
    public void SelectEnemyCard(int id)
    {
        switch (id)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
            case 10:

                break;
            case 11:

                break;
            case 12:

                break;
            case 13:

                break;
            case 14:

                break;
            case 15:

                break;
            case 16:

                break;
            case 17:

                break;
            case 18:

                break;
        }

        gameFlow.HideCards();
    }
}
