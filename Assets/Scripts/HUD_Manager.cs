using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_Manager : MonoBehaviour
{
    public static HUD_Manager instance;
    Generator generator;
    GameManager gameManager;
    CameraController cameraController;
    ColocatorManager colocatorManager;

    [Header("Sliders")]
    public Slider[] sliders = new Slider[5];
    [Space]
    public TextMeshProUGUI[] porcentajes = new TextMeshProUGUI[5];

    [Header("CanActivate")]
    public TextMeshProUGUI[] canActivate = new TextMeshProUGUI[3];

    [Header("Temporal messages")]
    public int coinsNumber;
    public TextMeshProUGUI coinsText;

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
    }

    void Update()
    {
        generator.probabilityStraight = (int)(sliders[0].value * 100);
        generator.probabilityNewWays = (int)(sliders[1].value * 100);
        generator.probabilityDeleteWay = (int)(sliders[2].value * 100);
        generator.probabilitySpecialTiles = (int)(sliders[3].value * 100);
        generator.probabilityObstacles = (int)(sliders[4].value * 100);

        porcentajes[0].text = ((int)(sliders[0].value * 100)).ToString() + "%";
        porcentajes[1].text = ((int)(sliders[1].value * 100)).ToString() + "%";
        porcentajes[2].text = ((int)(sliders[2].value * 100)).ToString() + "%";
        porcentajes[3].text = ((int)(sliders[3].value * 100)).ToString() + "%";
        porcentajes[4].text = ((int)(sliders[4].value * 100)).ToString() + "%";


        canActivate[0].text = "(P) Spawn: " + gameManager.doSpawnEnemies;
        canActivate[1].text = "(L) Lock Camera: " + cameraController.doMovement;
        canActivate[2].text = "(1/2) Build Tower: " + colocatorManager.canBuild;
    }

    public void AddCoins(int newCoins)
    {
        coinsNumber += newCoins;

        coinsText.text = "Coins: " + coinsNumber.ToString();
    }
}
