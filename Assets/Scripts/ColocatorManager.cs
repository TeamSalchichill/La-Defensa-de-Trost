using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocatorManager : MonoBehaviour
{
    public static ColocatorManager instance;

    public GameObject sticky;
    public GameObject grass;
    public GameObject tower;
    public GameObject testTower;

    public bool canBuild = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            canBuild = !canBuild;
        }

        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && canBuild)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                if (rayHit.collider.gameObject.layer == 7)
                {
                    Instantiate(tower, rayHit.collider.gameObject.transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
                }
            }
        }
    }
}
