using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // North = 0
    // East = 1
    // South = 2
    // West = 3

    // -2: Obstaculo
    // -1: Camino
    // 0: None
    // 1: Cesped nivel 1
    // 2: Cesped nivel 2
    // 3: Cesped nivel 3

    public static Generator instance;

    GameFlow gameFlow;
    MainTower mainTowerScript;

    public enum Zone { Hielo, Desierto, Atlantis, Valhalla, Fantasia, Infierno }
    public Zone zone;

    public bool activateRounds;
    public int expandRate = 1;

    [Header("Map")]
    public int sizeX;
    public int sizeY;
    public int sizeZ;

    [Header("Prefabs Tiles")]
    public GameObject grassBlock;
    public GameObject specialGrassBlock;
    public GameObject groundBlock;
    public GameObject specialGroundBlock;
    [Header("Prefabs Towers")]
    public GameObject mainTower;
    public GameObject miniMainTower;
    public GameObject tower;
    public bool miniMainTowerColocate = false;
    [Header("Prefabs Map")]
    public GameObject nextMap;
    [Space]
    public GameObject enemySpawn;
    public GameObject transparentEnemySpawn;
    public GameObject treasure;
    [Space]
    public GameObject obstacleBlock;
    public GameObject fireTile;

    [Header("Prefabs Aux")]
    public GameObject auxBlock;
    public GameObject navRemover;
    public GameObject blockNavRemover;

    [Header("Map Generations Variables")]
    int[,] map;

    int idX;
    int idZ;

    int startSide;
    string startSideOrientation;
    int nextSide;
    string nextSideOrientation;

    public Vector3 offsetStart;
    public Vector2 mapPos;

    public List<Vector2> colocatedMap = new List<Vector2>();
    public List<Vector3> openMap = new List<Vector3>();
    public List<GameObject> navRemovers = new List<GameObject>();
    public List<GameObject> newMapNodes = new List<GameObject>();

    public int numNewMapNodes = 1;
    public int numNewMapNodesLimit = 1;
    public int repiteNewMapNode = 0;

    [Header("Probabilities")]
    [Range(0, 100)]
    public int probabilityStraight = 50;
    [Range(0, 100)]
    public int probabilityNewWays = 50;
    [Range(0, 100)]
    public int probabilityDeleteWay = 50;
    [Range(0, 100)]
    public int probabilitySpecialTiles = 50;
    [Range(0, 100)]
    public int probabilityObstacles = 50;
    [Range(0, 100)]
    public int probabilityConectWays = 50;
    [Range(0, 100)]
    public int probabilityFireTile = 50;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameFlow = GameFlow.instance;

        InicializeMap();
    }

    void InicializeMap()
    {
        map = new int[sizeX, sizeZ];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                map[i, j] = 0;
            }
        }

        for (int i = -20; i <= 20; i++)
        {
            for (int j = -20; j <= 20; j++)
            {
                Vector3 pos = (new Vector3(i, 0, j) * 14) + new Vector3(7, 0.75f, 7);

                if (pos != new Vector3(0, 0, 0) + new Vector3(7, 0.75f, 7))
                {
                    GameObject NR = Instantiate(navRemover, pos, Quaternion.identity);
                    navRemovers.Add(NR);
                }
            }
        }

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                //Instantiate(groundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1), Quaternion.identity);

                if (!((i == sizeX - 1 || i == sizeX - 2 || i == sizeX - 3) && j == 3))
                {
                    Instantiate(grassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 0.75f, 1), Quaternion.identity);
                }
                else
                {
                    GameObject instTile = Instantiate(groundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1), Quaternion.identity);
                    instTile.GetComponent<MapInfo>().id = -1;
                }
            }
        }

        Instantiate(mainTower, new Vector3(7, 4, 7), Quaternion.identity);
        
        colocatedMap.Add(mapPos);
        openMap.Add(Vector3.zero);

        colocatedMap.Add(new Vector3(0, 1, 0));
        openMap.Add(new Vector3(0, 1, 0));
        colocatedMap.Add(new Vector3(0, 2, 0));
        openMap.Add(new Vector3(0, 2, 0));
        colocatedMap.Add(new Vector3(1, 1, 0));
        openMap.Add(new Vector3(1, 1, 0));
        colocatedMap.Add(new Vector3(-1, 2, 0));
        openMap.Add(new Vector3(-1, 2, 0));
        colocatedMap.Add(new Vector3(2, 1, 0));
        openMap.Add(new Vector3(2, 1, 0));
        colocatedMap.Add(new Vector3(-2, 2, 0));
        openMap.Add(new Vector3(-2, 2, 0));

        colocatedMap.Add(new Vector3(1, 0, 0));
        openMap.Add(new Vector3(1, 0, 0));
        colocatedMap.Add(new Vector3(-1, 0, 0));
        openMap.Add(new Vector3(-1, 0, 0));
        
        idX = 0;
        idZ = 3;
        startSide = 0;
        startSideOrientation = "North";
        mapPos += new Vector2(0, -1);

        GameObject newMap = Instantiate(nextMap, new Vector3(7f, 1, 7f) + offsetStart, Quaternion.identity);
        newMapNodes.Add(newMap);
        NewMapNode newMapScript = newMap.GetComponent<NewMapNode>();
        newMapScript.startSide = startSide;
        newMapScript.startSideOrientation = startSideOrientation;
        newMapScript.offsetStart = offsetStart;
        newMapScript.mapPos = mapPos;
        newMapScript.idX = idX;
        newMapScript.idZ = idZ;

        foreach (GameObject NR in navRemovers)
        {
            if (NR.transform.position == newMap.transform.position + new Vector3(0, -0.25f, 0))
            {
                newMapScript.navRemorer = NR;
                break;
            }
        }
    }

    public void Generate(int newStartSide, string newStartSideOrientation, Vector3 newOffsetStart, Vector2 newMapPos, int newIdX, int newIdZ)
    {
        /*
        // Colocamos la base de tierra
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                int specialTile = Random.Range(0, 101);
                if (specialTile < probabilitySpecialTiles)
                {
                    Instantiate(specialGroundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                }
                else
                {
                    Instantiate(groundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                }

                map[i, j] = 1;
            }
        }
        */

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                map[i, j] = 1;
            }
        }

        if (gameFlow.round % 3 == 0 && !miniMainTowerColocate && gameFlow.round > 4)
        {
            miniMainTowerColocate = true;
            
            map[1, 1] = -1;
            map[2, 1] = -1;
            map[1, 2] = -1;
            map[2, 2] = -1;

            map[5, 5] = -1;
            map[5, 4] = -1;
            map[4, 5] = -1;
            map[4, 4] = -1;

            map[1, 5] = -1;
            map[2, 5] = -1;
            map[1, 4] = -1;
            map[2, 4] = -1;

            map[5, 1] = -1;
            map[5, 2] = -1;
            map[4, 1] = -1;
            map[4, 2] = -1;

            /*
            map[3, 3] = -1;
            map[3, 2] = -1;
            map[3, 4] = -1;
            map[2, 3] = -1;
            map[4, 3] = -1;
            */

            int closeWays = Random.Range(0, 3);

            for (int i = 0; i < closeWays; i++)
            {
                if (i < closeWays)
                {
                    switch (i)
                    {
                        case 0:
                            map[3, 2] = -1;
                            map[3, 1] = -1;
                            break;
                        case 1:
                            map[2, 3] = -1;
                            map[1, 3] = -1;
                            break;
                        case 2:
                            map[5, 3] = -1;
                            map[6, 3] = -1;
                            break;
                    }
                }
            }

            // Ponemos césped donde no hay camino
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeZ; j++)
                {
                    if (map[i, j] == -1)
                    {
                        Instantiate(grassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 0.75f, 1) + newOffsetStart, Quaternion.identity);
                    }
                    else
                    {
                        int specialTile = Random.Range(0, 101);
                        if (specialTile < probabilitySpecialTiles)
                        {
                            GameObject instTile = Instantiate(specialGroundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                            gameFlow.idTile++;
                        }
                        else
                        {
                            GameObject instTile = Instantiate(groundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                            gameFlow.idTile++;
                        }

                        map[i, j] = 1;
                    }
                }
            }

            Instantiate(miniMainTower, new Vector3(3 * 2, 0, 3 * 2) + new Vector3(1, 3.5f, 1) + newOffsetStart, Quaternion.identity);

            switch (newStartSideOrientation)
            {
                case "North":
                    nextSideOrientation = "South";
                    break;
                case "South":
                    nextSideOrientation = "North";
                    break;
                case "East":
                    nextSideOrientation = "West";
                    break;
                case "West":
                    nextSideOrientation = "East";
                    break;
            }

            if (newStartSideOrientation == "North" || newStartSideOrientation == "South")
            {
                if (newIdX == 0)
                {
                    newIdX = sizeX - 1;
                }
                else
                {
                    newIdX = 0;
                }
            }
            if (newStartSideOrientation == "East" || newStartSideOrientation == "West")
            {
                if (newIdZ == 0)
                {
                    newIdZ = sizeZ - 1;
                }
                else
                {
                    newIdZ = 0;
                }
            }

            PrepareNextMap(newStartSide, newStartSideOrientation, newOffsetStart, newMapPos, newIdX, newIdZ, nextSideOrientation, false);
        }
        else
        {
            // Creamos las 2 primeras posiciones del camino
            switch (newStartSide)
            {
                case 0:
                    map[newIdX, newIdZ] = -1;
                    newIdX++;
                    map[newIdX, newIdZ] = -1;

                    newStartSideOrientation = "North";
                    break;
                case 1:
                    map[newIdX, newIdZ] = -1;
                    newIdZ--;
                    map[newIdX, newIdZ] = -1;

                    newStartSideOrientation = "East";
                    break;
                case 2:
                    map[newIdX, newIdZ] = -1;
                    newIdX--;
                    map[newIdX, newIdZ] = -1;

                    newStartSideOrientation = "South";
                    break;
                case 3:
                    map[newIdX, newIdZ] = -1;
                    newIdZ++;
                    map[newIdX, newIdZ] = -1;

                    newStartSideOrientation = "West";
                    break;
            }

            int iter = 0;
            int ways = -1;
            int saveIdX = -1;
            int saveIdZ = -1;

            // Creamos trozos de camino hasta que llegue al borde
            while (newIdX > 0 && newIdX < sizeX - 1 && newIdZ > 0 && newIdZ < sizeZ - 1)
            {
                // En el trozo 4 vemos si creamos 1 o 2 caminos extras
                if (iter == 4)
                {
                    int probabilityNewWaysAux = ((probabilityNewWays * 50) / 100) + 25;
                    int waysAux = Random.Range(probabilityNewWaysAux - 25, probabilityNewWaysAux + 25);

                    if (waysAux <= 50)
                    {
                        ways = 0;
                    }
                    else
                    {
                        int aux = Random.Range(0, 3);
                        if (aux == 0)
                        {
                            ways = 1;
                        }
                        else
                        {
                            ways = 2;
                        }
                    }

                    saveIdX = newIdX;
                    saveIdZ = newIdZ;
                }

                // Elegimos la dirección
                int probabilityStraightAux = ((probabilityStraight * 50) / 100) + 25;
                nextSide = Random.Range(probabilityStraightAux - 25, probabilityStraightAux + 25);
                nextSideOrientation = "";

                switch (newStartSideOrientation)
                {
                    case "North":
                        if (nextSide >= 50)
                        {
                            nextSideOrientation = "South";
                        }
                        else
                        {
                            int aux = Random.Range(0, 2);
                            if (aux == 0)
                            {
                                nextSideOrientation = "East";
                            }
                            else
                            {
                                nextSideOrientation = "West";
                            }
                        }
                        break;
                    case "East":
                        if (nextSide >= 50)
                        {
                            nextSideOrientation = "West";
                        }
                        else
                        {
                            int aux = Random.Range(0, 2);
                            if (aux == 0)
                            {
                                nextSideOrientation = "North";
                            }
                            else
                            {
                                nextSideOrientation = "South";
                            }
                        }
                        break;
                    case "South":
                        if (nextSide >= 50)
                        {
                            nextSideOrientation = "North";
                        }
                        else
                        {
                            int aux = Random.Range(0, 2);
                            if (aux == 0)
                            {
                                nextSideOrientation = "East";
                            }
                            else
                            {
                                nextSideOrientation = "West";
                            }
                        }
                        break;
                    case "West":
                        if (nextSide >= 50)
                        {
                            nextSideOrientation = "East";
                        }
                        else
                        {
                            int aux = Random.Range(0, 2);
                            if (aux == 0)
                            {
                                nextSideOrientation = "North";
                            }
                            else
                            {
                                nextSideOrientation = "South";
                            }
                        }
                        break;
                }

                // Creamos el siguiente trozo
                switch (nextSideOrientation)
                {
                    case "North":
                        if (map[newIdX - 1, newIdZ] != -1)
                        {
                            newIdX--;
                            map[newIdX, newIdZ] = -1;
                        }
                        break;
                    case "East":
                        if (map[newIdX, newIdZ + 1] != -1)
                        {
                            newIdZ++;
                            map[newIdX, newIdZ] = -1;
                        }
                        break;
                    case "South":
                        if (map[newIdX + 1, newIdZ] != -1)
                        {
                            newIdX++;
                            map[newIdX, newIdZ] = -1;
                        }
                        break;
                    case "West":
                        if (map[newIdX, newIdZ - 1] != -1)
                        {
                            newIdZ--;
                            map[newIdX, newIdZ] = -1;
                        }
                        break;
                }

                iter++;
            }

            // Creamos los caminos extras
            if (ways == 1)
            {
                GenerateOneWay(newStartSideOrientation, nextSideOrientation, newOffsetStart, newMapPos, saveIdX, saveIdZ);
            }
            if (ways == 2)
            {
                GenerateTwoWays(newStartSideOrientation, nextSideOrientation, newOffsetStart, newMapPos, saveIdX, saveIdZ);
            }

            GameObject grassAux1;
            //GameObject grassAux2;

            // Ponemos césped donde no hay camino
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeZ; j++)
                {
                    if (map[i, j] != -1)
                    {
                        int specialTile = Random.Range(0, 101);
                        specialTile *= 12;
                        if (specialTile < probabilitySpecialTiles)
                        {
                            grassAux1 = Instantiate(specialGrassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 0.75f, 1) + newOffsetStart, Quaternion.identity);
                        }
                        else
                        {
                            int burnTile = Random.Range(0, 101);
                            if (burnTile < probabilityFireTile)
                            {
                                grassAux1 = Instantiate(fireTile, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 0.75f, 1) + newOffsetStart, Quaternion.identity);
                            }
                            else
                            {
                                grassAux1 = Instantiate(grassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 0.75f, 1) + newOffsetStart, Quaternion.identity);
                            }
                        }

                        map[i, j] = 1;
                        
                        int newLayer1 = Random.Range(30, 101);
                        if (newLayer1 < 20)
                        {
                            /*
                            if (specialTile < probabilitySpecialTiles)
                            {
                                grassAux2 = Instantiate(specialGrassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 1.25f, 1) + newOffsetStart, Quaternion.identity);
                            }
                            else
                            {
                                grassAux2 = Instantiate(grassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 1.25f, 1) + newOffsetStart, Quaternion.identity);
                            }

                            grassAux1.layer = 0;

                            map[i, j] = 2;

                            int newLayer2 = Random.Range(0, 101);
                            if (newLayer2 < 20 && i != 0 && i != sizeX - 1 && j != 0 && j != sizeZ - 1)
                            {
                                if (specialTile < probabilitySpecialTiles)
                                {
                                    Instantiate(specialGrassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 1.75f, 1) + newOffsetStart, Quaternion.identity);
                                }
                                else
                                {
                                    Instantiate(grassBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 1.75f, 1) + newOffsetStart, Quaternion.identity);
                                }

                                grassAux2.layer = 0;

                                map[i, j] = 3;
                            }
                            */
                        }
                        else
                        {
                            int newObstacle = Random.Range(0, 101);
                            newObstacle *= 12;
                            if (newObstacle < probabilityObstacles)
                            {
                                Instantiate(obstacleBlock, new Vector3(i * 2, 0, j * 2) + new Vector3(1, 3, 1) + newOffsetStart, Quaternion.identity);
                            }
                        }
                        
                    }
                    else
                    {
                        int specialTile = Random.Range(0, 101);
                        if (specialTile < probabilitySpecialTiles)
                        {
                            GameObject instTile = Instantiate(specialGroundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                            gameFlow.idTile++;
                        }
                        else
                        {
                            GameObject instTile = Instantiate(groundBlock, new Vector3(i * 2, 0.25f, j * 2) + new Vector3(1, 0, 1) + newOffsetStart, Quaternion.identity);
                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                            gameFlow.idTile++;
                        }

                        map[i, j] = 1;
                    }
                }
            }

            colocatedMap.Add(newMapPos);

            // Preparamos las variables para la siguiente iteración
            PrepareNextMap(newStartSide, newStartSideOrientation, newOffsetStart, newMapPos, newIdX, newIdZ, nextSideOrientation, false);
        }

        if (gameFlow.round % expandRate == 0)
        {
            numNewMapNodes--;
            if (activateRounds && ((numNewMapNodes - repiteNewMapNode) == 0 || (numNewMapNodesLimit - numNewMapNodes == 3)))
            {
                Invoke("CalculateNewMapNodes", 0.2f);

                gameFlow.StartRound();

                miniMainTowerColocate = false;
            }
        }
    }

    void CalculateNewMapNodes()
    {
        int numNewMapNodesAux = 0;

        foreach (var newMapNode in newMapNodes)
        {
            if (newMapNode != null)
            {
                numNewMapNodesAux++;
            }
        }

        numNewMapNodes = numNewMapNodesAux;
        numNewMapNodesLimit = numNewMapNodesAux;
        //numNewMapNodes = numNewMapNodesAux - repiteNewMapNode;
        repiteNewMapNode = 0;
    }


    void GenerateOneWay(string myStartSideOrientation, string myNextSideOrientation, Vector3 myOffsetStart, Vector2 myMapPos, int myIdX, int myIdZ)
    {
        List<string> directions = new List<string>();

        if (myStartSideOrientation != "North" && myNextSideOrientation != "North")
        {
            directions.Add("North");
        }
        if (myStartSideOrientation != "East" && myNextSideOrientation != "East")
        {
            directions.Add("East");
        }
        if (myStartSideOrientation != "South" && myNextSideOrientation != "South")
        {
            directions.Add("South");
        }
        if (myStartSideOrientation != "West" && myNextSideOrientation != "West")
        {
            directions.Add("West");
        }

        int direction = Random.Range(0, 2);
        string finalDirection = directions[direction];

        PrepareNextMap(-1, myStartSideOrientation, myOffsetStart, myMapPos, myIdX, myIdZ, finalDirection, true);
    }

    void GenerateTwoWays(string myStartSideOrientation, string myNextSideOrientation, Vector3 myOffsetStart, Vector2 myMapPos, int myIdX, int myIdZ)
    {
        string startSideOrientation_Aux = myStartSideOrientation;
        string nextSideOrientation_Aux = myNextSideOrientation;
        Vector3 offsetStart_Aux = myOffsetStart;
        Vector2 mapPos_Aux = myMapPos;
        int idX_Aux = myIdX;
        int idZ_Aux = myIdZ;

        List<string> directions = new List<string>();

        if (startSideOrientation_Aux != "North" && nextSideOrientation_Aux != "North")
        {
            directions.Add("North");
        }
        if (startSideOrientation_Aux != "East" && nextSideOrientation_Aux != "East")
        {
            directions.Add("East");
        }
        if (startSideOrientation_Aux != "South" && nextSideOrientation_Aux != "South")
        {
            directions.Add("South");
        }
        if (startSideOrientation_Aux != "West" && nextSideOrientation_Aux != "West")
        {
            directions.Add("West");
        }

        PrepareNextMap(-1, startSideOrientation_Aux, offsetStart_Aux, mapPos_Aux, idX_Aux, idZ_Aux, directions[0], true);

        PrepareNextMap(-1, myStartSideOrientation, myOffsetStart, myMapPos, myIdX, myIdZ, directions[1], true);
    }

    void PrepareNextMap(int newStartSide, string newStartSideOrientation, Vector3 newOffsetStart, Vector2 newMapPos, int newIdX, int newIdZ, string newNextSideOrientation, bool newWay)
    {
        if (newWay)
        {
            while (newIdX > 0 && newIdX < sizeX - 1 && newIdZ > 0 && newIdZ < sizeZ - 1)
            {
                switch (newNextSideOrientation)
                {
                    case "North":
                        newIdX--;
                        map[newIdX, newIdZ] = -1;
                        break;
                    case "East":
                        newIdZ++;
                        map[newIdX, newIdZ] = -1;
                        break;
                    case "South":
                        newIdX++;
                        map[newIdX, newIdZ] = -1;
                        break;
                    case "West":
                        newIdZ--;
                        map[newIdX, newIdZ] = -1;
                        break;
                }
            }
        }

        bool deleteWay;
        int deleteWayAux = Random.Range(0, 101);
        if (deleteWayAux < probabilityDeleteWay)
        {
            deleteWay = true;
        }
        else
        {
            deleteWay = false;
        }

        int conectWaysAux = Random.Range(0, 101);

        switch (newNextSideOrientation)
        {
            case "North":
                Vector3 localOffset1 = new Vector3(1, 0, 1) + newOffsetStart - new Vector3(0, 0, 0);

                newStartSide = 2;
                newStartSideOrientation = "South";

                newOffsetStart += new Vector3(-14, 0, 0);
                newMapPos += new Vector2(0, 1);

                newIdX = sizeX - 1;

                if (!colocatedMap.Contains(newMapPos) && !openMap.Contains(newMapPos) && !deleteWay)
                {
                    GameObject newMap1 = Instantiate(nextMap, new Vector3(7f, 1, 7f) + newOffsetStart, Quaternion.identity);
                    newMap1.SetActive(false);
                    newMapNodes.Add(newMap1);
                    NewMapNode newMapScript1 = newMap1.GetComponent<NewMapNode>();
                    newMapScript1.startSide = newStartSide;
                    newMapScript1.startSideOrientation = newStartSideOrientation;
                    newMapScript1.offsetStart = newOffsetStart;
                    newMapScript1.mapPos = newMapPos;
                    newMapScript1.idX = newIdX;
                    newMapScript1.idZ = newIdZ;

                    GameObject spawn = Instantiate(transparentEnemySpawn, new Vector3(0, 1.25f, newIdZ * 2) + localOffset1, Quaternion.identity);
                    newMapScript1.spawn = spawn;

                    GameObject auxGrass = Instantiate(blockNavRemover, new Vector3(-2, 0.75f, newIdZ * 2) + localOffset1, Quaternion.identity);
                    newMapScript1.auxGrass = auxGrass;

                    foreach (GameObject NR in navRemovers)
                    {
                        if (NR.transform.position == newMap1.transform.position + new Vector3(0, -0.25f, 0))
                        {
                            newMapScript1.navRemorer = NR;
                            break;
                        }
                    }
                }
                else
                {
                    if (probabilityConectWays > conectWaysAux && Physics.Raycast(new Vector3(-2, 50, newIdZ * 2) + localOffset1, transform.TransformDirection(-Vector3.up), 1000, LayerMask.GetMask("Grass")))
                    {
                        bool isGrass = true;
                        int offsetAux = -2;

                        while (isGrass)
                        {
                            Vector3 pos = new Vector3(offsetAux, 50, newIdZ * 2) + localOffset1;
                            RaycastHit hit;
                            if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                            {
                                if (hit.collider.gameObject.transform.position.y == 0.5f)
                                {
                                    GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                    instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                    gameFlow.idTile++;
                                }

                                Destroy(hit.collider.gameObject);

                                if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                {
                                    if (hit.collider.gameObject.transform.position.y == 0.5f)
                                    {
                                        GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                        instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                        gameFlow.idTile++;
                                    }

                                    Destroy(hit.collider.gameObject);

                                    if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                    {
                                        if (hit.collider.gameObject.transform.position.y == 0.5f)
                                        {
                                            GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                            gameFlow.idTile++;
                                        }

                                        Destroy(hit.collider.gameObject);

                                        if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                        {
                                            if (hit.collider.gameObject.transform.position.y == 0.5f)
                                            {
                                                GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                                instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                                gameFlow.idTile++;
                                            }

                                            Destroy(hit.collider.gameObject);
                                        }
                                    }
                                }

                                offsetAux -= 2;
                            }
                            else
                            {
                                isGrass = false;
                            }
                        }
                    }
                    else
                    {
                        if (!newWay)
                        {
                            GameObject instSpawn = Instantiate(enemySpawn, new Vector3(2, 0.75f, newIdZ * 2) + localOffset1, Quaternion.identity);
                            instSpawn.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                        }
                        else
                        {
                            GameObject instTreasure = Instantiate(treasure, new Vector3(2, 0.75f, newIdZ * 2) + localOffset1, Quaternion.identity);
                            instTreasure.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        }

                        Instantiate(grassBlock, new Vector3(0, 0.75f, newIdZ * 2) + localOffset1, Quaternion.identity);
                    }
                }
                break;
            case "East":
                Vector3 localOffset2 = new Vector3(1, 0, 1) + newOffsetStart - new Vector3(0, 0, 0);

                newStartSide = 3;
                newStartSideOrientation = "West";

                newOffsetStart += new Vector3(0, 0, 14);
                newMapPos += new Vector2(1, 0);

                newIdZ = 0;

                if (!colocatedMap.Contains(newMapPos) && !openMap.Contains(newMapPos) && !deleteWay)
                {
                    GameObject newMap2 = Instantiate(nextMap, new Vector3(7f, 1, 7f) + newOffsetStart, Quaternion.identity);
                    newMap2.SetActive(false);
                    newMapNodes.Add(newMap2);
                    NewMapNode newMapScript2 = newMap2.GetComponent<NewMapNode>();
                    newMapScript2.startSide = newStartSide;
                    newMapScript2.startSideOrientation = newStartSideOrientation;
                    newMapScript2.offsetStart = newOffsetStart;
                    newMapScript2.mapPos = newMapPos;
                    newMapScript2.idX = newIdX;
                    newMapScript2.idZ = newIdZ;

                    GameObject spawn = Instantiate(transparentEnemySpawn, new Vector3(newIdX * 2, 1.25f, (sizeZ * 2) - 2) + localOffset2, Quaternion.identity);
                    newMapScript2.spawn = spawn;

                    GameObject auxGrass = Instantiate(blockNavRemover, new Vector3(newIdX * 2, 0.75f, sizeZ * 2) + localOffset2, Quaternion.identity);
                    newMapScript2.auxGrass = auxGrass;

                    foreach (GameObject NR in navRemovers)
                    {
                        if (NR.transform.position == newMap2.transform.position + new Vector3(0, -0.25f, 0))
                        {
                            newMapScript2.navRemorer = NR;
                            break;
                        }
                    }
                }
                else
                {
                    if (probabilityConectWays > conectWaysAux && Physics.Raycast(new Vector3(newIdX * 2, 50, (sizeZ * 2) - 0) + localOffset2, transform.TransformDirection(-Vector3.up), 1000, LayerMask.GetMask("Grass")))
                    {
                        bool isGrass = true;
                        int offsetAux = 0;

                        while (isGrass)
                        {
                            Vector3 pos = new Vector3(newIdX * 2, 50, (sizeZ * 2) - offsetAux) + localOffset2;
                            RaycastHit hit;
                            if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                            {
                                Destroy(hit.collider.gameObject);

                                if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                {
                                    Destroy(hit.collider.gameObject);

                                    if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                    {
                                        if (hit.collider.gameObject.transform.position.y == 0.5f)
                                        {
                                            GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                            gameFlow.idTile++;
                                        }

                                        Destroy(hit.collider.gameObject);

                                        if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                        {
                                            if (hit.collider.gameObject.transform.position.y == 0.5f)
                                            {
                                                GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                                instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                                gameFlow.idTile++;
                                            }

                                            Destroy(hit.collider.gameObject);
                                        }
                                    }
                                }

                                offsetAux -= 2;
                            }
                            else
                            {
                                isGrass = false;
                            }
                        }
                    }
                    else
                    {
                        if (!newWay)
                        {
                            GameObject instSpawn = Instantiate(enemySpawn, new Vector3(newIdX * 2, 1.5f, (sizeZ * 2) - 4) + localOffset2, Quaternion.identity);
                            instSpawn.transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                        }
                        else
                        {
                            GameObject instTreasure = Instantiate(treasure, new Vector3(newIdX * 2, 1.5f, (sizeZ * 2) - 4) + localOffset2, Quaternion.identity);
                            instTreasure.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                        }

                        Instantiate(grassBlock, new Vector3(newIdX * 2, 0.75f, (sizeZ * 2) - 2) + localOffset2, Quaternion.identity);
                    }
                }
                break;
            case "South":
                Vector3 localOffset3 = new Vector3(1, 0, 1) + newOffsetStart - new Vector3(0, 0, 0);

                newStartSide = 0;
                newStartSideOrientation = "North";

                newOffsetStart += new Vector3(14, 0, 0);
                newMapPos += new Vector2(0, -1);

                newIdX = 0;

                if (!colocatedMap.Contains(newMapPos) && !openMap.Contains(newMapPos) && !deleteWay)
                {
                    GameObject newMap3 = Instantiate(nextMap, new Vector3(7, 1, 7) + newOffsetStart, Quaternion.identity);
                    newMap3.SetActive(false);
                    newMapNodes.Add(newMap3);
                    NewMapNode newMapScript3 = newMap3.GetComponent<NewMapNode>();
                    newMapScript3.startSide = newStartSide;
                    newMapScript3.startSideOrientation = newStartSideOrientation;
                    newMapScript3.offsetStart = newOffsetStart;
                    newMapScript3.mapPos = newMapPos;
                    newMapScript3.idX = newIdX;
                    newMapScript3.idZ = newIdZ;

                    GameObject spawn = Instantiate(transparentEnemySpawn, new Vector3((sizeX * 2) - 2, 1.25f, newIdZ * 2) + localOffset3, Quaternion.identity);
                    newMapScript3.spawn = spawn;

                    GameObject auxGrass = Instantiate(blockNavRemover, new Vector3(sizeX * 2, 0.75f, newIdZ * 2) + localOffset3, Quaternion.identity);
                    newMapScript3.auxGrass = auxGrass;

                    foreach (GameObject NR in navRemovers)
                    {
                        if (NR.transform.position == newMap3.transform.position + new Vector3(0, -0.25f, 0))
                        {
                            newMapScript3.navRemorer = NR;
                            break;
                        }
                    }
                }
                else
                {
                    if (probabilityConectWays > conectWaysAux && Physics.Raycast(new Vector3((sizeX * 2) - 0, 50, newIdZ * 2) + localOffset3, transform.TransformDirection(-Vector3.up), 1000, LayerMask.GetMask("Grass")))
                    {
                        bool isGrass = true;
                        int offsetAux = 0;

                        while (isGrass)
                        {
                            Vector3 pos = new Vector3((sizeX * 2) - offsetAux, 50, newIdZ * 2) + localOffset3;
                            RaycastHit hit;
                            if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                            {
                                Destroy(hit.collider.gameObject);

                                if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                {
                                    Destroy(hit.collider.gameObject);

                                    if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                    {
                                        if (hit.collider.gameObject.transform.position.y == 0.5f)
                                        {
                                            GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                            gameFlow.idTile++;
                                        }

                                        Destroy(hit.collider.gameObject);

                                        if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                        {
                                            if (hit.collider.gameObject.transform.position.y == 0.5f)
                                            {
                                                GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                                instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                                gameFlow.idTile++;
                                            }

                                            Destroy(hit.collider.gameObject);
                                        }
                                    }
                                }

                                offsetAux -= 2;
                            }
                            else
                            {
                                isGrass = false;
                            }
                        }
                    }
                    else
                    {
                        if (!newWay)
                        {
                            GameObject instSpawn = Instantiate(enemySpawn, new Vector3((sizeX * 2) - 4, 1.5f, newIdZ * 2) + localOffset3, Quaternion.identity);
                            instSpawn.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                        }
                        else
                        {
                            GameObject instTreasure = Instantiate(treasure, new Vector3((sizeX * 2) - 4, 1.5f, newIdZ * 2) + localOffset3, Quaternion.identity);
                            instTreasure.transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                        }

                        Instantiate(grassBlock, new Vector3((sizeX * 2) - 2, 0.75f, newIdZ * 2) + localOffset3, Quaternion.identity);
                    }
                }
                break;
            case "West":
                Vector3 localOffset4 = new Vector3(1, 0, 1) + newOffsetStart - new Vector3(0, 0, 0);

                newStartSide = 1;
                newStartSideOrientation = "East";

                newOffsetStart += new Vector3(0, 0, -14);
                newMapPos += new Vector2(-1, 0);

                newIdZ = sizeZ - 1;

                if (!colocatedMap.Contains(newMapPos) && !openMap.Contains(newMapPos) && !deleteWay)
                {
                    GameObject newMap4 = Instantiate(nextMap, new Vector3(7, 1, 7) + newOffsetStart, Quaternion.identity);
                    newMap4.SetActive(false);
                    newMapNodes.Add(newMap4);
                    NewMapNode newMapScript4 = newMap4.GetComponent<NewMapNode>();
                    newMapScript4.startSide = newStartSide;
                    newMapScript4.startSideOrientation = newStartSideOrientation;
                    newMapScript4.offsetStart = newOffsetStart;
                    newMapScript4.mapPos = newMapPos;
                    newMapScript4.idX = newIdX;
                    newMapScript4.idZ = newIdZ;

                    GameObject spawn = Instantiate(transparentEnemySpawn, new Vector3(newIdX * 2, 1.25f, 0) + localOffset4, Quaternion.identity);
                    newMapScript4.spawn = spawn;

                    GameObject auxGrass = Instantiate(blockNavRemover, new Vector3(newIdX * 2, 0.75f, -2) + localOffset4, Quaternion.identity);
                    newMapScript4.auxGrass = auxGrass;

                    foreach (GameObject NR in navRemovers)
                    {
                        if (NR.transform.position == newMap4.transform.position + new Vector3(0, -0.25f, 0))
                        {
                            newMapScript4.navRemorer = NR;
                            break;
                        }
                    }
                }
                else
                {
                    if (probabilityConectWays > conectWaysAux && Physics.Raycast(new Vector3(newIdX * 2, 50, -2) + localOffset4, transform.TransformDirection(-Vector3.up), 1000, LayerMask.GetMask("Grass")))
                    {
                        bool isGrass = true;
                        int offsetAux = -2;

                        while (isGrass)
                        {
                            Vector3 pos = new Vector3(newIdX * 2, 50, offsetAux) + localOffset4;
                            RaycastHit hit;
                            if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                            {
                                Destroy(hit.collider.gameObject);

                                if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                {
                                    Destroy(hit.collider.gameObject);

                                    if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                    {
                                        if (hit.collider.gameObject.transform.position.y == 0.5f)
                                        {
                                            GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                            instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                            gameFlow.idTile++;
                                        }

                                        Destroy(hit.collider.gameObject);

                                        if (Physics.Raycast(pos, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Grass")))
                                        {
                                            if (hit.collider.gameObject.transform.position.y == 0.5f)
                                            {
                                                GameObject instTile = Instantiate(groundBlock, hit.collider.gameObject.transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                                                instTile.GetComponent<MapInfo>().id = gameFlow.round;
                                                gameFlow.idTile++;
                                            }

                                            Destroy(hit.collider.gameObject);
                                        }
                                    }
                                }

                                offsetAux -= 2;
                            }
                            else
                            {
                                isGrass = false;
                            }
                        }
                    }
                    else
                    {
                        if (!newWay)
                        {
                            GameObject instSpawn = Instantiate(enemySpawn, new Vector3(newIdX * 2, 0.75f, 2) + localOffset4, Quaternion.identity);
                            instSpawn.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        }
                        else
                        {
                            GameObject instTreasure = Instantiate(treasure, new Vector3(newIdX * 2, 0.75f, 2) + localOffset4, Quaternion.identity);
                            instTreasure.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                        }

                        Instantiate(grassBlock, new Vector3(newIdX * 2, 0.75f, 0) + localOffset4, Quaternion.identity);
                    }
                }
                break;
        }
    }
}
