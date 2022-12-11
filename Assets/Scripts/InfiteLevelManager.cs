using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiteLevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public Generator generator;
    public CameraController cameraController;
    public GameFlow gameFlow;
    public ColocatorManager colocatorManager;
    [Space]
    public GameObject gameManagerGO;
    public GameObject canvas;
    public GameObject selectScreen;
    [Space]
    public List<GameObject> herosGO;
    public List<GameObject> zonesGO;
    public List<GameObject> mainTowersGO;
    public List<GameObject> towersGO;
    public Sprite interrogacion;
    [Space]
    public GameObject[] normalTerrain;
    public GameObject[] specialTerrain;
    public GameObject[] differentTerrain;
    public GameObject[] normalPath;
    public GameObject[] specialPath;
    public GameObject[] obstacle;
    public GameObject[] spawner;
    [Space]
    public GameObject[] mainTower;
    public GameObject[] miniMainTower;

    public GameObject perla;
    [Space]
    public GameObject[] tower;
    public List<int> towersSelected;
    public int numTowersSelected;
    [Space]
    public GameObject[] hero;

    [Header("Checks")]
    public bool zoneChoosed;
    public bool mainTowerChoosed;
    public bool towersChoosed;
    public bool heroChoosed;

    [Header("Buttons")]
    public Image[] zoneImages;
    public Image[] mainTowerImages;
    public Image[] towersImages;
    public Image[] herosImages;
    
    int lastIdZone = 0;
    int lastIdMainTower = 0;
    int lastIdHeros = 0;

    void Start()
    {
        herosGO.Reverse();
        zonesGO.Reverse();
        mainTowersGO.Reverse();
        towersGO.Reverse();

        for (int i = 0; i <  (6 - (gameManager.levelMaxPublic - 1)) * 3; i++)
        {
            towersGO[i].GetComponent<Image>().sprite = interrogacion;
            towersGO[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < (8 - gameManager.levelMaxPublic - 1); i++)
        {
            herosGO[i].GetComponent<Image>().sprite = interrogacion;
            herosGO[i].GetComponent<Button>().interactable = false;
            zonesGO[i].GetComponent<Image>().sprite = interrogacion;
            zonesGO[i].GetComponent<Button>().interactable = false;
            mainTowersGO[i].GetComponent<Image>().sprite = interrogacion;
            mainTowersGO[i].GetComponent<Button>().interactable = false;
        }





        gameFlow.enemiesPerRound1 = new int[1000];
        gameFlow.enemiesPerRound2 = new int[1000];
        gameFlow.enemiesPerRound3 = new int[1000];

        for (int i = 0; i < 1000; i++)
        {
            int enemiesMultiplier1 = 1;
            int enemiesMultiplier2 = 1;

            if (i < 20)
            {
                enemiesMultiplier1 = 2;
                enemiesMultiplier2 = 1;
            }
            else if (i < 40)
            {
                enemiesMultiplier1 = 5;
                enemiesMultiplier2 = 1;
            }
            else if (i < 60)
            {
                enemiesMultiplier1 = 10;
                enemiesMultiplier2 = 2;
            }
            else if (i < 80)
            {
                enemiesMultiplier1 = 25;
                enemiesMultiplier2 = 5;
            }
            else if (i < 100)
            {
                enemiesMultiplier1 = 35;
                enemiesMultiplier2 = 6;
            }
            else
            {
                enemiesMultiplier1 = 50;
                enemiesMultiplier2 = 5;
            }

            gameFlow.enemiesPerRound1[i] = (i * enemiesMultiplier1) + 1;
            gameFlow.enemiesPerRound2[i] = (i * enemiesMultiplier2) + 1;

            if (i % 10 == 0)
            {
                gameFlow.enemiesPerRound3[i] = i / 10;
            }
        }
    }

    public void SelectZone(int id)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        generator.grassBlock = normalTerrain[id];
        generator.specialGrassBlock = specialTerrain[id];
        generator.fireTile = differentTerrain[id];
        generator.groundBlock = normalPath[id];
        generator.specialGroundBlock = specialPath[id];
        generator.obstacleBlock = obstacle[id];
        generator.enemySpawn = spawner[id];

        perla.SetActive(false);

        switch (id)
        {
            case 0:
                generator.zone = Generator.Zone.Hielo;
                break;
            case 1:
                generator.zone = Generator.Zone.Desierto;
                break;
            case 2:
                generator.zone = Generator.Zone.Atlantis;
                perla.SetActive(true);
                break;
            case 3:
                generator.zone = Generator.Zone.Valhalla;
                break;
            case 4:
                generator.zone = Generator.Zone.Fantasia;
                break;
            case 5:
                generator.zone = Generator.Zone.Infierno;
                break;
        }

        zoneImages[lastIdZone].color = new Color(1, 1, 1, 1);
        if (zoneChoosed)
        {
            zoneImages[lastIdZone].rectTransform.sizeDelta += new Vector2(25, 25);
        }
        zoneImages[id].color = new Color(1, 1, 1, 0.5f);
        zoneImages[id].rectTransform.sizeDelta -= new Vector2(25, 25);
        lastIdZone = id;

        zoneChoosed = true;
    }

    public void SelectMainTower(int id)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        generator.mainTower = mainTower[id];
        generator.miniMainTower = miniMainTower[id];

        mainTowerImages[lastIdMainTower].color = new Color(1, 1, 1, 1);
        if (mainTowerChoosed)
        {
            mainTowerImages[lastIdMainTower].rectTransform.sizeDelta += new Vector2(25, 25);
        }
        mainTowerImages[id].color = new Color(1, 1, 1, 0.5f);
        mainTowerImages[id].rectTransform.sizeDelta -= new Vector2(25, 25);
        lastIdMainTower = id;

        mainTowerChoosed = true;
    }

    public void SelectTower(int id)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (towersSelected.Contains(id))
        {
            towersSelected.Remove(id);
            numTowersSelected--;
            towersImages[id].color = new Color(1, 1, 1, 1);
            towersImages[id].rectTransform.sizeDelta += new Vector2(25, 25);
        }
        else
        {
            if (numTowersSelected < 6)
            {
                towersSelected.Add(id);
                numTowersSelected++;
                towersImages[id].color = new Color(1, 1, 1, 0.5f);
                towersImages[id].rectTransform.sizeDelta -= new Vector2(25, 25);
            }
        }

        towersChoosed = numTowersSelected == 6;
    }

    public void SelectHero(int id)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        colocatorManager.towers[0] = hero[id];

        herosImages[lastIdHeros].color = new Color(1, 1, 1, 1);
        if (heroChoosed)
        {
            herosImages[lastIdHeros].rectTransform.sizeDelta += new Vector2(25, 25);
        }
        herosImages[id].color = new Color(1, 1, 1, 0.5f);
        herosImages[id].rectTransform.sizeDelta -= new Vector2(25, 25);
        lastIdHeros = id;

        heroChoosed = true;
    }

    public void StartGame()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (zoneChoosed && mainTowerChoosed && towersChoosed && heroChoosed)
        {
            for (int i = 1; i < 7; i++)
            {
                colocatorManager.towers[i] = tower[towersSelected[i - 1]];
            }

            gameManagerGO.SetActive(true);
            canvas.SetActive(true);
            cameraController.enabled = true;
            selectScreen.SetActive(false);

            canvas.GetComponent<HUD_Manager>().tutorialSpriteIdFinal = 3 + gameManager.levelMaxPublic;
        }
    }
}
