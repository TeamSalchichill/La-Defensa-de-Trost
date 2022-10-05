using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        target.gameObject.GetComponent<Enemy>().health -= healthDamage;
        target.gameObject.GetComponent<Enemy>().armor -= healthDamage;

        target.gameObject.GetComponent<Enemy>().iceEffect += healthDamage;
        target.gameObject.GetComponent<Enemy>().igniteEffect += healthDamage;
        target.gameObject.GetComponent<Enemy>().waterEffect += healthDamage;
        target.gameObject.GetComponent<Enemy>().ascentEffect += healthDamage;
        target.gameObject.GetComponent<Enemy>().bloodEffect += healthDamage;
        target.gameObject.GetComponent<Enemy>().transformationEffect += healthDamage;

        Destroy(gameObject);
    }
}
