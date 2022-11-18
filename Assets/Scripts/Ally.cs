using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    public enum MoveType { Ground, Air }
    public MoveType moveType;

    [Header("Components")]
    public Animator anim;
    public NavMeshAgent nav;

    [Header("NavMesh")]
    public GameObject target;

    [Header("Stats")]
    public float damage = 250;
    public int range = 10;
    public bool canInfect;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.1f, 0.55f);
    }

    void Update()
    {
        if (target)
        {
            if (moveType == MoveType.Air)
            {
                Vector3 moveVec = (target.transform.position - transform.position).normalized;
                transform.LookAt(transform.position + moveVec);
                transform.position += moveVec * 5 * Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < 1)
            {
                if (target != null)
                {
                    if (canInfect)
                    {
                        target.GetComponent<Enemy>().infectationMode = true;

                        Destroy(gameObject);
                    }
                    else
                    {
                        target.GetComponent<Enemy>().health -= damage;

                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void UpdateTarget()
    {
        if (target)
        {
            return;
        }

        RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length > 0)
        {
            target = enemiesInRange[0].collider.gameObject;

            switch (moveType)
            {
                case MoveType.Ground:
                    nav.destination = enemiesInRange[0].transform.position;
                    break;
                case MoveType.Air:
                    Vector3 moveVec = (enemiesInRange[0].transform.position - transform.position).normalized;
                    transform.LookAt(transform.position + moveVec);
                    transform.position += moveVec * 5 * Time.deltaTime;
                    break;
            }
        }
    }
}
