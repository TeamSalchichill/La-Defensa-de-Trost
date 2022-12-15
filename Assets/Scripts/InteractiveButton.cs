using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour
{
    public Image button;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    public GameObject infoImage;
    public int idTorre;
    public bool isHechizo;
    public Sprite infoHechizo;

    public bool infiniteLevelSelector;
    public bool block;

    void Awake()
    {
        button = GetComponent<Image>();
        
        if (infoImage && !infiniteLevelSelector)
        {
            infoImage.GetComponent<Image>().sprite = ColocatorManager.instance.towers[idTorre].GetComponent<Tower>().infoInGame;
        }
        if (isHechizo)
        {
            infoImage.GetComponent<Image>().sprite = infoHechizo;
        }
    }

    public void Enter()
    {
        if (!block)
        {
            if (infoImage)
            {
                infoImage.SetActive(true);
            }
            if (hoverSprite && normalSprite)
            {
                button.sprite = hoverSprite;
            }
            button.rectTransform.sizeDelta += new Vector2(25, 25);
        }
    }
    public void Exit()
    {
        if (!block)
        {
            if (infoImage)
            {
                infoImage.SetActive(false);
            }
            if (hoverSprite && normalSprite)
            {
                button.sprite = normalSprite;
            }
            button.rectTransform.sizeDelta -= new Vector2(25, 25);
        }
    }
}
