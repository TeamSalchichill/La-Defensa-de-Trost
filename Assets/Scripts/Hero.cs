using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero instance;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno }
    public Zone zone;

    public bool realocate = false;
    public bool nextRound = true;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            realocate = false;
        }
        if (realocate && nextRound)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                if (rayHit.collider.gameObject.layer == 7)
                {
                    if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                    {
                        transform.position = rayHit.collider.gameObject.transform.position + new Vector3(0, 0.25f, 0);
                        realocate = false;
                        nextRound = false;

                        if (GetComponent<Recolocate>())
                        {
                            if (GetComponent<Recolocate>().oritateToPath)
                            {
                                GetComponent<Recolocate>().Orientate();
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        Invoke("CanRealocate", 0.2f);
    }

    void CanRealocate()
    {
        realocate = true;
    }
}
