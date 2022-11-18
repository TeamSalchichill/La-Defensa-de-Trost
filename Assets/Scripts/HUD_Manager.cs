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
    MainTower mainTower;

    [Header("Sliders")]
    public Slider[] sliders = new Slider[6];
    [Space]
    public TextMeshProUGUI[] porcentajes = new TextMeshProUGUI[6];

    [Header("CanActivate")]
    public TextMeshProUGUI[] canActivate = new TextMeshProUGUI[3];
    public Button nextRoundButton;

    [Header("Temporal messages")]
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI specialCoinsText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemiesText1;
    public TextMeshProUGUI enemiesText2;
    public TextMeshProUGUI enemiesText3;

    [Header("Tower Info")]
    public bool isShowInfo = false;
    public Tower activeTower;
    [Space]
    public GameObject fichaTecnica;
    public TextMeshProUGUI towerName;
    public Image icon;
    public TextMeshProUGUI towerDescription1;
    public TextMeshProUGUI towerDescription2;
    public TextMeshProUGUI levelUpButton;
    public TextMeshProUGUI sellButton;
    [Space]
    public GameObject preferencesBoard;

    [Header("Tower Buttons")]
    public TextMeshProUGUI[] towersButton;

    [Header("Screens")]
    public GameObject pauseScreen;
    public GameObject noTocar;

    [Header("Tower Banner")]
    public GameObject towerBanner;
    public bool showTowerBanner = true;
    public GameObject towerBannerButton;
    public TextMeshProUGUI towerBannerText;

    [Header("Game Over")]
    public GameObject gameOverScreen;

    [Header("Utility Buttons")]
    public GameObject towerPotionButton;
    public GameObject towerPotionIcon;
    public Color towerPotionButtonColorHover;
    public Color towerPotionIconColorHover;
    
    [Header("Particles")]
    public GameObject levelUpParticle;
    public GameObject levelUpSpecialParticle;
    
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
        mainTower = MainTower.instance;

        for (int i = 0; i < towersButton.Length; i++)
        {
            towersButton[i].text = colocatorManager.towers[i].GetComponent<Tower>().towerName + "\n" + "(" + colocatorManager.towers[i].GetComponent<Tower>().price + "€)";
        }
    }

    void Update()
    {
        if (activeTower == null)
        {
            fichaTecnica.SetActive(false);
        }

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

        coinsText.text = gameFlow.coins.ToString();
        specialCoinsText.text = gameFlow.specialCoins.ToString();
        roundText.text = "Ronda: " + gameFlow.round.ToString();
        if (mainTower == null)
        {
            mainTower = MainTower.instance;
        }
        healthText.text = mainTower.health.ToString();
        enemiesText1.text = "" + gameFlow.enemiesLeft1;
        enemiesText2.text = "" + gameFlow.enemiesLeft2;
        enemiesText3.text = "" + gameFlow.enemiesLeft3;

        if (isShowInfo && (Input.GetButtonDown("Fire2") || Input.GetButton("Fire2")))
        {
            isShowInfo = false;

            activeTower.rangeArea.SetActive(false);

            fichaTecnica.SetActive(false);

            preferencesBoard.SetActive(false);
        }

        if (activeTower != null)
        {
            towerName.text = activeTower.towerName + " - Nivel: " + activeTower.level;
            if (activeTower.icon != null)
            {
                icon.sprite = activeTower.icon;
            }
            towerDescription1.text =
            " ---- STATS ----\n" +
            "Daño: " + activeTower.healthDamage + "\n" +
            "Rango: " + activeTower.range + "\n" +
            "Vel. disparo: " + activeTower.fireRate + "\n" +
            "Vida: " + activeTower.health + "\n"
            //"Velocidad de giro: " + activeTower.turnSpeed + "\n" +
            ;
            towerDescription2.text =
            "-- EFFECTS --\n" +
            "Hielo: " + activeTower.iceDamage + "%" + "\n" +
            "Fuego: " + activeTower.igniteDamage + "%" + "\n" +
            "Agua: " + activeTower.waterDamage + "%" + "\n" +
            "Ascensión: " + activeTower.ascentDamage + "%" + "\n" +
            "Sangrado: " + activeTower.bloodDamage + "%" + "\n" +
            "Locura: " + activeTower.transformationDamage + "%" + "\n"
            ;

            if (activeTower.level == 5)
            {
                levelUpButton.gameObject.SetActive(false);
            }
            else
            {
                levelUpButton.gameObject.SetActive(true);
            }

            float actualHealth = activeTower.health;
            float actualHealthMax = activeTower.healthMax;

            float healthPercent = actualHealth / actualHealthMax;

            levelUpButton.text = "Mejorar" + "\n" + "(" + activeTower.levelUpPrice + activeTower.priceLogo + ")";
            sellButton.text = "Vender" + "\n" + "(" + (int)(activeTower.acumulateGold * 0.7f * healthPercent) + "€)";
        }

        if (activeTower != null && activeTower.health < 0)
        {
            fichaTecnica.SetActive(false);
        }

        if (Time.timeScale == 0)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }

        if (showTowerBanner)
        {
            towerBanner.SetActive(true);
            towerBannerText.text = "Ocultar";
            towerBannerButton.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2, Screen.height / 2);
        }
        else
        {
            towerBanner.SetActive(false);
            towerBannerText.text = "Mostrar";
            towerBannerButton.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2, (Screen.height / 9) * 2.5f);
        }

        if (mainTower.activateTower)
        {
            towerPotionIcon.GetComponent<Image>().color = towerPotionIconColorHover;
        }
        else
        {
            towerPotionIcon.GetComponent<Image>().color = Color.white;
        }
        if (mainTower.restRounds <= 0)
        {
            towerPotionButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            towerPotionButton.GetComponent<Image>().color = towerPotionButtonColorHover;
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
    public void ExitGame()
    {
        Application.Quit();
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
        //colocatorManager.canBuild = !colocatorManager.canBuild;
    }
    public void ChangeTower(int id)
    {
        isShowInfo = false;

        if (activeTower != null)
        {
            activeTower.rangeArea.SetActive(false);
        }

        fichaTecnica.SetActive(false);
        /*
        if (colocatorManager.towerID == id)
        {
            colocatorManager.canBuild = false;
        }
        else
        {
            colocatorManager.towerID = id;
            colocatorManager.canBuild = true;
        }
        */
        colocatorManager.towerID = id;
        colocatorManager.canBuild = true;

        colocatorManager.canDisableColocatotMode = 1;
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
        if (activeTower != null)
        {
            activeTower.rangeArea.SetActive(false);
        }

        activeTower = tower;

        tower.rangeArea.SetActive(true);
        /*
        towerName.text = tower.towerName;
        //icon = tower.icon;
        
        towerDescription.text =
            " ----- STATS -----\n" +
            "Nivel: " + tower.level + "\n" +
            "Vida: " + tower.health + "\n" + 
            "Rango: " + tower.range + "\n" +
            "Velocidad de disparo: " + tower.fireRate + "\n" +
            "Velocidad de giro: " + tower.turnSpeed + "\n" +
            " ----- DAÑOS -----\n" +
            "Vida: " + tower.healthDamage + "\n" +
            "Hielo: " + tower.iceDamage + "%" + "\n" +
            "Fuego: " + tower.igniteDamage + "%" + "\n" +
            "Agua: " + tower.waterDamage + "%" + "\n" +
            "Ascensión: " + tower.ascentDamage + "%" + "\n" +
            "Sangrado: " + tower.bloodDamage + "%" + "\n" +
            "Locura: " + tower.transformationDamage + "%" + "\n"
            ;
        
        if (tower.level == 5)
        {
            levelUpButton.gameObject.SetActive(false);
        }
        else
        {
            levelUpButton.gameObject.SetActive(true);
        }
        
        levelUpButton.text = "Mejorar" + "\n" + "(" + tower.levelUpPrice + ")";
        sellButton.text = "Vender" + "\n" + "(" + (int)(tower.acumulateGold * 0.7f) + ")";
        */
        Invoke("CanDisableFichaTecnica", 0.2f);
        fichaTecnica.SetActive(true);
    }

    void CanDisableFichaTecnica()
    {
        isShowInfo = true;
    }

    public void LevelUp()
    {
        if ((activeTower.level < 4 && gameFlow.coins >= activeTower.levelUpPrice) || (activeTower.level == 4 && gameFlow.specialCoins >= activeTower.levelUpPrice))
        {
            if (activeTower.level < 4)
            {
                GameObject instParticle = Instantiate(levelUpParticle, activeTower.transform.position, transform.rotation);
                Destroy(instParticle, 3);
                
                gameFlow.coins -= activeTower.levelUpPrice;
            }
            else
            {
                GameObject instParticle = Instantiate(levelUpSpecialParticle, activeTower.transform.position, transform.rotation);
                instParticle.transform.rotation = Quaternion.AngleAxis(270, Vector3.right);
                Destroy(instParticle, 3);
                
                gameFlow.specialCoins -= activeTower.levelUpPrice;

                activeTower.gameObject.AddComponent<RecolocateManual>();
            }
            
            activeTower.level++;
            activeTower.acumulateGold += activeTower.levelUpPrice;

            if (activeTower.level < 4)
            {
                activeTower.levelUpPrice = (int)(activeTower.levelUpPrice * activeTower.levelMultiplier);
            }
            else
            {
                activeTower.levelUpPrice = activeTower.level5Price;
                activeTower.priceLogo = "$";
            }


            activeTower.numTargets++;
            activeTower.healthMax = (int)(activeTower.healthMax * activeTower.levelMultiplier);
            activeTower.health = (int)(activeTower.health * activeTower.levelMultiplier);
            activeTower.armorMax = (int)(activeTower.armorMax * activeTower.levelMultiplier);
            activeTower.armor = (int)(activeTower.armor * activeTower.levelMultiplier);
            activeTower.range = (int)(activeTower.range * activeTower.levelMultiplier);
            activeTower.fireRate = (activeTower.fireRate * activeTower.levelMultiplier);
            activeTower.turnSpeed = (int)(activeTower.turnSpeed * activeTower.levelMultiplier);

            activeTower.healthDamage = (int)(activeTower.healthDamage * activeTower.levelMultiplier);
            activeTower.armorDamage = (int)(activeTower.armorDamage * activeTower.levelMultiplier);
            activeTower.iceDamage = (int)(activeTower.iceDamage * activeTower.levelMultiplier);
            activeTower.igniteDamage = (int)(activeTower.igniteDamage * activeTower.levelMultiplier);
            activeTower.waterDamage = (int)(activeTower.waterDamage * activeTower.levelMultiplier);
            activeTower.ascentDamage = (int)(activeTower.ascentDamage * activeTower.levelMultiplier);
            activeTower.bloodDamage = (int)(activeTower.bloodDamage * activeTower.levelMultiplier);
            activeTower.transformationDamage = (int)(activeTower.transformationDamage * activeTower.levelMultiplier);

            activeTower.rangeArea.transform.localScale = new Vector3(activeTower.range * activeTower.rangeAreaOriginalScale, activeTower.rangeAreaOriginalScale, activeTower.range * activeTower.rangeAreaOriginalScale);

            switch (activeTower.specialStat)
            {
                case Tower.SpecialStat.None:

                    break;
                case Tower.SpecialStat.Health:
                    activeTower.healthMax = (int)(activeTower.healthMax * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.Range:
                    activeTower.range = (int)(activeTower.range * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.ShootSpeed:
                    activeTower.fireRate = (int)(activeTower.fireRate * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.TurnSpeed:
                    activeTower.turnSpeed = (int)(activeTower.turnSpeed * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.HealthDamage:
                    activeTower.healthDamage = (int)(activeTower.healthDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.IceEffect:
                    activeTower.iceDamage = (int)(activeTower.iceDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.IgniteEffect:
                    activeTower.igniteDamage = (int)(activeTower.igniteDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.WaterEffect:
                    activeTower.waterDamage = (int)(activeTower.waterDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.AscensionEffect:
                    activeTower.ascentDamage = (int)(activeTower.ascentDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.BloodEffect:
                    activeTower.bloodDamage = (int)(activeTower.bloodDamage * activeTower.levelMultiplierSpecialStat);
                    break;
                case Tower.SpecialStat.CrazyEffect:
                    activeTower.transformationDamage = (int)(activeTower.transformationDamage * activeTower.levelMultiplierSpecialStat);
                    break;
            }

            if (activeTower.level == 5)
            {
                activeTower.level5Light.enabled = true;
            }
        }
    }
    public void SellTower()
    {
        if (!activeTower.isHero)
        {
            float actualHealth = activeTower.health;
            float actualHealthMax = activeTower.healthMax;

            float healthPercent = actualHealth / actualHealthMax;

            gameFlow.coins += (int)(activeTower.acumulateGold * 0.7f * healthPercent);

            Destroy(activeTower.gameObject);

            activeTower = null;
            fichaTecnica.SetActive(false);
        }
    }

    public void DisableInfo()
    {
        if (isShowInfo)
        {
            isShowInfo = false;

            if (activeTower != null)
            {
                activeTower.rangeArea.SetActive(false);
            }

            fichaTecnica.SetActive(false);
        }
    }

    public void ChangeScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void ChangeSpeed(int speed)
    {
        Time.timeScale = speed;
    }

    public void StartRoundButtom()
    {
        gameFlow.StartRound();
    }

    public void NoTocar()
    {
        noTocar.SetActive(true);
        Invoke("QuitarNoTocar", 5);
    }
    void QuitarNoTocar()
    {
        noTocar.SetActive(false);
    }

    public void HideTowerBanner()
    {
        showTowerBanner = !showTowerBanner;
    }

    public void ActivateGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void ActivatePotion()
    {
        if (mainTower.restRounds <= 0)
        {
            mainTower.activateTower = true;
        }
    }

    public void Zoom(int zoom)
    {
        cameraController.Zoom(zoom, Camera.main.orthographicSize);
    }

    public void ExitInfo()
    {
        isShowInfo = false;

        activeTower.rangeArea.SetActive(false);

        fichaTecnica.SetActive(false);

        preferencesBoard.SetActive(false);
    }

    public void ChangeEnemyPreference(int newPreference)
    {
        switch (newPreference)
        {
            case 0:
                activeTower.targetPreference = Tower.TargetPreference.Near;
                break;
            case 1:
                activeTower.targetPreference = Tower.TargetPreference.Far;
                break;
            case 2:
                activeTower.targetPreference = Tower.TargetPreference.MoreHealh;
                break;
            case 3:
                activeTower.targetPreference = Tower.TargetPreference.LessHealth;
                break;
            case 4:
                activeTower.targetPreference = Tower.TargetPreference.MoreFast;
                break;
            case 5:
                activeTower.targetPreference = Tower.TargetPreference.LessFast;
                break;
            case 6:
                activeTower.targetPreference = Tower.TargetPreference.MoreDamage;
                break;
            case 7:
                activeTower.targetPreference = Tower.TargetPreference.LessDamage;
                break;
            case 8:
                activeTower.targetPreference = Tower.TargetPreference.SmallEnemies;
                break;
            case 9:
                activeTower.targetPreference = Tower.TargetPreference.MediumEnemies;
                break;
            case 10:
                activeTower.targetPreference = Tower.TargetPreference.Boss;
                break;
            case 11:
                activeTower.targetPreference = Tower.TargetPreference.FirstEnemy;
                break;
            case 12:
                activeTower.targetPreference = Tower.TargetPreference.LastEnemy;
                break;
        }

        preferencesBoard.SetActive(false);
    }

    public void ShowPreferenceInfo()
    {
        preferencesBoard.SetActive(true);
    }

    public void HidePreferenceInfo()
    {
        preferencesBoard.SetActive(false);
    }
}
