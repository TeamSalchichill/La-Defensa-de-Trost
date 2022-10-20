using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum Type { Pequeño, Mediano, Grande }
    public Type type;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno }
    public Zone zone;

    public enum TargetPreference { MainTower, OtherTowers }
    public TargetPreference targetPreference;

    GameFlow gameFlow;
    MainTower mainTower;
    Generator generator;

    [Header("Components")]
    public Animator anim;
    public Transform target;
    public NavMeshAgent nav;
    [Space]
    public GameObject skull;
    public ParticleSystem deadParticle;
    
    [Header("States")]
    public string enemyName;
    public int damage;//
    public int gold;//
    public float speed;
    public int range;//
    public float normalSpeed;//
    public float health = 100;
    public float healthMax = 0;//
    public int armor = 0;
    [Space]
    public float iceEffect = 0;
    public float igniteEffect = 0;
    public float waterEffect = 0;
    public float ascentEffect = 0;
    public float bloodEffect = 0;
    public float transformationEffect = 0;

    public bool infectationMode = false;

    [Header("States multiplier")]
    [Range(0, 1)]
    public float healthResistence = 0;
    [Range(0, 1)]
    public float armorResistence = 0;
    [Space]
    [Range(0, 1)]
    public float iceResistence = 0;
    [Range(0, 1)]
    public float igniteResistence = 0;
    [Range(0, 1)]
    public float waterResistence = 0;
    [Range(0, 1)]
    public float ascentResistence = 0;
    [Range(0, 1)]
    public float bloodResistence = 0;
    [Range(0, 1)]
    public float transformationResistence = 0;

    [Header("Boss")]
    public bool isBoss;

    public GameObject bullet;
    public GameObject bulletPos;

    public GameObject goblins;
    public GameObject mamut;

    public float attackRate = 5;
    public float invokeGloblinsRate = 10;
    public float invokeMamutRate = 20;
    [Space]
    public float healthRate = 10;
    public float areaAtacckRate = 10;

    [Header("Health Bar")]
    public GameObject HealthBar;
    float initialScaleX;

    public Material healthBarGreen;
    public Material healthBarYellow;
    public Material healthBarRed;

    void Start()
    {
        healthMax = health;
        initialScaleX = HealthBar.transform.localScale.x;

        gameFlow = GameFlow.instance;
        mainTower = MainTower.instance;
        generator = Generator.instance;

        nav = GetComponent<NavMeshAgent>();
        nav.destination = target.position;

        nav.speed = normalSpeed;

        Destroy(gameObject, 120);

        if (type == Type.Grande)
        {
            switch (zone)
            {
                case Zone.Hielo:
                    InvokeRepeating("Zone1Attack1", 1, attackRate);
                    InvokeRepeating("Zone1Attack2", 3.5f, invokeGloblinsRate);
                    InvokeRepeating("Zone1Attack3", 3.5f, invokeMamutRate);
                    break;
                case Zone.Desierto:
                    InvokeRepeating("Zone2Attack1", 1, healthRate);
                    InvokeRepeating("Zone2Attack2", 6, areaAtacckRate);
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

        if (targetPreference == TargetPreference.OtherTowers)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }

    void UpdateTarget()
    {
        if (!infectationMode)
        {
            RaycastHit[] miniMainTowerInRange = Physics.SphereCastAll(transform.position, 40, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
            if (miniMainTowerInRange.Length > 0)
            {
                foreach (var miniMainTower in miniMainTowerInRange)
                {
                    if (miniMainTower.collider.gameObject.tag == "MiniMainTower")
                    {
                        nav.destination = miniMainTower.collider.gameObject.transform.position;

                        if (Vector3.Distance(transform.position, miniMainTower.collider.gameObject.transform.position) < 5)
                        {
                            switch (type)
                            {
                                case (Type.Pequeño):
                                    gameFlow.enemiesLeft1--;
                                    break;
                                case (Type.Mediano):
                                    gameFlow.enemiesLeft2--;
                                    break;
                                case (Type.Grande):
                                    gameFlow.enemiesLeft3--;
                                    break;
                            }

                            miniMainTower.collider.gameObject.GetComponent<MiniMainTower>().health--;

                            Destroy(gameObject);
                        }

                        break;
                    }
                }
            }
            else
            {
                RaycastHit[] towerInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
                if (towerInRange.Length > 0)
                {
                    if (towerInRange[0].collider.GetComponent<Tower>())
                    {
                        if (towerInRange[0].collider.GetComponent<Tower>().health > 0)
                        {
                            if (!towerInRange[0].collider.GetComponent<Tower>().isHero)
                            {
                                nav.destination = towerInRange[0].transform.position;
                                towerInRange[0].collider.GetComponent<Tower>().health -= (damage * 3);
                                anim.SetTrigger("doHit");
                            }
                        }
                    }
                }
                else
                {
                    nav.destination = target.position;
                }
            }
        }
    }

    void Update()
    {
        float newScaleX = initialScaleX * (health / healthMax);
        float newPosX = (initialScaleX - newScaleX) / 2;
        HealthBar.transform.localScale = new Vector3(newScaleX, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
        HealthBar.transform.localPosition = new Vector3(newPosX, HealthBar.transform.localPosition.y, HealthBar.transform.localPosition.z);

        float healthNormalized = (health / healthMax) * 100;
        if (healthNormalized > 50)
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarGreen;
        }
        else if (healthNormalized > 20)
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarYellow;
        }
        else
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarRed;
        }

        if (health < 0)
        {
            gameFlow.coins += gold;

            switch (type)
            {
                case (Type.Pequeño):
                    gameFlow.enemiesLeft1--;
                    break;
                case (Type.Mediano):
                    gameFlow.enemiesLeft2--;
                    break;
                case (Type.Grande):
                    gameFlow.enemiesLeft3--;
                    break;
            }

            GameObject instSkull = Instantiate(skull, transform.position + new Vector3(0, 1, 0), transform.rotation);
            instSkull.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);

            Instantiate(deadParticle, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        iceEffect -= (Time.deltaTime * 5);
        iceEffect = Mathf.Max(iceEffect, 0);
        iceEffect = Mathf.Min(iceEffect, 50);
        speed = (normalSpeed * ((100 - iceEffect) / 100));
        nav.speed = speed;

        igniteEffect -= (Time.deltaTime * 5);
        igniteEffect = Mathf.Max(igniteEffect, 0);
        health -= (igniteEffect * 0.01f);
        if (igniteEffect >= 100)
        {
            health -= igniteEffect;
            igniteEffect = 0;
        }

        if (infectationMode)
        {
            RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, 50, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
            if (enemiesInRange.Length > 0)
            {
                int enemyID = -1;

                for (int i = 0; i < enemiesInRange.Length; i++)
                {
                    if (enemiesInRange[i].collider.gameObject != gameObject)
                    {
                        enemyID = i;
                        break;
                    }
                }

                if (enemyID != -1)
                {
                    if (nav.isActiveAndEnabled)
                    {
                        nav.destination = enemiesInRange[0].transform.position;
                    }

                    if (Vector3.Distance(transform.position, enemiesInRange[0].transform.position) < range)
                    {
                        enemiesInRange[0].collider.GetComponent<Enemy>().health -= (damage * 3);
                        anim.SetTrigger("doHit");
                    }
                }
                else
                {
                    nav.destination = target.position;
                }
            }
            else
            {
                nav.destination = target.position;
            }
        }
        else if (targetPreference == TargetPreference.MainTower)
        {
            if (isActiveAndEnabled)
            {
                nav.destination = target.position;
            }
            //nav.destination = target.position;
        }
    }

    void Zone1Attack1()
    {
        RaycastHit[] rayHitsPlayers = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
        if (rayHitsPlayers.Length > 0)
        {
            anim.SetTrigger("doHit");

            GameObject bulletGO = Instantiate(bullet, bulletPos.transform.position, transform.rotation);
            Bullet newBullet = bulletGO.GetComponent<Bullet>();

            newBullet.healthDamage = damage;

            newBullet.Seek(rayHitsPlayers[0].transform);
        }
    }
    void Zone1Attack2()
    {
        StartCoroutine(SpawnGoblins());
    }

    IEnumerator SpawnGoblins()
    {
        anim.SetTrigger("doHit");

        for (int i = 0; i < 4; i++)
        {
            Instantiate(goblins, transform.position + (transform.forward * 2), transform.rotation);
            gameFlow.enemiesLeft1++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Zone1Attack3()
    {
        anim.SetTrigger("doHit");

        Instantiate(mamut, transform.position + (transform.forward * 3), transform.rotation);
        gameFlow.enemiesLeft2++;
    }

    void Zone2Attack1()
    {
        anim.SetTrigger("doInvoke");
        speed = 0;

        health += 200;
        health = Mathf.Min(health, healthMax);

        Invoke("canMove", 1.15f);
    }

    void Zone2Attack2()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }
        }

        Invoke("canMove", 1.15f);
    }

    void canMove()
    {
        speed = normalSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainTower")
        {
            switch (type)
            {
                case (Type.Pequeño):
                    gameFlow.enemiesLeft1--;
                    break;
                case (Type.Mediano):
                    gameFlow.enemiesLeft2--;
                    break;
                case (Type.Grande):
                    gameFlow.enemiesLeft3--;
                    mainTower.health = -1;
                    break;
            }

            MainTower.instance.health--;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "TowerPath")
        {
            //other.gameObject.GetComponentInParent<Tower>().health -= damage;
        }
        if (other.tag == "Damage")
        {
            health -= (other.gameObject.GetComponentInParent<Tower>().healthDamage * 0.1f);
            iceEffect += ((other.gameObject.GetComponentInParent<Tower>().iceDamage * 0.1f) * iceResistence);
            iceEffect = Mathf.Min(iceEffect, 50);

            other.gameObject.GetComponentInParent<Tower>().health -= damage;

            if (anim != null && !isBoss)
            {
                anim.SetBool("isHit", true);
            }
        }
        else
        {
            if (anim != null && !isBoss)
            {
                anim.SetBool("isHit", false);
            }
        }

        if (other.tag == "SpecialGround")
        {
            switch (generator.zone)
            {
                case Generator.Zone.Hielo:
                    float speedAux = speed;
                    nav.speed = speedAux * 0.5f;
                    break;
                case Generator.Zone.Desierto:

                    break;
                case Generator.Zone.Atlantis:

                    break;
                case Generator.Zone.Valhalla:

                    break;
                case Generator.Zone.Fantasia:

                    break;
                case Generator.Zone.Infierno:

                    break;
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Damage")
        {
            health -= 1;
            iceEffect += (1 * iceResistence);
            iceEffect = Mathf.Min(iceEffect, 50);
        }
        if (other.tag == "InstaIce")
        {
            iceEffect = 105;
        }
        if (other.tag == "Infectation")
        {
            infectationMode = true;

            Invoke("NoInfectationMode", mainTower.infectationDuration);
        }
    }
    /*
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(collision.collider.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }
    }
    */

    void NoInfectationMode()
    {
        infectationMode = false;
    }
}
