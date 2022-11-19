using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour
{
    public Image button;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    public void Enter()
    {
        button.sprite = hoverSprite;
    }
    public void Exit()
    {
        button.sprite = normalSprite;
    }
}
