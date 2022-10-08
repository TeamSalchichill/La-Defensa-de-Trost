using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocatorManager : MonoBehaviour
{
    public static ColocatorManager instance;

    GameFlow gameFlow;

    public GameObject sticky;
    public GameObject grass;
    public GameObject activeTower;

    public int towerID;
    public GameObject[] towers;

    public bool canBuild = false;
    public bool heroBuild = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameFlow = GameFlow.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            canBuild = !canBuild;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            canBuild = false;
        }

        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && canBuild)
        {
            if (heroBuild && towerID == 0)
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
                    if (towerID == 0)
                    {
                        heroBuild = true;
                    }
                    if (gameFlow.coins >= towerScript.price)
                    {
                        gameFlow.coins -= towerScript.price;

                        rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        rayHit.collider.gameObject.layer = 0;

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);
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
                        }
                        else
                        {
                            instTowerScript.specialTile = false;
                        }
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

                        rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        rayHit.collider.gameObject.layer = 0;

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);
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
                    }
                }
            }
        }
    }
}
