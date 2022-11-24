using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocatorManager : MonoBehaviour
{
    public static ColocatorManager instance;

    GameFlow gameFlow;

    public GameObject towerPlace;
    public GameObject instTowerPlace;
    public Material transparentMaterial;
    public int actualID = -1;

    public int towerID;
    public GameObject[] towers;

    public bool canBuild = false;
    public bool heroBuild = false;

    int minesBuilt = 0;
    int limitMines = 5;

    public float canDisableColocatotMode = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameFlow = GameFlow.instance;
        //instTowerPlace = Instantiate(towerPlace, new Vector3(1000, 1000, 1000), Quaternion.identity);
        
        for (int i = 1; i < towers.Length; i++)
        {
            GameObject instTower = Instantiate(towers[i], new Vector3(0, -1000, 0), transform.rotation);
            instTower.GetComponent<Tower>().enabled = false;
            
            towers[i] = instTower;
        }

        foreach (var cardScript in gameFlow.cardsScripts)
        {
            cardScript.hero = towers[0].GetComponent<Hero>();
        }

    }

    void Update()
    {
        canDisableColocatotMode -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //canBuild = !canBuild;
        }
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            canBuild = false;
            towerID = -1;
        }
        */
        if (actualID != towerID && towerID != -1)
        {
            actualID = towerID;
            Destroy(instTowerPlace);

            instTowerPlace = Instantiate(towers[towerID], new Vector3(1000, 1000, 1000), Quaternion.identity);
            instTowerPlace.GetComponent<Tower>().rangeArea.transform.localScale = new Vector3(instTowerPlace.GetComponent<Tower>().rangeArea.transform.localScale.x * instTowerPlace.GetComponent<Tower>().range, instTowerPlace.GetComponent<Tower>().rangeArea.transform.localScale.y, instTowerPlace.GetComponent<Tower>().rangeArea.transform.localScale.z * instTowerPlace.GetComponent<Tower>().range);
            if (instTowerPlace.GetComponent<Tower>())
            {
                instTowerPlace.GetComponent<Tower>().enabled = false;
            }
            if (instTowerPlace.GetComponentInChildren<Tower>())
            {
                instTowerPlace.GetComponentInChildren<Tower>().enabled = false;
            }
            instTowerPlace.GetComponent<BoxCollider>().enabled = false;

            MeshRenderer[] meshs = instTowerPlace.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshs)
            {
                mesh.material = transparentMaterial;
            }
        }

        if (canBuild)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                Tower towerScript;
                if (towers[towerID].GetComponent<Tower>())
                {
                    towerScript = towers[towerID].GetComponent<Tower>();
                }
                else
                {
                    towerScript = towers[towerID].GetComponentInChildren<Tower>();
                }

                if (rayHit.collider.gameObject.layer == 7 && towerScript.canColocate == Tower.CanColocate.Ground)
                {
                    instTowerPlace.transform.position = rayHit.collider.transform.position + new Vector3(0, 1, 0);
                }
                else if (rayHit.collider.gameObject.layer == 8 && towerScript.canColocate == Tower.CanColocate.Path)
                {
                    instTowerPlace.transform.position = rayHit.collider.transform.position + new Vector3(0, 1, 0);
                }
                else
                {
                    instTowerPlace.transform.position = new Vector3(1000, 1000, 1000);
                }
            }
        }
        else
        {
            if (instTowerPlace != null)
            {
                instTowerPlace.transform.position = new Vector3(1000, 1000, 1000);
            }
        }

        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && canBuild)
        {
            if (heroBuild && towerID == 0)
            {
                return;
            }
            if (towerID == 7 && minesBuilt >= limitMines)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                Tower towerScript;
                if (towers[towerID].GetComponent<Tower>())
                {
                    towerScript = towers[towerID].GetComponent<Tower>();
                }
                else
                {
                    towerScript = towers[towerID].GetComponentInChildren<Tower>();
                }

                if (rayHit.collider.gameObject.layer == 7 && towerScript.canColocate == Tower.CanColocate.Ground)
                {
                    if (gameFlow.coins >= towerScript.price)
                    {
                        if (towerID == 0)
                        {
                            HUD_Manager.instance.towersButtonIcon[0].GetComponent<Button>().interactable = false;
                            heroBuild = true;
                        }

                        gameFlow.coins -= towerScript.price;

                        //rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        //rayHit.collider.gameObject.layer = 0;

                        if (towerID == 7)
                        {
                            if (minesBuilt < limitMines)
                            {
                                minesBuilt++;
                            }
                        }

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        instTower.GetComponent<Tower>().enabled = true;

                        if (instTower.GetComponentsInChildren<Tower>().Length > 0)
                        {
                            foreach (var tower in instTower.GetComponentsInChildren<Tower>())
                            {
                                tower.enabled = true;
                            }
                        }

                        if (heroBuild && towerID == 0)
                        {
                            foreach (var cardScript in gameFlow.cardsScripts)
                            {
                                cardScript.hero = instTower.GetComponent<Hero>();
                            }
                        }

                        Tower instTowerScript;
                        if (towers[towerID].GetComponent<Tower>())
                        {
                            instTowerScript = instTower.GetComponent<Tower>();
                        }
                        else
                        {
                            instTowerScript = instTower.GetComponentInChildren<Tower>();
                        }

                        if (rayHit.collider.gameObject.tag == "SpecialGrass")
                        {
                            instTowerScript.specialTile = true;
                            instTowerScript.burnTile = false;
                        }
                        else if (rayHit.collider.gameObject.tag == "Burn")
                        {
                            instTower.transform.position += new Vector3(0, -0.25f, 0);

                            instTowerScript.burnTile = true;
                            instTowerScript.specialTile = false;
                        }
                        else
                        {
                            instTowerScript.specialTile = false;
                            instTowerScript.burnTile = false;
                        }

                        canBuild = false;
                        towerID = -1;

                        //Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
                    }
                }
                else if (rayHit.collider.gameObject.layer == 8 && towerScript.canColocate == Tower.CanColocate.Path)
                {
                    if (towerID == 0)
                    {
                        heroBuild = true;
                    }
                    if (gameFlow.coins >= towerScript.price)
                    {
                        gameFlow.coins -= towerScript.price;

                        //rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        //rayHit.collider.gameObject.layer = 0;

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                        instTower.GetComponent<Tower>().enabled = true;
                        Tower instTowerScript;
                        if (towers[towerID].GetComponent<Tower>())
                        {
                            instTowerScript = instTower.GetComponent<Tower>();
                        }
                        else
                        {
                            instTowerScript = instTower.GetComponentInChildren<Tower>();
                        }

                        if (rayHit.collider.gameObject.tag == "SpecialGround")
                        {
                            instTowerScript.specialTile = true;
                        }
                        else
                        {
                            instTowerScript.specialTile = false;
                        }

                        canBuild = false;
                        towerID = -1;
                    }
                }
                else
                {
                    if (canDisableColocatotMode <= 0)
                    {
                        canBuild = false;
                        towerID = -1;
                    }
                }
            }
        }
    }
}
