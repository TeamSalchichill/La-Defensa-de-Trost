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

    [Header("Preview")]
    public GameObject hechizoHolo;
    public Vector3 offset;

    GameObject instHechizoHolo;

    [Header("Zona de hielo")]
    public GameObject blizzard;
    public float blizzadTime;

    [Header("Zona de desierto")]
    public GameObject infection;
    public float infectationDuration;

    [Header("Zona de agua")]
    public GameObject wave;

    [Header("Zona de dioses")]
    public GameObject lanza;
    public float lanzaTime = 4;

    [Header("Zona de dioses")]
    public GameObject shieldMagic;
    public float shieldTime = 10;

    [Header("Zona de agua")]
    public GameObject fireBall;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hudManager = HUD_Manager.instance;

        health = 99999;

        instHechizoHolo = Instantiate(hechizoHolo, new Vector3(0, -1000, 0), transform.rotation);
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

        if (activateTower)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                instHechizoHolo.transform.position = rayHit.point + offset;
            }
            else
            {
                instHechizoHolo.transform.position = new Vector3(0, -1000, 0);
            }
        }
        else
        {
            instHechizoHolo.transform.position = new Vector3(0, -1000, 0);
        }

        if (Input.GetButtonDown("Fire1") && timeToWait > 0.2f && activateTower)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 1000))
            {
                SoundManager.instance.SoundSelection(7, 0.5f);
                hudManager.hechizoText.text = roundsToReset.ToString();

                switch (zone)
                {
                    case Zone.Hielo:
                        GameObject instBlizzard = Instantiate(blizzard, rayHit.point, Quaternion.identity);
                        Destroy(instBlizzard, blizzadTime);
                        break;
                    case Zone.Desierto:
                        GameObject instInfestation = Instantiate(infection, rayHit.point, Quaternion.identity);
                        Destroy(instInfestation, 5);
                        break;
                    case Zone.Atlantis:
                        GameObject instWave = Instantiate(wave, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);

                        Vector3 dir = rayHit.point - transform.position;
                        Quaternion lookRotation = Quaternion.LookRotation(dir);
                        Vector3 rotation = Quaternion.Lerp(instWave.transform.rotation, lookRotation, Time.deltaTime * 500).eulerAngles;
                        instWave.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

                        instWave.GetComponent<Rigidbody>().velocity = new Vector3(dir.normalized.x, 0, dir.normalized.z) * 10;

                        Destroy(instWave, 10);
                        break;
                    case Zone.Vikingos:
                        GameObject instLanza = Instantiate(lanza, rayHit.point, Quaternion.identity);
                        Destroy(instLanza, lanzaTime);
                        break;
                    case Zone.Fantasia:
                        GameObject instShield = Instantiate(shieldMagic, rayHit.point, Quaternion.identity);
                        Destroy(instShield, shieldTime);
                        break;
                    case Zone.Infierno:
                        GameObject instBall = Instantiate(fireBall, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);

                        Vector3 dir2 = rayHit.point - transform.position;
                        Quaternion lookRotation2 = Quaternion.LookRotation(dir2);
                        Vector3 rotation2 = Quaternion.Lerp(instBall.transform.rotation, lookRotation2, Time.deltaTime * 500).eulerAngles;
                        instBall.transform.rotation = Quaternion.Euler(0f, rotation2.y, 0f);

                        instBall.GetComponent<Rigidbody>().velocity = new Vector3(dir2.normalized.x, 0, dir2.normalized.z) * 10;

                        Destroy(instBall, 10);
                        break;
                }

                activateTower = false;
                restRounds = roundsToReset;
            }

            timeToWait = 0;
        }
    }
}
