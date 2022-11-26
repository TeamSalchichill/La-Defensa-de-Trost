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

    void Awake()
    {
        instance = this;

        volumeMultiplierPublic = volumeMultiplier;
        volumeMultiplierEffectsPublic = volumeMultiplierEffects;
    }
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            doSpawnEnemies = !doSpawnEnemies;
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
        */
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
}
