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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                if (rayHit.collider.gameObject.layer == 7 && towers[towerID].GetComponent<Tower>().canColocate == Tower.CanColocate.Ground)
                {
                    if (gameFlow.coins >= towers[towerID].GetComponent<Tower>().price)
                    {
                        gameFlow.coins -= towers[towerID].GetComponent<Tower>().price;

                        rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        rayHit.collider.gameObject.layer = 0;

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);

                        if (rayHit.collider.gameObject.tag == "SpecialGrass")
                        {
                            instTower.GetComponent<Tower>().specialTile = true;
                        }
                        else
                        {
                            instTower.GetComponent<Tower>().specialTile = false;
                        }
                        //Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
                    }
                }
                else if (rayHit.collider.gameObject.layer == 8 && towers[towerID].GetComponent<Tower>().canColocate == Tower.CanColocate.Path)
                {
                    if (gameFlow.coins >= towers[towerID].GetComponent<Tower>().price)
                    {
                        gameFlow.coins -= towers[towerID].GetComponent<Tower>().price;

                        rayHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        rayHit.collider.gameObject.layer = 0;

                        GameObject instTower = Instantiate(towers[towerID], rayHit.collider.gameObject.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);

                        if (rayHit.collider.gameObject.tag == "SpecialGround")
                        {
                            instTower.GetComponent<Tower>().specialTile = true;
                        }
                        else
                        {
                            instTower.GetComponent<Tower>().specialTile = false;
                        }
                    }
                }
            }
        }
    }
}
