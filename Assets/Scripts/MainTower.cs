using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    public static MainTower instance;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno }
    public Zone zone;

    HUD_Manager hudManager;

    public int health;

    public bool activateTower = false;
    public int roundsToReset;
    public int restRounds;

    [Header("General")]
    float timeToWait = 0;

    [Header("Zona de hielo")]
    public GameObject blizzard;
    public float blizzadTime;

    [Header("Zona de desierto")]
    public GameObject infection;
    public float infectationDuration;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hudManager = HUD_Manager.instance;
    }

    void Update()
    {
        if (health <= 0)
        {
            hudManager.ResetGame();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            activateTower = false;
        }

        timeToWait += Time.deltaTime;

        switch (zone)
        {
            case Zone.Hielo:
                if (Input.GetButtonDown("Fire1") && timeToWait > 0.2f && activateTower)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit, 1000))
                    {
                        GameObject instBlizzard = Instantiate(blizzard, rayHit.point, Quaternion.identity);
                        Destroy(instBlizzard, blizzadTime);
                        activateTower = false;
                        restRounds = roundsToReset;
                    }

                    timeToWait = 0;
                }
                break;
            case Zone.Desierto:
                if (Input.GetButtonDown("Fire1") && timeToWait > 0.2f && activateTower)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit, 1000))
                    {
                        GameObject instInfestation = Instantiate(infection, rayHit.point, Quaternion.identity);
                        Destroy(instInfestation, 1);
                        activateTower = false;
                        restRounds = roundsToReset;
                    }

                    timeToWait = 0;
                }
                break;
            case Zone.Atlantis:

                break;
            case Zone.Vikingos:

                break;
            case Zone.Fantasia:

                break;
            case Zone.Infierno:

                break;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (restRounds <= 0)
        {
            activateTower = true;
        }
    }
}
