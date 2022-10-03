using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TargetType { SingleTarget, MultiTarget }
    public TargetType targetType;

    public enum CanTarget { Ground, Air, Both }
    public CanTarget canTarget;

    public enum CanColocate { Ground, Path }
    public CanColocate canColocate;

    [Header("Resources")]
    Transform target;
    public GameObject bullet;
    
    [Header("General Stats")]
    public int health;
    public int armor;
    [Space]
    public float range;
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    [Space]
    public int price;

    [Header("Damages")]
    public int healthDamage = 100;
    public int armorDamage = 0;
    [Space]
    public int iceDamage = 0;
    public int igniteDamage = 0;
    public int waterDamage = 0;
    public int ascentDamage = 0;
    public int bloodDamage = 0;
    public int transformationDamage = 0;

    

    void Start()
    {
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
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet, transform.position, transform.rotation);
        Bullet newBullet = bulletGO.GetComponent<Bullet>();

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
