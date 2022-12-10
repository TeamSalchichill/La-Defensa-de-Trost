using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD_Button : MonoBehaviour
{
    public enum Link { LinkTree, itchio, Twitter, Youtube }

    public GameObject panel;

    [Header("Loading")]
    public GameObject loadingScreen;

    [Header("Button Fixs")]
    public Image backButtonImage;

    public void ChangeScene(int idScene)
    {
        loadingScreen.SetActive(true);

        SoundManager.instance.SoundSelection(3, 0.5f);

        SceneManager.LoadScene(idScene);
    }

    public void OpenURL(int idLink)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        switch (idLink)
        {
            case 0:
                Application.OpenURL("https://linktr.ee/teamsalchichill");
                break;
            case 1:
                Application.OpenURL("https://teamsalchichill.itch.io/la-defensa-de-trost");
                break;
            case 2:
                Application.OpenURL("https://twitter.com/TeamSalchichill?s=20");
                break;
            case 3:
                Application.OpenURL("https://www.youtube.com/channel/UCJ1A2R_n6q1AA3j-7plyBLg");
                break;
        }
    }

    public void ExitGame()
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        Application.Quit();
    }

    public void TutorialOptions(bool activate)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        panel.SetActive(activate);

        if (!activate)
        {
            backButtonImage.rectTransform.sizeDelta -= new Vector2(25, 25);
        }
    }

    public void StartLevel(int id)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        loadingScreen.SetActive(true);

        GameManager.instance.SelectLevel(id); 
    }
}
