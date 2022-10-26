using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public enum TypeMapInfo { Tile }
    public TypeMapInfo mapInfo;

    GameFlow gameFlow;

    public int id = 1000000;
    public bool tileCambiado = false;
    public int numTilesEncontradas = 0;
    public int sumaTilesEncontradas = 0;

    void Start()
    {
        gameFlow = GameFlow.instance;

        Invoke("CheckID", 1);
    }

    void CheckID()
    {
        if (id == 1000000)
        {
            id = gameFlow.round;
            tileCambiado = true;
        }

        if (id == 1000000)
        {
            print("Algo no funciona");
        }
    }
}
