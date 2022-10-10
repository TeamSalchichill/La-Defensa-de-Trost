using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public enum TargetType { SingleTarget, MultiTarget, Resources }
    public TargetType targetType;

    public enum AttackType { Melee, Range }
    public AttackType attackType;

    public enum CanTarget { Ground, Air, Both }
    public CanTarget canTarget;

    public enum CanColocate { Ground, Path }
    public CanColocate canColocate;

    public enum BulletType { Prefab, Particles }
    public BulletType bulletType;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno }
    public Zone zone;

    public enum SpecialStat { None, Health, Range, ShootSpeed, TurnSpeed, HealthDamage, IceEffect, IgniteEffect, WaterEffect, AscensionEffect, BloodEffect, CrazyEffect}
    public SpecialStat specialStat;

    MainTower mainTower;
    GameFlow gameFlow;
    HUD_Manager hudManager;

    public string towerName;
    public Image icon;
    public Light level5Light;
    public GameObject rangeArea;

    [Header("Components")]
    public Animator anim;
    public GameObject particles;

    [Header("Resources")]
    public Transform target;
    public GameObject bullet;
    public GameObject bulletPos;
    public Transform partToRotate;

    [Header("General Stats")]
    public bool isHero;
    public bool specialTile;
    [Space]
    public int level = 1;
    public float levelMultiplier = 1.2f;
    public float levelMultiplierSpecialStat = 1.3f;
    public int levelUpPrice = 100;
    public int acumulateGold = 0;
    public int health;
    public int healthMax;
    public int armor;
    public int armorMax;
    [Space]
    public float range;
    public float fireRate = 1f;
    float fireCountdown = 0f;
    public float turnSpeed = 10f;
    [Space]
    public int price;
    public bool isDie = false;

    [Header("Damages")]
    public int healthDamage = 100;
    public int armorDamage = 0;
    [Space]
    [Range(0, 100)]
    public int iceDamage = 0;
    [Range(0, 100)]
    public int igniteDamage = 0;
    [Range(0, 100)]
    public int waterDamage = 0;
    [Range(0, 100)]
    public int ascentDamage = 0;
    [Range(0, 100)]
    public int bloodDamage = 0;
    [Range(0, 100)]
    public int transformationDamage = 0;

    [Header("Hero")]
    public GameObject iceWall;

    void Start()
    {
        rangeArea.transform.localScale = new Vector3(rangeArea.transform.localScale.x * range, rangeArea.transform.localScale.y, rangeArea.transform.localScale.z * range);
        rangeArea.SetActive(false);
        level5Light = GetComponentInChildren<Light>();

        mainTower = MainTower.instance;
        gameFlow = GameFlow.instance;
        hudManager = HUD_Manager.instance;

        healthMax = health;
        armorMax = armor;
        acumulateGold = price;

        if (specialTile)
        {
            switch (mainTower.zone)
            {
                case MainTower.Zone.Hielo:
                    iceDamage *= 3;
                    break;
                case MainTower.Zone.Desierto:

                    break;
                case MainTower.Zone.Atlantis:

                    break;
                case MainTower.Zone.Vikingos:

                    break;
                case MainTower.Zone.Fantasia:

                    break;
                case MainTower.Zone.Infierno:

                    break;
            }
        }

        if (isHero)
        {
            switch (zone)
            {
                case Zone.Hielo:
                    InvokeRepeating("InvokeIceWall", 1, 20);
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

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (gameFlow.nextRound)
        {
            health = healthMax;
            armor = armorMax;
        }

        if (health <= 0 && !isDie)
        {
            isDie = true;

            if (anim != null)
            {
                anim.SetTrigger("doDie");
            }

            if (!isHero)
            {
                Destroy(gameObject, 2);
            }
        }

        if (targetType == TargetType.Resources)
        {
            if (fireCountdown <= 0f)
            {
                hudManager.AddCoins(healthDamage);

                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;

        if (target == null)
        {
            if (particles != null)
            {
                particles.SetActive(false);
            }
            if (isHero && zone == Zone.Hielo)
            {
                anim.SetBool("isShoot", false);
            }

            return;
        }
        else
        {
            if (isHero && zone == Zone.Hielo)
            {
                anim.SetBool("isShoot", true);
            }
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        switch (attackType)
        {
            case AttackType.Melee:
                if (fireCountdown <= 0f)
                {
                    if (anim != null)
                    {
                        anim.SetTrigger("doShoot");
                    }

                    fireCountdown = 1f / fireRate;
                }
                break;
            case AttackType.Range:
                if (fireCountdown <= 0f)
                {
                    switch (bulletType)
                    {
                        case BulletType.Prefab:
                            if (anim != null)
                            {
                                anim.SetTrigger("doShoot");
                            }

                            Shoot();
                            fireCountdown = 1f / fireRate;
                            break;
                        case BulletType.Particles:
                            particles.SetActive(true);
                            break;
                        default:
                            break;
                    }
                }
                break;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet, bulletPos.transform.position, transform.rotation);
        Bullet newBullet = bulletGO.GetComponent<Bullet>();
        newBullet.healthDamage = healthDamage;
        newBullet.armorDamage = armorDamage;

        newBullet.iceDamage = iceDamage;
        newBullet.igniteDamage = igniteDamage;
        newBullet.waterDamage = waterDamage;
        newBullet.ascentDamage = ascentDamage;
        newBullet.bloodDamage = bloodDamage;
        newBullet.transformationDamage = transformationDamage;

        if (newBullet != null)
        {
            newBullet.Seek(target);
        }
    }

    void InvokeIceWall()
    {
        List<GameObject> groundsInRange = new List<GameObject>();

        for (int i = -10; i < 10; i+=2)
        {
            for (int j = -10; j < 10; j+=2)
            {
                RaycastHit hit1;
                RaycastHit hit2;
                if (Physics.Raycast(transform.position + new Vector3(i, 50, j), transform.TransformDirection(-Vector3.up), out hit1, 1000, LayerMask.GetMask("Ground")))
                {
                    if (!Physics.Raycast(transform.position + new Vector3(i, 50, j), transform.TransformDirection(-Vector3.up), out hit2, 1000, LayerMask.GetMask("Grass")))
                    {
                        if (!Physics.Raycast(transform.position + new Vector3(i, 50, j), transform.TransformDirection(-Vector3.up), out hit2, 1000, LayerMask.GetMask("Tower")))
                        {
                            groundsInRange.Add(hit1.collider.gameObject);
                            anim.SetTrigger("doHit");
                        }
                    }
                }
            }
        }

        int aux = Random.Range(0, groundsInRange.Count);

        if (aux >= 0 && aux < groundsInRange.Count - 1)
        {
            Instantiate(iceWall, groundsInRange[aux].transform.position + new Vector3(0, 1, 0), transform.rotation);
        }
    }

    private void OnMouseDown()
    {
        hudManager.ShowTowerInfo(gameObject.GetComponent<Tower>());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
