using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [Header("Componentes")]
    public Animator anim;

    [Header("Stats")]
    public int lifes;
    public float health;
    public int range;

    [Header("Abilities GameObject")]
    public GameObject[] bosses;
    public GameObject skeletons;
    public GameObject magicBall;
    public GameObject energyRay;

    [Header("Abilities Rate")]
    public int bossesRate;
    public int skeletonsRate;
    public int magicBallRate;
    public int energyRayRate;

    [Header("Others variables")]
    int numBossesInvoked = 0;
    public int numBossesKilled = 0;
    public int numSkeletonsToInvoke;
    public int timeMagicBall;
    GameObject selectedTower;
    GameObject instMagicBall;
    public int damageEnergyRay;

    [Header("Others")]
    public GameObject winScreen;

    bool dead = false;

    void Start()
    {
        GameFlow.instance.enemiesLeft3 += 6;

        InvokeRepeating("InvokeBoss", 1, bossesRate);
        InvokeRepeating("InvokeSkeletons", 3, skeletonsRate);
        InvokeRepeating("InvokeMagicBall", 5, magicBallRate);
        InvokeRepeating("InvokeEnergyRay", 7, energyRayRate);
    }

    void Update()
    {
        if (GameFlow.instance.enemiesLeft3 > 0)
        {
            health = Mathf.Max(health, 1000);
        }
        else if (!dead)
        {
            dead = true;

            anim.SetTrigger("doDie");

            Invoke("AutoWin", 3);
        }
    }

    void AutoWin()
    {
        HUD_Manager.instance.endScreen.SetActive(true);
    }

    void InvokeBoss()
    {
        if (numBossesInvoked < 6)
        {
            anim.SetTrigger("doBoss");

            Instantiate(bosses[numBossesInvoked], new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation);
            numBossesInvoked++;
        }
    }

    void InvokeSkeletons()
    {
        anim.SetTrigger("doSkeleton");

        StartCoroutine(CoInvokeSkeletons());
    }
    IEnumerator CoInvokeSkeletons()
    {
        for (int i = 0; i < numSkeletonsToInvoke; i++)
        {
            Instantiate(skeletons, transform.position, transform.rotation);
            GameFlow.instance.enemiesLeft2++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void InvokeMagicBall()
    {
        int moreKills = -1;

        GameObject[] towers = GameFlow.instance.towers;
        if (towers.Length > 0)
        {
            anim.SetTrigger("doMagicBall");

            foreach (var tower in towers)
            {
                if (tower)
                {
                    if (tower.GetComponent<Tower>())
                    {
                        if (tower.GetComponent<Tower>().kills > moreKills)
                        {
                            moreKills = tower.GetComponent<Tower>().kills;
                            selectedTower = tower;
                        }
                    }
                }
            }

            instMagicBall = Instantiate(magicBall, selectedTower.transform.position + new Vector3(0, 2, 0), transform.rotation);

            selectedTower.GetComponent<Tower>().fireRate /= 1000;

            Invoke("ResetTower", timeMagicBall);
        }
    }
    void ResetTower()
    {
        Destroy(instMagicBall);

        if (selectedTower != null)
        {
            selectedTower.GetComponent<Tower>().fireRate *= 1000;
        }
    }

    void InvokeEnergyRay()
    {
        anim.SetTrigger("doEnergyBall");

        GameObject instEnergyRay = Instantiate(energyRay, transform.position, transform.rotation);
        instEnergyRay.transform.localScale *= range;
        
        GameObject[] towers = GameFlow.instance.towers;
        if (towers.Length > 0)
        {
            foreach (var tower in towers)
            {
                if (tower.GetComponent<Tower>())
                {
                    if (Vector3.Distance(transform.position, tower.transform.position) <= range)
                    {
                        tower.GetComponent<Tower>().health -= damageEnergyRay;
                    }
                }
            }
        }

        Destroy(instEnergyRay, 5);
    }
}
