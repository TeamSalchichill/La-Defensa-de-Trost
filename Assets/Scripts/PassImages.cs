using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassImages : MonoBehaviour
{
    public Image tutorialSprite;
    public int tutorialSpriteId;
    public Sprite[] tutorialImages;

    public void ChangeTutorial(bool dir)
    {
        SoundManager.instance.SoundSelection(3, 0.5f);

        if (dir)
        {
            tutorialSpriteId++;

            if (tutorialSpriteId > tutorialImages.Length - 1)
            {
                tutorialSpriteId = 0;
            }
        }
        else
        {
            tutorialSpriteId--;

            if (tutorialSpriteId < 0)
            {
                tutorialSpriteId = tutorialImages.Length - 1;
            }
        }

        tutorialSprite.sprite = tutorialImages[tutorialSpriteId];
    }
}
