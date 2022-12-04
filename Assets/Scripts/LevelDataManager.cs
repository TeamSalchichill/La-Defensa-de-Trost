using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataManager : MonoBehaviour
{
    public Button[] levelsButtons;
    public Button[] levelsButtonsAux;

    void Start()
    {
        for (int i = 0; i <= GameManager.instance.levelMaxPublic - 1; i++)
        {
            if (i < levelsButtons.Length)
            {
                levelsButtons[i].interactable = true;
                levelsButtonsAux[i].interactable = true;
            }
        }
    }
}
