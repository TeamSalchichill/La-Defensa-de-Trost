using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_Button : MonoBehaviour
{
    public enum Link { LinkTree, itchio, Twitter, Youtube }

    public void ChangeScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    public void OpenURL(int idLink)
    {
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
        Application.Quit();
    }
}
