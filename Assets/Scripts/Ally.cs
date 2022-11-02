using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public NavMeshAgent nav;

    [Header("NavMesh")]
    public GameObject target;

    [Header("Stats")]
    public float damage = 250;
    public int range = 10;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.1f, 0.55f);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 1)
        {
            if (target != null)
            {
                target.GetComponent<Enemy>().health -= damage;

                Destroy(gameObject, 1);
            }
        }
    }

    void UpdateTarget()
    {
        RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length > 0)
        {
            target = enemiesInRange[0].collider.gameObject;
            nav.destination = enemiesInRange[0].transform.position;
        }
    }
}
