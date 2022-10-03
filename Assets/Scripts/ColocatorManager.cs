using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocatorManager : MonoBehaviour
{
    public static ColocatorManager instance;

    public enum Action { None, Tower }
    public Action action = Action.None;

    public GameObject sticky;
    public GameObject grass;
    public GameObject tower;

    public bool canBuild = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            action = Action.None;
            canBuild = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            action = Action.Tower;
            canBuild = true;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                if (rayHit.collider.gameObject.layer == 7 && action == Action.Tower)
                {
                    Instantiate(tower, rayHit.collider.gameObject.transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
                }
            }
        }
    }
}
