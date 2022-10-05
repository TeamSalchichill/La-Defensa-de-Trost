using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    public static MainTower instance;

    HUD_Manager hudManager;

    public int health;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hudManager = HUD_Manager.instance;
    }

    void Update()
    {
        if (health <= 0)
        {
            hudManager.ResetGame();
        }
    }
}
