using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataManager : MonoBehaviour
{
    public Button[] levelsButtons;
    public GameObject[] levelsShadows;
    [Space]
    public GameObject vineta;
    public GameObject[] videos;
    [Space]
    public TextMeshProUGUI frase;
    public string[] frases;

    void Start()
    {
        frase.text = frases[Random.Range(0, frases.Length)];

        int maxLevel = Mathf.Min(GameManager.instance.levelMaxPublic, levelsButtons.Length - 1);

        for (int i = 0; i <= maxLevel; i++)
        {
            levelsButtons[i].interactable = true;
            levelsShadows[i].SetActive(false);
        }
        if (GameManager.instance.levelMaxPublic > 3)
        {
            levelsButtons[7].interactable = true;
            levelsShadows[7].SetActive(false);
        }
    }

    public void ChangeVideo(int id)
    {
        vineta.SetActive(true);

        foreach (var video in videos)
        {
            video.SetActive(false);
        }

        videos[id].SetActive(true);
    }
    public void DisablesVideos()
    {
        vineta.SetActive(false);

        foreach (var video in videos)
        {
            video.SetActive(false);
        }
    }
}
