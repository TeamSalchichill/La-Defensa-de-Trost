using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
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
    }

    public void SelectMainTower(int id)
    {
        generator.mainTower = mainTower[id];
        generator.miniMainTower = miniMainTower[id];
    }

    public void SelectTower(int id)
    {
        if (towersSelected.Contains(id))
        {
            towersSelected.Remove(id);
            numTowersSelected--;
        }
        else
        {
            if (numTowersSelected < 6)
            {
                towersSelected.Add(id);
                numTowersSelected++;
            }
        }
    }

    public void SelectHero(int id)
    {
        colocatorManager.towers[0] = hero[id];
    }

    public void StartGame()
    {
        for (int i = 1; i < 7; i++)
        {
            colocatorManager.towers[i] = tower[towersSelected[i - 1]];
        }

        gameManagerGO.SetActive(true);
        canvas.SetActive(true);
        cameraController.enabled = true;
        selectScreen.SetActive(false);
    }
}
