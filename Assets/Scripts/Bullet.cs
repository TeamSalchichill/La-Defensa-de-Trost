using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Type { Tower, Enemy }
    public Type type;

    private Transform target;

    public GameObject impactEffect;

    public float speed = 70f;
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

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

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
        GameObject efffectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(efffectIns, 2f);

        //Destroy(target.gameObject);

        if (type == Type.Tower)
        {
            target.gameObject.GetComponent<Enemy>().health -= healthDamage;
            target.gameObject.GetComponent<Enemy>().armor -= armorDamage;

            target.gameObject.GetComponent<Enemy>().iceEffect += iceDamage;
            target.gameObject.GetComponent<Enemy>().igniteEffect += igniteDamage;
            target.gameObject.GetComponent<Enemy>().waterEffect += waterDamage;
            target.gameObject.GetComponent<Enemy>().ascentEffect += ascentDamage;
            target.gameObject.GetComponent<Enemy>().bloodEffect += bloodDamage;
            target.gameObject.GetComponent<Enemy>().transformationEffect += transformationDamage;
        }
        if (type == Type.Enemy)
        {
            target.gameObject.GetComponentInParent<Tower>().health -= (healthDamage * 5);
        }
        
        Destroy(gameObject);
    }
}
