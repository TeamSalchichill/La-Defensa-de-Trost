using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Type { Tower, Enemy }
    public Type type;

    public enum AreaDamage { Unique, AoE }
    public AreaDamage areaDamage;

    private Transform target;
    
    public GameObject[] impactEffects;
    public GameObject impactEffect;
    
    [Header("Rebotes")]
    public bool canRebote;
    public int rebotes = 0;
    public int rebotesMax = 10;

    public float speed = 70f;
    public float range = 3f;
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

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        if (target == null && canRebote)
        {
            GameObject[] enemies = GameFlow.instance.activeEnemies;
            foreach (GameObject enemy in enemies)
            {
                if (enemies.Length > 0)
                {
                    target = enemy.transform;

                    break;
                }
            }
        }
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(target.position);

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        if (!target.gameObject.GetComponent<Enemy>() && target.gameObject.GetComponent<FinalBoss>())
        {
            target.gameObject.GetComponent<FinalBoss>().health -= healthDamage;
            return;
        }

        if (target != null)
        {
            if (target.gameObject.GetComponent<Enemy>())
            {
                Enemy.Type enemyType = target.gameObject.GetComponent<Enemy>().type;

                switch (enemyType)
                {
                    case Enemy.Type.Pequeño:
                        impactEffect = impactEffects[0];
                        break;
                    case Enemy.Type.Mediano:
                        impactEffect = impactEffects[1];
                        break;
                    case Enemy.Type.Grande:
                        impactEffect = impactEffects[2];
                        break;
                }

                GameObject efffectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(efffectIns, 2f);
            }
        }
        
        switch (type)
        {
            case Type.Tower:
                target.gameObject.GetComponent<Enemy>().health -= healthDamage;
                target.gameObject.GetComponent<Enemy>().armor -= armorDamage;

                target.gameObject.GetComponent<Enemy>().iceEffect += iceDamage;
                target.gameObject.GetComponent<Enemy>().igniteEffect += igniteDamage;
                target.gameObject.GetComponent<Enemy>().waterEffect += waterDamage;
                target.gameObject.GetComponent<Enemy>().ascentEffect += ascentDamage;
                target.gameObject.GetComponent<Enemy>().bloodEffect += bloodDamage;
                target.gameObject.GetComponent<Enemy>().transformationEffect -= transformationDamage;

                break;
            case Type.Enemy:
                if (target.gameObject.GetComponentInParent<Tower>())
                {
                    target.gameObject.GetComponentInParent<Tower>().health -= (healthDamage * 5);
                }
                break;
        }

        switch (areaDamage)
        {
            case AreaDamage.Unique:
                
                break;
            case AreaDamage.AoE:
                switch (type)
                {
                    case Type.Tower:
                        RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
                        if (enemiesInRange.Length > 0)
                        {
                            foreach (var enemy in enemiesInRange)
                            {
                                enemy.collider.gameObject.GetComponent<Enemy>().health -= healthDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().armor -= armorDamage;

                                enemy.collider.gameObject.GetComponent<Enemy>().iceEffect += iceDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().igniteEffect += igniteDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().waterEffect += waterDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().ascentEffect += ascentDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().bloodEffect += bloodDamage;
                                enemy.collider.gameObject.GetComponent<Enemy>().transformationEffect += transformationDamage;
                            }
                        }
                        break;
                    case Type.Enemy:
                        RaycastHit[] towerInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
                        if (towerInRange.Length > 0)
                        {
                            foreach (var tower in towerInRange)
                            {
                                if (tower.collider.gameObject.GetComponent<Tower>())
                                {
                                    tower.collider.gameObject.GetComponent<Tower>().health -= (healthDamage * 5);
                                }
                            }
                        }
                        break;
                }
                break;
        }

        if (!canRebote)
        {
            Destroy(gameObject);
        }
        else
        {
            if (rebotes >= rebotesMax)
            {
                Destroy(gameObject);
            }

            GameObject[] enemies = GameFlow.instance.activeEnemies;
            foreach (GameObject enemy in enemies)
            {
                if (enemies.Length > 0)
                {
                    if (enemy.transform != target)
                    {
                        target = enemy.transform;

                        break;
                    }
                }
            }

            rebotes++;
        }
    }
}
