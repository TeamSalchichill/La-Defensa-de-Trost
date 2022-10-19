using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Animator anim;

    public bool explote;
    public bool frezze;

    void Start()
    {
        anim = GetComponent<Animator>();

        Invoke("AutoDestroyAnim", 9);

        Invoke("AutoDestroyGO", 10);
    }

    void Update()
    {
        if (frezze)
        {
            RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, 4, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
            if (enemiesInRange.Length > 0)
            {
                foreach (var enemy in enemiesInRange)
                {
                    enemy.collider.gameObject.GetComponent<Enemy>().iceEffect += 0.2f;
                }
            }
        }
    }

    void AutoDestroyAnim()
    {
        anim.SetTrigger("doDie");
    }
    void AutoDestroyGO()
    {
        if (explote)
        {
            RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, 4, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
            if (enemiesInRange.Length > 0)
            {
                foreach (var enemy in enemiesInRange)
                {
                    enemy.collider.gameObject.GetComponent<Enemy>().health -= 100;
                }
            }
        }

        Destroy(gameObject);
    }
}
