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
    [Space]
    public TextMeshProUGUI[] statsTexts;
    public TextMeshProUGUI[] effectsTexts;
    [Space]
    public Image coin;
    public Sprite[] coins;

    [Header("Tower Buttons")]
    public TextMeshProUGUI[] towersButton;
    public Image[] towersButtonIcon;

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
    public GameObject winScreen;

    [Header("Utility Buttons")]
    public GameObject towerPotionButton;
    public GameObject towerPotionIcon;
    public Color towerPotionButtonColorHover;
    public Color towerPotionIconColorHover;
    
    [Header("Particles")]
    public GameObject levelUpParticle;
    public GameObject levelUpSpecialParticle;

    [Header("Icons")]
    public Sprite[] enemyIcons;

    [Header("Cards")]
    public GameObject dadosBackGround;

    [Header("Tutorial")]
    public Image tutorialSprite;
    public int tutorialSpriteId;
    public Sprite[] tutorialImages;

    [Header("Hechizo")]
    public TextMeshProUGUI hechizoText;

    [Header("Intro images")]
    public Image activeImage;
    public Sprite[] images;
    int imageId = 1;

    public GameObject panel;

    [Header("End images")]
    public Image activeImageEnd;
    public Sprite[] imagesEnd;
    int imageIdEnd = 1;

    public GameObject panelEnd;


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
            //towersButton[i].text = colocatorManager.towers[i].GetComponent<Tower>().towerName + "\n" + "(" + colocatorManager.towers[i].GetComponent<Tower>().price + "€)";
            towersButton[i].text = "" + colocatorManager.towers[i].GetComponent<Tower>().price;
            towersButtonIcon[i].sprite = colocatorManager.towers[i].GetComponent<Tower>().icon;
        }

        dadosBackGround.SetActive(false);
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

            statsTexts[0].text = activeTower.healthDamage.ToString("F1");
            statsTexts[1].text = activeTower.health.ToString("F1");
            statsTexts[2].text = activeTower.range.ToString("F1");
            statsTexts[3].text = activeTower.fireRate.ToString("F1");

            effectsTexts[0].text = activeTower.iceDamage.ToString("F1");
            effectsTexts[1].text = activeTower.igniteDamage.ToString("F1");
            effectsTexts[2].text = activeTower.waterDamage.ToString("F1");
            effectsTexts[3].text = activeTower.ascentDamage.ToString("F1");
            effectsTexts[4].text = activeTower.bloodDamage.ToString("F1");
            effectsTexts[5].text = activeTower.transformationDamage.ToString("F1");

            if (activeTower.level < 4)
            {
                coin.sprite = coins[0];
            }
            else
            {
                coin.sprite = coins[1];
            }



            /*
            towerDescription1.text =
            " ---- STATS ----\n" +
            "Daño: " + activeTower.healthDamage.ToString("F1") + "\n" +
            "Rango: " + activeTower.range.ToString("F1") + "\n" +
            "Vel. disparo: " + activeTower.fireRate.ToString("F1") + "\n" +
            "Vida: " + activeTower.health.ToString("F1") + "\n"
            //"Velocidad de giro: " + activeTower.turnSpeed + "\n" +
            ;
            towerDescription2.text =
            "-- EFFECTS --\n" +
            "Hielo: " + activeTower.iceDamage.ToString("F1") + "%" + "\n" +
            "Fuego: " + activeTower.igniteDamage.ToString("F1") + "%" + "\n" +
            "Agua: " + activeTower.waterDamage.ToString("F1") + "%" + "\n" +
            "Ascensión: " + activeTower.ascentDamage.ToString("F1") + "%" + "\n" +
            "Sangrado: " + activeTower.bloodDamage.ToString("F1") + "%" + "\n" +
            "Locura: " + activeTower.transformationDamage.ToString("F1") + "%" + "\n"
            ;
            */
            if (activeTower.level == 5)
            {
                levelUpButton.text = "Max";
                //levelUpButton.gameObject.SetActive(false);
            }
            else
            {
                levelUpButton.text = "" + activeTower.levelUpPrice;
                //levelUpButton.gameObject.SetActive(true);
            }

            float actualHealth = activeTower.health;
            float actualHealthMax = activeTower.healthMax;

            float healthPercent = actualHealth / actualHealthMax;

            //levelUpButton.text = "" + activeTower.levelUpPrice;
            sellButton.text = "" + (int)(activeTower.acumulateGold * 0.7f * healthPercent);
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
        /*
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
        */
    }

    public void AddCoins(int newCoins)
    {
        gameFlow.coins += newCoins;
    }

    public void ResetGame()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

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
        SoundManager.instance.SoundSelection(3, 0.5f);

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
            SoundManager.instance.SoundSelection(17, 1);

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
            SoundManager.instance.SoundSelection(6, 1);

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
        SoundManager.instance.SoundSelection(3, 0.5f);

        SceneManager.LoadScene(id);
    }

    public void ChangeSpeed(int speed)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);
        //BackgroundMusic.instance.ChangeClip();

        Time.timeScale = speed;
    }

    public void StartRoundButtom()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

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
        SoundManager.instance.SoundSelection(3, 0.5f);

        showTowerBanner = !showTowerBanner;
    }

    public void ActivateGameOver()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        gameOverScreen.SetActive(true);
    }

    public void ActivatePotion()
    {
        if (mainTower.restRounds <= 0)
        {
            SoundManager.instance.SoundSelection(3, 0.5f);

            mainTower.activateTower = true;
        }
    }

    public void Zoom(int zoom)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        cameraController.Zoom(zoom, Camera.main.orthographicSize);
    }

    public void ExitInfo()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        isShowInfo = false;

        activeTower.rangeArea.SetActive(false);

        fichaTecnica.SetActive(false);

        preferencesBoard.SetActive(false);
    }

    public void ChangeEnemyPreference(int newPreference)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

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
        SoundManager.instance.SoundSelection(3, 0.5f);

        preferencesBoard.SetActive(true);
    }

    public void HidePreferenceInfo()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        preferencesBoard.SetActive(false);
    }

    public void ChangeTutorial(bool dir)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (dir)
        {
            tutorialSpriteId++;

            if (tutorialSpriteId > tutorialImages.Length - 1)
            {
                tutorialSpriteId = 0;
            }
        }
        else
        {
            tutorialSpriteId--;

            if (tutorialSpriteId < 0)
            {
                tutorialSpriteId = tutorialImages.Length - 1;
            }
        }

        tutorialSprite.sprite = tutorialImages[tutorialSpriteId];
    }

    public void TurnCamera(bool dir)
    {
        RaycastHit HitInfo;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f);

        if (dir)
        {
            cameraController.gameObject.transform.RotateAround(HitInfo.point, Vector3.up, 45);
        }
        else
        {
            cameraController.gameObject.transform.RotateAround(HitInfo.point, -Vector3.up, 45);
        }
    }

    public void NewImage(bool moment)
    {
        if (!moment)
        {
            if (imageId < images.Length)
            {
                activeImage.sprite = images[imageId];
                imageId++;
            }
            else if (imageId == images.Length)
            {
                gameFlow.canExpand = true;
                panel.SetActive(false);
            }
        }
        else
        {
            if (imageIdEnd < imagesEnd.Length)
            {
                activeImageEnd.sprite = imagesEnd[imageIdEnd];
                imageIdEnd++;
            }
            else if (imageIdEnd == imagesEnd.Length)
            {
                winScreen.SetActive(true);
            }
        }
    }
}
