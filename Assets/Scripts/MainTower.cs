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

    [Header("Zona de hielo")]
    public GameObject blizzard;
    public float blizzadTime;
    float timeToWait = 0;

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

        switch (zone)
        {
            case Zone.Hielo:
                timeToWait += Time.deltaTime;

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
