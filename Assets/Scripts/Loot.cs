using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    HUD_Manager hudManager;

    public int coins;

    void Start()
    {
        hudManager = HUD_Manager.instance;

        coins = Random.Range(200, 701);
    }

    private void OnMouseUpAsButton()
    {
        hudManager.AddCoins(coins);

        Destroy(gameObject, 0.25f);
    }
}
