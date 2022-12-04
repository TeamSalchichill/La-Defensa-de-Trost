using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public Generator generator;
    public GameFlow gameFlow;
    public ColocatorManager colocatorManager;
    public HUD_Manager hudManager;
    [Space]
    public GameObject gameManagerGO;
    public GameObject canvas;
    [Space]
    public GameObject[] normalTerrain;
    public GameObject[] specialTerrain;
    public GameObject[] differentTerrain;
    public GameObject[] normalPath;
    public GameObject[] specialPath;
    public GameObject[] obstacle;
    public GameObject[] spawner;
    public GameObject[] treasure;
    [Space]
    public GameObject[] mainTower;
    public GameObject[] miniMainTower;

    public GameObject perla;
    [Space]
    public GameObject[] tower;
    public GameObject[] enemy;
    [Space]
    public GameObject[] hero;

    void Start()
    {
        int id = GameManager.instance.levelSelectedPublic;
        id--;

        generator.grassBlock = normalTerrain[id];
        generator.specialGrassBlock = specialTerrain[id];
        generator.fireTile = differentTerrain[id];
        generator.groundBlock = normalPath[id];
        generator.specialGroundBlock = specialPath[id];
        generator.obstacleBlock = obstacle[id];
        generator.enemySpawn = spawner[id];
        generator.treasure = treasure[id];

        perla.SetActive(false);

        Color backgroundColor;
        ColorUtility.TryParseHtmlString("#383838", out backgroundColor);
        string bacgroundColorString = "#383838";

        switch (id)
        {
            case 0:
                generator.zone = Generator.Zone.Hielo;
                hudManager.imageId = 1;
                hudManager.imageIdFinal = 10;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 0;
                hudManager.tutorialSpriteIdFinal = 4;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#383E61";
                break;
            case 1:
                generator.zone = Generator.Zone.Desierto;
                hudManager.imageId = 11;
                hudManager.imageIdFinal = 15;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 4;
                hudManager.tutorialSpriteIdFinal = 8;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#615638";
                break;
            case 2:
                generator.zone = Generator.Zone.Atlantis;
                hudManager.imageId = 16;
                hudManager.imageIdFinal = 20;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 8;
                hudManager.tutorialSpriteIdFinal = 12;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#385861";
                perla.SetActive(true);
                break;
            case 3:
                generator.zone = Generator.Zone.Valhalla;
                hudManager.imageId = 21;
                hudManager.imageIdFinal = 25;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 12;
                hudManager.tutorialSpriteIdFinal = 16;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#7A8282";
                break;
            case 4:
                generator.zone = Generator.Zone.Fantasia;
                hudManager.imageId = 26;
                hudManager.imageIdFinal = 30;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 16;
                hudManager.tutorialSpriteIdFinal = 20;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#4C824B";
                break;
            case 5:
                generator.zone = Generator.Zone.Infierno;
                hudManager.imageId = 31;
                hudManager.imageIdFinal = 36;
                hudManager.activeImage.sprite = hudManager.images[hudManager.imageId - 1];

                hudManager.tutorialSpriteId = 20;
                hudManager.tutorialSpriteIdFinal = 24;
                hudManager.tutorialSprite.sprite = hudManager.tutorialImages[hudManager.tutorialSpriteId];

                bacgroundColorString = "#442424";
                break;
        }

        ColorUtility.TryParseHtmlString(bacgroundColorString, out backgroundColor);
        Camera.main.backgroundColor = backgroundColor;

        generator.mainTower = mainTower[id];
        generator.miniMainTower = miniMainTower[id];

        colocatorManager.towers[0] = hero[id];

        int idAuxTower = id * 3;
        colocatorManager.towers[1] = tower[idAuxTower + 0];
        colocatorManager.towers[2] = tower[idAuxTower + 1];
        colocatorManager.towers[3] = tower[idAuxTower + 2];
        
        int idAuxEnemy = id * 6;
        gameFlow.enemies[0] = enemy[idAuxEnemy + 0];
        gameFlow.enemies[1] = enemy[idAuxEnemy + 1];
        gameFlow.enemies[2] = enemy[idAuxEnemy + 2];
        gameFlow.enemies[3] = enemy[idAuxEnemy + 3];
        gameFlow.enemies[4] = enemy[idAuxEnemy + 4];
        gameFlow.enemies[5] = enemy[idAuxEnemy + 5];
        
        gameManagerGO.SetActive(true);
        canvas.SetActive(true);
    }
}
