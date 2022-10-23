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
    public NavMeshAgent nav;

    [Header("Target")]
    public Transform target;
    public bool miniTowerFound = false;
    GameObject miniMainTowerFound;

    [Header("General")]
    public string enemyName;
    public GameObject skull;
    public ParticleSystem deadParticle;

    [Header("Stats")]
    public int damage;//
    public float speed;
    public float normalSpeed;//
    public int range;//
    public float health = 100;
    public float healthMax = 0;//
    public int armor = 0;
    public int gold;//
    [Space]
    public float iceEffect = 0;
    public float igniteEffect = 0;
    public float waterEffect = 0;
    public float ascentEffect = 0;
    public float bloodEffect = 0;
    public float transformationEffect = 0;
    [Space]
    public bool infectationMode = false;

    [Header("Stats multiplier")]
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
    public bool poseidonBoost = false;
    [Space(30)]
    [Header("External GameObjects")]
    [Header("Health Bar")]
    public GameObject HealthBar;
    float initialScaleX;

    public Material healthBarGreen;
    public Material healthBarYellow;
    public Material healthBarRed;
    
    [Header("Water Effect")]
    public GameObject waterParticles;
    bool isWaterEffect = false;
    int waterEffectTime = 2;

    [Space(30)]
    [Header("Boss - General")]
    public bool isBoss;
    bool isAttack = false;

    [Header("Boss - Hielo")]
    public GameObject bullet;
    public GameObject bulletPos;
    [Space]
    public GameObject goblins;
    public GameObject mamut;
    [Space]
    public float attackRate = 5;
    public float invokeGloblinsRate = 10;
    public float invokeMamutRate = 20;

    [Header("Boss - Desierto")]
    public float healthRate = 10;
    public float areaAtacckRate = 10;

    [Header("Boss - Agua")]
    public float spearAttackRate = 5;
    public float speedBoostRate = 10;
    
    void Start()
    {
        gameFlow = GameFlow.instance;
        mainTower = MainTower.instance;
        generator = Generator.instance;

        nav = GetComponent<NavMeshAgent>();
        nav.destination = target.position;
        nav.speed = normalSpeed;

        waterParticles.SetActive(false);

        healthMax = health;
        initialScaleX = HealthBar.transform.localScale.x;

        Invoke("AutoDestroy", 300);

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
                    InvokeRepeating("Zone3Attack1", 1, speedBoostRate);
                    InvokeRepeating("Zone3Attack2", 3, spearAttackRate);
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
            InvokeRepeating("UpdateTarget", 1, 5);
        }
    }

    void UpdateTarget()
    {
        if (!infectationMode)
        {
            if (!miniTowerFound)
            {
                miniTowerFound = false;

                RaycastHit[] miniMainTowerInRange = Physics.SphereCastAll(transform.position, 25, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
                if (miniMainTowerInRange.Length > 0)
                {
                    foreach (var miniMainTower in miniMainTowerInRange)
                    {
                        if (miniMainTower.collider.gameObject.tag == "MiniMainTower")
                        {
                            miniTowerFound = true;

                            nav.destination = miniMainTower.collider.gameObject.transform.position;

                            miniMainTowerFound = miniMainTower.collider.gameObject;

                            break;
                        }
                    }
                }

                if (!miniTowerFound)
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
            else
            {
                if (Vector3.Distance(transform.position, miniMainTowerFound.transform.position) < 5)
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

                    miniMainTowerFound.GetComponent<MiniMainTower>().health--;

                    Destroy(gameObject);
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

        iceEffect -= (Time.deltaTime * 3);
        iceEffect = Mathf.Max(iceEffect, 0);
        iceEffect = Mathf.Min(iceEffect, 50);
        
        igniteEffect -= (Time.deltaTime * 3);
        igniteEffect = Mathf.Max(igniteEffect, 0);
        health -= (igniteEffect * 0.01f);
        if (igniteEffect >= 100)
        {
            health -= igniteEffect;
            igniteEffect = 0;
        }

        waterEffect -= (Time.deltaTime * 3);
        waterEffect = Mathf.Max(waterEffect, 0);
        if (waterEffect >= 100)
        {
            waterParticles.SetActive(true);
            speed = 0;
            isWaterEffect = true;
            Invoke("DisableWaterEffect", waterEffectTime);
        }

        if (!isWaterEffect)
        {
            if (isBoss)
            {
                if (!isAttack)
                {
                    speed = (normalSpeed * ((100 - iceEffect) / 100));
                }
            }
            else
            {
                speed = (normalSpeed * ((100 - iceEffect) / 100));
            }
        }
        nav.speed = speed * gameFlow.newSpeed;

        if (infectationMode)
        {
            InfectationMode();
        }
        else if (targetPreference == TargetPreference.MainTower)
        {
            if (isActiveAndEnabled)
            {
                nav.destination = target.position;
            }
        }
    }

    void InfectationMode()
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
                    enemiesInRange[0].collider.GetComponent<Enemy>().health -= (damage * 10);
                    anim.SetTrigger("doHit");
                }
            }
            else
            {
                if (gameObject != null)
                {
                    nav.destination = target.position;
                }
            }
        }
        else
        {
            nav.destination = target.position;
        }
    }

    void DisableWaterEffect()
    {
        waterParticles.SetActive(false);
        waterEffect = 0;
        speed = normalSpeed;
        isWaterEffect = false;
        waterEffectTime = 2;
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
        speed = 0;

        isAttack = true;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(goblins, transform.position + (transform.forward * 2), transform.rotation);
            gameFlow.enemiesLeft1++;
            yield return new WaitForSeconds(0.1f);
        }

        canMove();
    }

    void Zone1Attack3()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        isAttack = true;

        Instantiate(mamut, transform.position + (transform.forward * 3), transform.rotation);
        gameFlow.enemiesLeft2++;

        Invoke("canMove", 1.15f);
    }

    void Zone2Attack1()
    {
        anim.SetTrigger("doInvoke");
        speed = 0;

        health += 200;
        health = Mathf.Min(health, healthMax);

        isAttack = true;
        Invoke("canMove", 1.15f);
    }

    void Zone2Attack2()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone3Attack1()
    {
        RaycastHit[] enemiesInrange = Physics.SphereCastAll(transform.position, range, transform.forward, 1, LayerMask.GetMask("Enemy"));
        if (enemiesInrange.Length > 0)
        {
            anim.SetTrigger("doInvoke");
            speed = 0;

            foreach (var enemy in enemiesInrange)
            {
                if (!enemy.collider.gameObject.GetComponent<Enemy>().poseidonBoost)
                {
                    enemy.collider.gameObject.GetComponent<Enemy>().normalSpeed *= 1.25f;
                    enemy.collider.gameObject.GetComponent<Enemy>().poseidonBoost = true;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone3Attack2()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void canMove()
    {
        isAttack = false;
        speed = normalSpeed;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Tower")
        {
            if (collision.collider.GetComponent<Tower>())
            {
                if (collision.collider.GetComponent<Tower>().canColocate == Tower.CanColocate.Path)
                {
                    collision.collider.gameObject.GetComponentInParent<Tower>().health -= damage;
                }
            }
        }
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

        if (other.tag == "Wave")
        {
            waterEffect = 120;
            waterEffectTime = 3;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Damage")
        {
            health -= (other.gameObject.GetComponentInParent<Tower>().healthDamage * 0.1f);
            iceEffect += ((other.gameObject.GetComponentInParent<Tower>().iceDamage * 0.1f) * iceResistence);
            iceEffect = Mathf.Min(iceEffect, 50);

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
                    nav.speed = speed * 0.5f;
                    break;
                case Generator.Zone.Desierto:
                    igniteResistence *= 2;
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
            health -= 5;
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

    void NoInfectationMode()
    {
        infectationMode = false;
    }

    void AutoDestroy()
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

        Destroy(gameObject);
    }
}
