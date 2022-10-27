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

    [Header("Zona de agua")]
    public GameObject wave;

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
            hudManager.ActivateGameOver();
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
                        Destroy(instInfestation, 5);
                        activateTower = false;
                        restRounds = roundsToReset;
                    }

                    timeToWait = 0;
                }
                break;
            case Zone.Atlantis:
                if (Input.GetButtonDown("Fire1") && timeToWait > 0.2f && activateTower)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit, 1000))
                    {
                        GameObject instWave = Instantiate(wave, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);

                        Vector3 dir = rayHit.point - transform.position;
                        Quaternion lookRotation = Quaternion.LookRotation(dir);
                        Vector3 rotation = Quaternion.Lerp(instWave.transform.rotation, lookRotation, Time.deltaTime * 500).eulerAngles;
                        instWave.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

                        instWave.GetComponent<Rigidbody>().velocity = new Vector3(dir.normalized.x, 0, dir.normalized.z) * 10;

                        Destroy(instWave, 10);
                        activateTower = false;
                        restRounds = roundsToReset;
                    }

                    timeToWait = 0;
                }
                break;
            case Zone.Vikingos:

                break;
            case Zone.Fantasia:

                break;
            case Zone.Infierno:

                break;
        }
    }
    /*
    private void OnMouseUpAsButton()
    {
        if (restRounds <= 0)
        {
            activateTower = true;
        }
    }
    */
}
