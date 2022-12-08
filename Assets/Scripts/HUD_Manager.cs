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
    public Image[] squareImages;
    public Sprite squarePath;
    public Sprite squareTerrain;

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
    public Button winScreenButton;
    public GameObject endScreen;
    public GameObject checkExit;
    public GameObject checkReset;

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
    public Sprite[] dicesImages;
    public Image dicesImage;
    public TextMeshProUGUI dicesText;

    [Header("Tutorial")]
    public Image tutorialSprite;
    public int tutorialSpriteId;
    public int tutorialSpriteIdFinal;
    public Sprite[] tutorialImages;

    [Header("Hechizo")]
    public TextMeshProUGUI hechizoText;

    [Header("Intro images")]
    public Image activeImage;
    public Sprite[] images;
    public int imageId = 1;
    public int imageIdFinal = 1;

    public GameObject panel;

    [Header("End images")]
    public Image activeImageEnd;
    public Sprite[] imagesEnd;
    int imageIdEnd = 1;

    public GameObject panelEnd;

    [Header("Loading")]
    public GameObject loadingScreen;

    [Header("Summary")]
    public TextMeshProUGUI summaryTextDead;
    public TextMeshProUGUI summaryTextWin;

    [Header("Move")]
    public GameObject moveTowerButton;
    public GameObject moveHeroButton;

    [Header("Speed")]
    public Image speedImage;
    public Sprite speed1;
    public Sprite speed2;
    int actualSpeed = 1;

    [Header("Button Fixs")]
    public Image sellButtonImage;
    public Image closeButtonImage;
    public Image close2ButtonImage;
    public Image moveTowerButtonImage;
    public Image moveHeroButtonImage;
    public Image exitButtonImage;
    public Image resetButtonImage;
    public Image playButton;

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
            /*
            if (colocatorManager.towers[i].GetComponent<Tower>().canColocate == Tower.CanColocate.Path)
            {
                squareImages[i].sprite = squarePath;
            }
            else
            {
                squareImages[i].sprite = squareTerrain;
            }
            */
        }

        dadosBackGround.SetActive(false);
        /*
        generator.probabilityStraight = (int)(sliders[0].value * 100);
        generator.probabilityNewWays = (int)(sliders[1].value * 100);
        generator.probabilityDeleteWay = (int)(sliders[2].value * 100);
        generator.probabilitySpecialTiles = (int)(sliders[3].value * 100);
        generator.probabilityObstacles = (int)(sliders[4].value * 100);
        generator.probabilityConectWays = (int)(sliders[5].value * 100);
        */
    }

    void Update()
    {
        if (activeTower == null)
        {
            fichaTecnica.SetActive(false);
        }

        if (generator.zone == Generator.Zone.Valhalla)
        {
            generator.probabilitySpecialTiles = 4;
        }
        if (generator.zone == Generator.Zone.Fantasia)
        {
            generator.probabilitySpecialTiles = 10;
        }

        porcentajes[0].text = ((int)(sliders[0].value * 100)).ToString() + "%";
        porcentajes[1].text = ((int)(sliders[1].value * 100)).ToString() + "%";
        porcentajes[2].text = ((int)(sliders[2].value * 100)).ToString() + "%";
        porcentajes[3].text = ((int)(sliders[3].value * 100)).ToString() + "%";
        porcentajes[4].text = ((int)(sliders[4].value * 100)).ToString() + "%";
        porcentajes[5].text = ((int)(sliders[5].value * 100)).ToString() + "%";

        coinsText.text = gameFlow.coins.ToString();
        specialCoinsText.text = gameFlow.specialCoins.ToString();
        roundText.text = "Ronda: " + gameFlow.round.ToString() + "/" + gameFlow.totalRounds.ToString();
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

            statsTexts[0].text = activeTower.healthDamage.ToString("F0");
            statsTexts[1].text = activeTower.health.ToString("F0");
            statsTexts[2].text = activeTower.range.ToString("F0");
            statsTexts[3].text = activeTower.fireRate.ToString("F1");

            effectsTexts[0].text = activeTower.iceDamage.ToString("F0");
            effectsTexts[1].text = activeTower.igniteDamage.ToString("F0");
            effectsTexts[2].text = activeTower.waterDamage.ToString("F0");
            if (activeTower.isAscent)
            {
                effectsTexts[3].text = "SÍ";
            }
            else
            {
                effectsTexts[3].text = "NO";
            }
            
            effectsTexts[4].text = activeTower.bloodDamage.ToString("F0");
            effectsTexts[5].text = activeTower.transformationDamage.ToString("F0");

            if (activeTower.level < 4)
            {
                coin.sprite = coins[0];
            }
            else
            {
                coin.sprite = coins[1];
            }

            if (activeTower.level == 5)
            {
                levelUpButton.text = "Max";
            }
            else
            {
                levelUpButton.text = "" + activeTower.levelUpPrice;
            }

            float actualHealth = activeTower.health;
            float actualHealthMax = activeTower.healthMax;

            float healthPercent = actualHealth / actualHealthMax;

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
    }

    public void AddCoins(int newCoins)
    {
        gameFlow.coins += newCoins;
    }

    public void ResetGame()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (checkExit)
        {
            checkReset.SetActive(false);
        }

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
        
        colocatorManager.towerID = id;
        colocatorManager.canBuild = true;

        colocatorManager.canDisableColocatotMode = 1;

        cameraController.CameraCanMove();
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

        moveTowerButton.SetActive(activeTower.level == 5 && !activeTower.isHero && activeTower.GetComponent<RecolocateManual>().nextRound);
        moveHeroButton.SetActive(activeTower.isHero && activeTower.GetComponent<Hero>().nextRound);

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
                gameFlow.goldSpent += activeTower.levelUpPrice;
            }
            else
            {
                //activeTower.level5Update.SetActive(true);
                if (activeTower.level5Updates.Length > 0)
                {
                    foreach (GameObject update in activeTower.level5Updates)
                    {
                        update.SetActive(true);
                    }
                }

                GameObject instParticle = Instantiate(levelUpSpecialParticle, activeTower.transform.position, transform.rotation);
                instParticle.transform.rotation = Quaternion.AngleAxis(270, Vector3.right);
                Destroy(instParticle, 3);
                
                gameFlow.specialCoins -= activeTower.levelUpPrice;
                gameFlow.specialGoldSpent += activeTower.levelUpPrice;

                activeTower.gameObject.AddComponent<RecolocateManual>();
                if (!activeTower.isHero)
                {
                    moveTowerButton.SetActive(true);
                }
            }
            
            activeTower.level++;
            activeTower.acumulateGold += activeTower.levelUpPrice;

            if (activeTower.level < 4)
            {
                activeTower.levelUpPrice = (int)(activeTower.levelUpPrice * 1.2f);
            }
            else
            {
                activeTower.levelUpPrice = activeTower.level5Price;
                activeTower.priceLogo = "$";
            }


            activeTower.numTargets++;
            activeTower.healthMax = (int)(activeTower.healthMax + activeTower.healthMax * 0.2f);
            activeTower.health = (int)(activeTower.health + activeTower.health * 0.2f);
            activeTower.range = (activeTower.range + activeTower.range * 0.1f);
            activeTower.fireRate = (activeTower.fireRate + activeTower.fireRate * 0.2f);

            activeTower.healthDamage = (int)(activeTower.healthDamage + activeTower.healthDamage * 0.2f);
            if (activeTower.iceDamage > 0)
            {
                activeTower.iceDamage++;
            }
            if (activeTower.igniteDamage > 0)
            {
                activeTower.igniteDamage++;
            }
            if (activeTower.waterDamage > 0)
            {
                activeTower.waterDamage++;
            }
            if (activeTower.ascentDamage > 0)
            {
                activeTower.ascentDamage++;
            }
            if (activeTower.bloodDamage > 0)
            {
                activeTower.bloodDamage++;
            }
            if (activeTower.transformationDamage > 0)
            {
                activeTower.transformationDamage++;
            }

            activeTower.rangeArea.transform.localScale = new Vector3(activeTower.range * activeTower.rangeAreaOriginalScale, activeTower.rangeAreaOriginalScale, activeTower.range * activeTower.rangeAreaOriginalScale);

            switch (activeTower.specialStat)
            {
                case Tower.SpecialStat.Health:
                    activeTower.health = (int)(activeTower.health + activeTower.health * 0.2f);
                    activeTower.healthMax = (int)(activeTower.healthMax + activeTower.healthMax * 0.2f);
                    break;
                case Tower.SpecialStat.Range:
                    activeTower.range = (activeTower.range + activeTower.range * 0.15f);
                    break;
                case Tower.SpecialStat.ShootSpeed:
                    activeTower.fireRate = (activeTower.fireRate + activeTower.fireRate * 0.3f);
                    break;
                case Tower.SpecialStat.HealthDamage:
                    activeTower.healthDamage = (int)(activeTower.healthDamage + activeTower.healthDamage * 0.3f);
                    break;
                case Tower.SpecialStat.IceEffect:
                    activeTower.iceDamage += 2;
                    break;
                case Tower.SpecialStat.IgniteEffect:
                    activeTower.igniteDamage += 2;
                    break;
                case Tower.SpecialStat.WaterEffect:
                    activeTower.waterDamage += 2;
                    break;
                case Tower.SpecialStat.AscensionEffect:
                    activeTower.ascentDamage += 2;
                    break;
                case Tower.SpecialStat.BloodEffect:
                    activeTower.bloodDamage += 2;
                    break;
                case Tower.SpecialStat.CrazyEffect:
                    activeTower.transformationDamage += 2;
                    break;
            }
            /*
            if (activeTower.level == 5)
            {
                activeTower.level5Light.enabled = true;
            }
            */
        }
    }
    public void SellTower()
    {
        if (!activeTower.isHero)
        {
            SoundManager.instance.SoundSelection(6, 1);

            sellButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);

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
        loadingScreen.SetActive(true);

        SoundManager.instance.SoundSelection(3, 0.5f);

        SceneManager.LoadScene(id);
    }

    public void ChangeSpeed()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);
        //BackgroundMusic.instance.ChangeClip();

        switch (actualSpeed)
        {
            case 1:
                speedImage.sprite = speed2;
                Time.timeScale = 2;
                actualSpeed = 2;
                break;
            case 2:
                speedImage.sprite = speed1;
                Time.timeScale = 1;
                actualSpeed = 1;
                break;
        }
    }

    public void PauseGame(int iter)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (iter == 1)
        {
            playButton.rectTransform.sizeDelta -= new Vector2(25, 25);
        }

        Time.timeScale = iter;
    }

    public void StartRoundButtom()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (Hero.instance != null)
        {
            Hero.instance.nextRound = true;
            Hero.instance.GetComponentInParent<Tower>().health = Hero.instance.GetComponentInParent<Tower>().health;
        }
        foreach (var tower in gameFlow.towers)
        {
            if (tower)
            {
                if (tower.GetComponent<RecolocateManual>())
                {
                    tower.GetComponent<RecolocateManual>().nextRound = true;
                }
            }
        }

        nextRoundButton.gameObject.GetComponent<Image>().rectTransform.sizeDelta -= new Vector2(25, 25);

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

        if (checkExit)
        {
            checkExit.SetActive(false);
        }

        int minutes = (int)gameFlow.time / 60;
        int seconds = (int)gameFlow.time % 60;

        summaryTextDead.text =
            //"Tiempo: " + (int)gameFlow.time + " segundos" + "\n" +
            "Tiempo: " + minutes + ":" + seconds + "\n" +
            "Ronda: " + gameFlow.round + "\n" +
            "Muertes enemigos enanos: " + gameFlow.kills1 + "\n" +
            "Muertes enemigos medianos: " + gameFlow.kills2 + "\n" +
            "Muertes enemigos bosses: " + gameFlow.kills3 + "\n" +
            "Torres construidas: " + gameFlow.towersBuild + "\n" +
            "Torres destruidas: " + gameFlow.towersDestroyed + "\n" +
            "Monedas gastadas: " + gameFlow.goldSpent + "\n" +
            "Cristales gastadas: " + gameFlow.specialGoldSpent + "\n" +
            "Mini objetivos destruidos: " + gameFlow.miniObjetivesDestroyed + "\n"
            ;

        gameOverScreen.SetActive(true);
    }

    public void ActivatePotion()
    {
        if (mainTower.restRounds <= 0)
        {
            SoundManager.instance.SoundSelection(3, 0.5f);
            
            MainTower.instance.activateTower = !MainTower.instance.activateTower;
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

        closeButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);

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

        close2ButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);

        preferencesBoard.SetActive(false);
    }

    public void ChangeTutorial(bool dir)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (dir)
        {
            tutorialSpriteId++;

            if (tutorialSpriteId > tutorialSpriteIdFinal - 1)
            {
                tutorialSpriteId = tutorialSpriteIdFinal - 4;
            }
        }
        else
        {
            tutorialSpriteId--;

            if (tutorialSpriteId < tutorialSpriteIdFinal - 4)
            {
                tutorialSpriteId = tutorialSpriteIdFinal - 1;
            }
        }

        tutorialSprite.sprite = tutorialImages[tutorialSpriteId];
    }

    public void TurnCamera(bool dir)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

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
            if (imageId < imageIdFinal)
            {
                activeImage.sprite = images[imageId];
                imageId++;
            }
            else if (imageId == imageIdFinal)
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
                int minutes = (int)gameFlow.time / 60;
                int seconds = (int)gameFlow.time % 60;

                summaryTextWin.text =
                    //"Tiempo: " + (int)gameFlow.time + " segundos" + "\n" +
                    "Tiempo: " + minutes + ":" + seconds + "\n" +
                    "Ronda: " + gameFlow.round + "\n" +
                    "Muertes enemigos enanos: " + gameFlow.kills1 + "\n" +
                    "Muertes enemigos medianos: " + gameFlow.kills2 + "\n" +
                    "Muertes enemigos bosses: " + gameFlow.kills3 + "\n" +
                    "Torres construidas: " + gameFlow.towersBuild + "\n" +
                    "Torres destruidas: " + gameFlow.towersDestroyed + "\n" +
                    "Monedas gastadas: " + gameFlow.goldSpent + "\n" +
                    "Cristales gastadas: " + gameFlow.specialGoldSpent + "\n" +
                    "Mini objetivos destruidos: " + gameFlow.miniObjetivesDestroyed + "\n"
                    ;

                winScreen.SetActive(true);
                CanExitInvoke();
            }
        }
    }

    public void CanExitInvoke()
    {
        Invoke("CanExit", 5);
    }
    void CanExit()
    {
        winScreenButton.interactable = true;
    }

    public void SkipImages()
    {
        activeImage.sprite = images[imageId - 1];
        imageId = images.Length;
        gameFlow.canExpand = true;
        panel.SetActive(false);
    }

    public void CheckExit()
    {
        checkExit.SetActive(true);
    }
    public void DisableCheckExit()
    {
        exitButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);
        checkExit.SetActive(false);
    }
    public void CheckReset()
    {
        checkReset.SetActive(true);
    }
    public void DisableCheckReset()
    {
        resetButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);
        checkReset.SetActive(false);
    }

    public void StartLevel(int id)
    {
        gameManager.levelSelectedPublic = id;

        SceneManager.LoadScene(3);
    }

    public void MoveTower()
    {
        moveTowerButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);

        moveTowerButton.SetActive(false);
        activeTower.gameObject.GetComponent<RecolocateManual>().CanRealocateAux();
    }
    public void MoveHero()
    {
        moveHeroButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);

        moveHeroButton.SetActive(false);
        Hero.instance.gameObject.GetComponent<Hero>().CanRealocateAux();
    }
}
