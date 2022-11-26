using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour
{
    public Image button;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    void Awake()
    {
        button = GetComponent<Image>();
    }

    public void Enter()
    {
        if (hoverSprite && normalSprite)
        {
            button.sprite = hoverSprite;
        }
        button.rectTransform.sizeDelta += new Vector2(25, 25);
    }
    public void Exit()
    {
        if (hoverSprite && normalSprite)
        {
            button.sprite = normalSprite;
        }
        button.rectTransform.sizeDelta -= new Vector2(25, 25);
    }
}
