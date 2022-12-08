using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool doSpawnEnemies = false;
    public bool isInfiniteLevel;

    public static float volumeMultiplier = 1;
    public float volumeMultiplierPublic = 1;
    public Slider sliderVolumeMusic;
    public AudioSource musicAS;
    public AudioSource musicASAux;

    public static float volumeMultiplierEffects = 1;
    public float volumeMultiplierEffectsPublic = 1;
    public Slider sliderVolumeMusicEffects;
    public AudioSource effectsAS;

    public static int levelSelected = 1;
    public int levelSelectedPublic = 1;

    public static int levelMax = 1;
    public int levelMaxPublic = 1;

    public static bool firstTime = true;
    public bool firstTimePublic = true;
    public GameObject loginScreen;

    public static bool invitate;
    public bool invitatePublic;

    void Awake()
    {
        instance = this;

        volumeMultiplierPublic = volumeMultiplier;
        volumeMultiplierEffectsPublic = volumeMultiplierEffects;

        levelSelectedPublic = levelSelected;
        levelMaxPublic = levelMax;

        invitatePublic = invitate;
    }

    void Start()
    {
        if (loginScreen)
        {
            loginScreen.SetActive(firstTime);
        }

        Application.targetFrameRate = 30;

        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().name == "Options")
        {
            sliderVolumeMusic.value = volumeMultiplier;
            sliderVolumeMusicEffects.value = volumeMultiplierEffects;
        }
    }

    void Update()
    {
        volumeMultiplierPublic = volumeMultiplier;
        volumeMultiplierEffectsPublic = volumeMultiplierEffects;
    }

    public void ChangeVolumeMusic()
    {
        volumeMultiplier = sliderVolumeMusic.value;
        musicAS.volume = volumeMultiplier / 2;

        if (musicASAux)
        {
            musicASAux.volume = volumeMultiplier / 2;
        }
        BackgroundMusic.instance.defaultVolume = volumeMultiplier / 2;
    }
    public void ChangeEffectsMusic()
    {
        volumeMultiplierEffects = sliderVolumeMusicEffects.value;
        effectsAS.volume = volumeMultiplierEffects / 2;
    }

    public void SelectLevel(int id)
    {
        levelSelected = id;
        levelSelectedPublic = id;

        SceneManager.LoadScene(5);
    }

    public void UpdateMaxLevel(int newMaxLevel)
    {
        levelMax = newMaxLevel;
        levelMaxPublic = newMaxLevel;
    }
    public void UpdateFirstTime()
    {
        firstTime = false;
        firstTimePublic = false;
    }
    public void UpdateInvitate()
    {
        invitate = true;
        invitatePublic = true;
    }
}
