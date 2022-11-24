using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolocateManual : MonoBehaviour
{
    public bool realocate = false;
    public bool nextRound = true;

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
                if ((rayHit.collider.gameObject.layer == 7 && GetComponent<Tower>().canColocate == Tower.CanColocate.Ground) || (rayHit.collider.gameObject.layer == 8 && GetComponent<Tower>().canColocate == Tower.CanColocate.Path))
                {
                    if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                    {
                        Vector3 recolocateOffset = new Vector3(0, 0, 0);

                        if (GetComponent<Recolocate>())
                        {
                            recolocateOffset = GetComponent<Recolocate>().offsetPos;
                        }

                        transform.position = rayHit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0) + recolocateOffset;
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
