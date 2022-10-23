using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public enum TargetType { SingleTarget, MultiTarget, AoE }
    public TargetType targetType;

    public enum AttackType { Melee, Range, Resources }
    public AttackType attackType;

    public enum CanColocate { Ground, Path }
    public CanColocate canColocate;

    public enum BulletType { Prefab, Particles }
    public BulletType bulletType;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno }
    public Zone zone;

    public enum SpecialStat { None, Health, Range, ShootSpeed, TurnSpeed, HealthDamage, IceEffect, IgniteEffect, WaterEffect, AscensionEffect, BloodEffect, CrazyEffect}
    public SpecialStat specialStat;

    public enum TargetPreference { Near, Far, MoreHealh, LessHealth, MoreFast, LessFast, MoreDamage, LessDamage, SmallEnemies, MediumEnemies, Boss,  }
    public TargetPreference targetPreference;

    GameFlow gameFlow;
    HUD_Manager hudManager;
    Generator generator;

    [Header("Components")]
    public Animator anim;

    [Header("External GameObjects")]
    public Light level5Light;
    public GameObject rangeArea;
    public Transform partToRotate;

    [Header("General")]
    public string towerName;
    public Image icon;
    [Space]
    public int price;
    public int acumulateGold = 0;
    [Space]
    public bool specialTile;
    public bool burnTile;
    [Space]
    public ParticleSystem spawnParticles;

    [Header("Stats")]
    public int healthDamage = 100;
    public int armorDamage = 0;
    [Space]
    public float range;
    public float rangeAreaOriginalScale;
    public float fireRate = 1f;
    float fireCountdown = 0f;
    public float turnSpeed = 10f;
    [Space]
    public int health;
    public int healthMax;
    public int armor;
    public int armorMax;
    [Space]
    public bool sirenitaBoost = false;

    [Header("Attack Resources")]
    public Transform target;
    public int numTargets = 1;
    [Space]
    public GameObject bullet;
    public GameObject bulletPos;
    [Space]
    public GameObject particles;
    public bool fullRotate = false;
    [Space]
    GameObject[] enemies;

    [Header("Level")]
    public int level = 1;
    public float levelMultiplier = 1.2f;
    public float levelMultiplierSpecialStat = 1.3f;
    public int levelUpPrice = 100;
    public int level5Price = 100;
    public string priceLogo = "�";
    
    [Header("States Stats")]
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
    
    [Header("Overheat")]
    public bool isBurn = false;
    public float burnEffect = 0;
    public float burnEffectPerShoot = 2;
    public float timeInOverHeat = 10;
    public ParticleSystem smokeOverHeat;
    ParticleSystem instSmoke;

    [Header("Hero - General")]
    public bool isHero;

    [Header("Hero - Hielo")]
    public GameObject iceWall;
    public bool exploteIceWall = false;
    public bool frezzeIceWall = false;

    [Header("Hero - Desierto")]
    public int curation = 50;

    [Header("Hero - Agua")]
    public GameObject singParticles;

    void Start()
    {
        gameFlow = GameFlow.instance;
        hudManager = HUD_Manager.instance;
        generator = Generator.instance;

        level5Light = GetComponentInChildren<Light>();

        healthMax = health;
        armorMax = armor;
        acumulateGold = price;

        ParticleSystem instParticle = Instantiate(spawnParticles, transform.position, transform.rotation);
        instParticle.transform.rotation = Quaternion.AngleAxis(270, Vector3.right);

        if (burnTile)
        {
            fireRate *= 1.2f;
        }

        if (rangeAreaOriginalScale == 0)
        {
            rangeAreaOriginalScale = rangeArea.transform.localScale.x;
            rangeArea.transform.localScale = new Vector3(rangeArea.transform.localScale.x * range, rangeArea.transform.localScale.y, rangeArea.transform.localScale.z * range);
            rangeArea.SetActive(false);
        }

        if (specialTile)
        {
            switch (generator.zone)
            {
                case Generator.Zone.Hielo:
                    iceDamage *= 3;
                    break;
                case Generator.Zone.Desierto:
                    igniteDamage *= 3;
                    break;
                case Generator.Zone.Atlantis:
                    waterDamage *= 3;
                    break;
                case Generator.Zone.Valhalla:

                    break;
                case Generator.Zone.Fantasia:

                    break;
                case Generator.Zone.Infierno:

                    break;
            }
        }

        if (isHero)
        {
            switch (zone)
            {
                case Zone.Hielo:
                    InvokeRepeating("Hero1SpecialAttack", 1, 20);
                    break;
                case Zone.Desierto:
                    InvokeRepeating("Hero2SpecialAttack", 1, 15);
                    break;
                case Zone.Atlantis:
                    InvokeRepeating("Hero3SpecialAttack", 1, 15);
                    break;
                case Zone.Vikingos:

                    break;
                case Zone.Fantasia:

                    break;
                case Zone.Infierno:

                    break;
            }
        }

        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void UpdateTarget()
    {
        if (attackType == AttackType.Resources)
        {
            target = MainTower.instance.transform;
            return;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
            anim.SetBool("isShoot", true);
        }
        else
        {
            target = null;
            anim.SetBool("isShoot", false);
        }
    }

    void Update()
    {
        // Comprobar vida
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // Bajar tiempo para volver a disparar
        fireCountdown -= Time.deltaTime;

        // Girar torre hacia el objetivo
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            if (fullRotate)
            {
                partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }
            else
            {
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }

        // Activar modo sobrecalentado
        if (burnEffect >= 100)
        {
            instSmoke = Instantiate(smokeOverHeat, transform.position, transform.rotation);

            isBurn = true;

            burnEffect = 0;

            if (particles != null)
            {
                particles.SetActive(false);
            }

            anim.SetBool("isShoot", false);

            Invoke("NoBurn", timeInOverHeat);
        }

        // Disparar
        if (!isBurn && fireCountdown <= 0 && target != null)
        {
            switch (attackType)
            {
                case AttackType.Melee:
                    anim.SetTrigger("doShoot");
                    break;
                case AttackType.Range:
                    switch (targetType)
                    {
                        case TargetType.SingleTarget:
                            switch (bulletType)
                            {
                                case BulletType.Prefab:
                                    anim.SetTrigger("doShoot");
                                    Shoot();
                                    break;
                                case BulletType.Particles:
                                    particles.SetActive(true);
                                    break;
                            }
                            break;
                        case TargetType.MultiTarget:
                            anim.SetTrigger("doShoot");
                            for (int i = 0; i < numTargets; i++)
                            {
                                if (i < enemies.Length)
                                {
                                    MultiShoot(enemies[i].transform);
                                }
                            }
                            break;
                        case TargetType.AoE:
                            anim.SetTrigger("doShoot");
                            RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
                            if (towerInrange.Length > 0)
                            {
                                foreach (var tower in towerInrange)
                                {
                                    if (tower.collider.gameObject.GetComponent<Enemy>())
                                    {
                                        tower.collider.gameObject.GetComponent<Enemy>().health -= healthDamage;
                                    }
                                }
                            }
                            break;
                    }
                    break;
                case AttackType.Resources:
                    if (!gameFlow.roundFinished)
                    {
                        hudManager.AddCoins(healthDamage);
                    }
                    break;
            }

            fireCountdown = 1f / fireRate;
            if (burnTile)
            {
                if (particles != null)
                {
                    burnEffect += Time.deltaTime;
                }
                else
                {
                    burnEffect += burnEffectPerShoot;
                }
            }
        }
        else
        {
            if (particles != null && target == null)
            {
                particles.SetActive(false);
            }
        }
    }

    void NoBurn()
    {
        Destroy(instSmoke);

        isBurn = false;
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

    void MultiShoot(Transform targetPos)
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
            newBullet.Seek(targetPos);
        }
    }

    void Hero1SpecialAttack()
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
            GameObject instWall = Instantiate(iceWall, groundsInRange[aux].transform.position + new Vector3(0, 1, 0), transform.rotation);
            instWall.GetComponent<Destroy>().explote = exploteIceWall;
            instWall.GetComponent<Destroy>().frezze = frezzeIceWall;
        }
    }

    void Hero2SpecialAttack()
    {
        anim.SetTrigger("doHit");

        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health += curation;
                    tower.collider.gameObject.GetComponent<Tower>().health = Mathf.Min(tower.collider.gameObject.GetComponent<Tower>().health, tower.collider.gameObject.GetComponent<Tower>().healthMax);
                }
            }
        }
    }

    void Hero3SpecialAttack()
    {
        RaycastHit[] towersInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1, LayerMask.GetMask("Tower"));
        if (towersInRange.Length > 0)
        {
            anim.SetTrigger("doHit");

            foreach (var tower in towersInRange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    if (!tower.collider.gameObject.GetComponent<Tower>().sirenitaBoost)
                    {
                        tower.collider.gameObject.GetComponent<Tower>().fireRate *= 1.25f;
                        tower.collider.gameObject.GetComponent<Tower>().sirenitaBoost = true;
                    }
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<Tower>())
        {
            hudManager.ShowTowerInfo(gameObject.GetComponent<Tower>());
        }
        else
        {
            hudManager.ShowTowerInfo(gameObject.GetComponentInChildren<Tower>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
