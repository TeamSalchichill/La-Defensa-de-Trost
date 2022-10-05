using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TargetType { SingleTarget, MultiTarget }
    public TargetType targetType;

    public enum AttackType { Melee, Range }
    public AttackType attackType;

    public enum CanTarget { Ground, Air, Both }
    public CanTarget canTarget;

    public enum CanColocate { Ground, Path }
    public CanColocate canColocate;

    public enum BulletType { Prefab, Particles }
    public BulletType bulletType;

    MainTower mainTower;

    [Header("Components")]
    public Animator anim;
    public GameObject particles;

    [Header("Resources")]
    public Transform target;
    public GameObject bullet;
    public GameObject bulletPos;
    public Transform partToRotate;

    [Header("General Stats")]
    public bool specialTile;
    [Space]
    public int health;
    public int armor;
    [Space]
    public float range;
    public float fireRate = 1f;
    float fireCountdown = 0f;
    public float turnSpeed = 10f;
    [Space]
    public int price;

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

    void Start()
    {
        mainTower = MainTower.instance;

        if (specialTile)
        {
            switch (mainTower.zone)
            {
                case MainTower.Zone.None:
                    
                    break;
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
        if (health <= 0)
        {
            if (anim != null)
            {
                anim.SetTrigger("doDie");
            }
            
            Destroy(gameObject);
        }

        if (target == null)
        {
            if (particles != null)
            {
                particles.SetActive(false);
            }

            return;
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

        fireCountdown -= Time.deltaTime;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
