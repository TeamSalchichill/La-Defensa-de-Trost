using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum Type { Pequeño, Mediano, Grande }
    public Type type;

    public enum Zone { None, Hielo, Desierto, Atlantis, Vikingos, Fantasia, Infierno, FinalBoss }
    public Zone zone;

    public enum TargetPreference { MainTower, OtherTowers }
    public TargetPreference targetPreference;

    public enum Terrain { Ground, Air }
    public Terrain terrain;

    GameFlow gameFlow;
    MainTower mainTower;
    Generator generator;
    CameraController camera;

    [Header("Components")]
    public Animator anim;
    public NavMeshAgent nav;

    [Header("Target")]
    public Transform target;
    public bool miniTowerFound = false;
    public bool towerFound = false;
    GameObject miniMainTowerFound;
    GameObject normaltowerFound;
    public Vector3 targetPos;
    public float targetSpeed;
    public int mapPosId;
    public Vector3 tileTargetPos = Vector3.zero;
    public float tileTargetDist = 0;
    public int bugCount = 0;
    public GameObject targetGO = null;

    float timerToFoundNewTile = 0;
    bool canFindNextTile = true;

    [Header("General")]
    public string enemyName;
    public Sprite icon;
    public GameObject skull;
    public ParticleSystem deadParticle;

    [Header("Stats")]
    public int damage;
    public float speed;
    public float normalSpeed;
    public int range;
    public float health = 100;
    public float healthMax = 0;
    public int armor = 0;
    public int gold;
    [Space]
    public float iceEffect = 0;
    public float igniteEffect = 0;
    public float waterEffect = 0;
    public float ascentEffect = 0;
    public float bloodEffect = 0;
    public float transformationEffect = 0;
    [Space]
    public bool infectationMode = false;
    public bool canBoom = false;
    [Space]
    public bool attackTowers;

    [Header("Stats multiplier")]
    [Range(0, 1)]
    public float healthResistence = 0;
    [Range(0, 1)]
    public float armorResistence = 0;
    [Space]
    [Range(0, 1)]
    public float iceResistence = 0;
    [Range(0, 1)]
    public float igniteResistence = 0;
    [Range(0, 1)]
    public float waterResistence = 0;
    [Range(0, 1)]
    public float ascentResistence = 0;
    [Range(0, 1)]
    public float bloodResistence = 0;
    [Range(0, 1)]
    public float transformationResistence = 0;
    public bool poseidonBoost = false;
    [Space(30)]
    [Header("External GameObjects")]
    [Header("Health Bar")]
    public GameObject HealthBar;
    float initialScaleX;

    public Material healthBarGreen;
    public Material healthBarYellow;
    public Material healthBarRed;
    
    [Header("Water Effect")]
    public GameObject waterParticles;
    bool isWaterEffect = false;
    int waterEffectTime = 2;

    [Space(30)]
    [Header("Boss - General")]
    public bool isBoss;
    bool isAttack = false;

    [Header("Boss - Hielo")]
    public GameObject bullet;
    public GameObject bulletPos;
    [Space]
    public GameObject goblins;
    public GameObject mamut;
    [Space]
    public float attackRate = 5;
    public float invokeGloblinsRate = 10;
    public float invokeMamutRate = 20;

    [Header("Boss - Desierto")]
    public float healthRate = 10;
    public float areaAtacckRate = 10;

    [Header("Boss - Agua")]
    public float spearAttackRate = 5;
    public float speedBoostRate = 10;

    [Header("Boss - Valhalla")]
    public float invokeEnemiesRate = 5;
    public float biteAttackRate = 7;
    public GameObject dogs;

    [Header("Boss - Forest")]
    public float hitAttackRate = 7;
    public int numEnemiesDead = 0;

    [Header("Boss - Hell")]
    public float invokeDeadEnemiesRate = 5;
    public float fireSpearAttackRate = 7;
    public GameObject fireBlins;

    [Header("Boss final")]
    public GameObject finalBoss;
    
    [Header("Particles")]
    public GameObject infectionParticle;
    public GameObject hitParticle;
    public GameObject torbellinoParticle;
    
    void Start()
    {
        gameFlow = GameFlow.instance;
        mainTower = MainTower.instance;
        generator = Generator.instance;

        mapPosId = 1000000;

        if (terrain == Terrain.Ground)
        {
            nav = GetComponent<NavMeshAgent>();
            if (nav.isOnNavMesh)
            {
                nav.destination = target.transform.position;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 1000, LayerMask.GetMask("Ground")))
                {
                    GameObject firstTroundTile = hit.collider.gameObject;

                    mapPosId = firstTroundTile.GetComponent<MapInfo>().id;
                    tileTargetPos = firstTroundTile.transform.position;
                    targetGO = firstTroundTile;
                }
            }
            else
            {
                Dead();
            }
            nav.speed = normalSpeed;
        }
        else
        {
            transform.position += new Vector3(0, 3, 0);
        }
        
        waterParticles.SetActive(false);

        healthMax = health;
        initialScaleX = HealthBar.transform.localScale.x;

        float healthMultiplier = ((gameFlow.round + 1) / 3);
        healthMultiplier = Mathf.Max(healthMultiplier, 1);

        switch (type)
        {
            case Type.Pequeño:
                gold = 30;
                normalSpeed = 2;
                health *= healthMultiplier;
                healthMax *= healthMultiplier;
                break;
            case Type.Mediano:
                gold = 80;
                normalSpeed = 1.5f;
                health *= healthMultiplier;
                healthMax *= healthMultiplier;
                break;
            case Type.Grande:
                gold = 1500;
                normalSpeed = 1;
                health *= healthMultiplier;
                healthMax *= healthMultiplier;
                break;
        }
        
        Invoke("AutoDestroy", 300);

        if (type == Type.Grande)
        {
            switch (zone)
            {
                case Zone.None:
                    InvokeRepeating("Zone0Attack1", 1, 10);
                    break;
                case Zone.Hielo:
                    InvokeRepeating("Zone1Attack1", 1, attackRate);
                    InvokeRepeating("Zone1Attack2", 3.5f, invokeGloblinsRate);
                    InvokeRepeating("Zone1Attack3", 3.5f, invokeMamutRate);
                    break;
                case Zone.Desierto:
                    InvokeRepeating("Zone2Attack1", 1, healthRate);
                    InvokeRepeating("Zone2Attack2", 6, areaAtacckRate);
                    break;
                case Zone.Atlantis:
                    InvokeRepeating("Zone3Attack1", 1, speedBoostRate);
                    InvokeRepeating("Zone3Attack2", 3, invokeDeadEnemiesRate);
                    break;
                case Zone.Vikingos:
                    InvokeRepeating("Zone4Attack1", 1, biteAttackRate);
                    InvokeRepeating("Zone4Attack2", 5, invokeEnemiesRate);
                    break;
                case Zone.Fantasia:
                    InvokeRepeating("Zone5Attack1", 6, hitAttackRate);
                    InvokeRepeating("Zone5Attack2", 8, hitAttackRate);
                    break;
                case Zone.Infierno:
                    InvokeRepeating("Zone6Attack1", 1, fireSpearAttackRate);
                    InvokeRepeating("Zone6Attack2", 5, invokeEnemiesRate);
                    break;
                case Zone.FinalBoss:

                    break;
            }
        }

        if (terrain == Terrain.Ground)
        {
            InvokeRepeating("UpdateTargetTile", 0.15f, 2.0f);

            if (nav.isActiveAndEnabled)
            {
                nav.destination = target.transform.position;
            }
        }
        else
        {
            Vector3 moveVec = new Vector3(target.position.x - transform.position.x, 0 - transform.position.y, target.position.z - transform.position.z).normalized;
            transform.LookAt(transform.position + moveVec);
            transform.position += moveVec * speed * Time.deltaTime;
        }
    }

    void UpdateTargetTile()
    {
        targetSpeed = nav.speed;

        tileTargetDist = Vector3.Distance(transform.position, tileTargetPos);

        if (nav.speed == 0)
        {
            nav.speed = normalSpeed;
        }

        if (!infectationMode)
        {
            if (!miniTowerFound && type == Type.Mediano)
            {
                float distanceToMiniMainTower = Mathf.Infinity;

                RaycastHit[] miniMainTowerInRange = Physics.SphereCastAll(transform.position, 20, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
                if (miniMainTowerInRange.Length > 0)
                {
                    foreach (var miniMainTower in miniMainTowerInRange)
                    {
                        if (miniMainTower.collider.gameObject.tag == "MiniMainTower")
                        {
                            miniTowerFound = true;

                            if (Vector3.Distance(transform.position, miniMainTower.collider.gameObject.transform.position) < distanceToMiniMainTower)
                            {
                                nav.destination = miniMainTower.collider.gameObject.transform.position;
                                miniMainTowerFound = miniMainTower.collider.gameObject;

                                distanceToMiniMainTower = Vector3.Distance(transform.position, miniMainTower.collider.gameObject.transform.position);
                            }
                        }
                    }
                }

                if (!miniTowerFound)
                {
                    if (!towerFound)
                    {
                        towerFound = false;

                        RaycastHit[] towerInRange = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
                        if (towerInRange.Length > 0)
                        {
                            foreach (var towerTarget in towerInRange)
                            {
                                if (towerTarget.collider.GetComponent<Tower>())
                                {
                                    if (towerTarget.collider.GetComponent<Tower>().health > 0)
                                    {
                                        if (!towerTarget.collider.GetComponent<Tower>().isHero)
                                        {
                                            nav.destination = towerTarget.transform.position;
                                            normaltowerFound = towerTarget.collider.gameObject;
                                            
                                            towerFound = true;

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (normaltowerFound != null)
                        {
                            if (normaltowerFound.GetComponent<Tower>().health < 0)
                            {
                                towerFound = false;
                                normaltowerFound = null;
                                nav.destination = tileTargetPos;
                            }
                            else
                            {
                                nav.destination = new Vector3(normaltowerFound.transform.position.x, 0.5f, normaltowerFound.transform.position.z);
                                normaltowerFound.GetComponent<Tower>().health -= damage * 15;
                                anim.SetTrigger("doHit");

                                for (int i = 0; i < 10; i++)
                                {
                                    GameObject instParticle = Instantiate(hitParticle, transform.position, transform.rotation);
                                    Destroy(instParticle, 3);
                                }
                            }
                        }
                        else
                        {
                            towerFound = false;
                            normaltowerFound = null;
                            nav.destination = tileTargetPos;
                        }
                    }
                }
            }
            else if (miniTowerFound)
            {
                if (miniMainTowerFound == null)
                {
                    miniTowerFound = false;
                    return;
                }

                //nav.destination = miniMainTowerFound.transform.position;
                nav.destination = new Vector3(miniMainTowerFound.transform.position.x, 0.5f, miniMainTowerFound.transform.position.z);

                if (Vector3.Distance(transform.position, miniMainTowerFound.transform.position) < 2)
                {
                    miniMainTowerFound.GetComponent<MiniMainTower>().health--;

                    Dead();
                }
            }
            
            if (!miniTowerFound && !towerFound)
            {
                nav.destination = target.position;
                return;
                /*
                int auxID = 0;

                if (canFindNextTile)
                {
                    auxID = 1;
                }

                //if (canFindNextTile || timerToFoundNewTile > 5)
                if (true)
                {
                    timerToFoundNewTile = 0;

                    canFindNextTile = false;

                    Transform closestTarget = null;
                    float closestTargetDistance = float.MaxValue;
                    NavMeshPath path = new NavMeshPath();

                    GameObject[] groundTiles = gameFlow.groundTiles;
                    List<GameObject> groundTilesSelected = new List<GameObject>();
                    GameObject tileSelected = targetGO;

                    foreach (var groundTile in groundTiles)
                    {
                        if (groundTile.GetComponent<MapInfo>().id == mapPosId - auxID)
                        {
                            groundTilesSelected.Add(groundTile);
                        }
                    }

                    for (int i = 0; i < groundTilesSelected.Count; i++)
                    {
                        if (NavMesh.CalculatePath(transform.position, groundTilesSelected[i].transform.position, nav.areaMask, path))
                        {
                            float distance = Vector3.Distance(transform.position, path.corners[0]);//

                            for (int j = 1; j < path.corners.Length; j++)
                            {
                                distance += Vector3.Distance(path.corners[j - 1], path.corners[j]);
                            }

                            if (distance < closestTargetDistance)
                            {
                                closestTargetDistance = distance;
                                closestTarget = groundTilesSelected[i].transform;
                                tileSelected = groundTilesSelected[i];
                                mapPosId = groundTilesSelected[i].GetComponent<MapInfo>().id;
                            }
                        }
                    }

                    if (path.corners.Length > 0 && nav.isActiveAndEnabled)
                    {
                        nav.SetDestination(closestTarget.position);//
                        targetGO = tileSelected;
                    }

                    if (mapPosId < 2 && nav.isActiveAndEnabled)
                    {
                        nav.SetDestination(target.transform.position);
                    }
                }

                if (mapPosId == -1 && nav.isActiveAndEnabled && !miniTowerFound)
                {
                    nav.destination = target.position;
                }
                */
            }
        }
    }

    void Update()
    {
        timerToFoundNewTile += Time.deltaTime;

        float newScaleX = initialScaleX * (health / healthMax);
        float newPosX = (initialScaleX - newScaleX) / 2;
        HealthBar.transform.localScale = new Vector3(newScaleX, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
        HealthBar.transform.localPosition = new Vector3(newPosX, HealthBar.transform.localPosition.y, HealthBar.transform.localPosition.z);

        float healthNormalized = (health / healthMax) * 100;
        if (healthNormalized > 50)
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarGreen;
        }
        else if (healthNormalized > 20)
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarYellow;
        }
        else
        {
            HealthBar.GetComponent<MeshRenderer>().material = healthBarRed;
        }

        if (health < 0)
        {
            GameObject[] towers = gameFlow.towers;
            if (towers.Length > 0)
            {
                foreach (var tower in towers)
                {
                    if (tower)
                    {
                        if (tower.GetComponent<Tower>())
                        {
                            if (tower.GetComponent<Tower>().attackType == Tower.AttackType.ResourcesVariable)
                            {
                                if (Vector3.Distance(transform.position, tower.gameObject.transform.position) <= tower.GetComponent<Tower>().range)
                                {
                                    tower.GetComponent<Tower>().healthDamage += 5;
                                }
                            }

                            if (Vector3.Distance(transform.position, tower.transform.position) < 10)
                            {
                                tower.GetComponent<Tower>().kills++;
                            }
                        }
                    }
                }
            }
            GameObject[] enemies = gameFlow.activeEnemies;
            if (enemies.Length > 0)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy)
                    {
                        if (enemy.GetComponent<Enemy>())
                        {
                            if (enemy.GetComponent<Enemy>().isBoss && enemy.GetComponent<Enemy>().zone == Enemy.Zone.Fantasia)
                            {
                                enemy.GetComponent<Enemy>().numEnemiesDead++;
                            }
                        }
                    }
                }
            }

            gameFlow.coins += gold;

            GameObject instSkull = Instantiate(skull, new Vector3(transform.position.x, 0.6f, transform.position.z), transform.rotation);
            instSkull.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);

            ParticleSystem instDeadParticle = Instantiate(deadParticle, transform.position, transform.rotation);
            Destroy(instDeadParticle, 3);

            Dead();
        }

        iceEffect -= (Time.deltaTime * 3);
        iceEffect = Mathf.Max(iceEffect, 0);
        iceEffect = Mathf.Min(iceEffect, 50);
        
        igniteEffect -= (Time.deltaTime * 3);
        igniteEffect = Mathf.Max(igniteEffect, 0);
        health -= (igniteEffect * 0.01f);
        if (igniteEffect >= 100)
        {
            health -= igniteEffect;
            igniteEffect = 0;
        }

        waterEffect -= (Time.deltaTime * 3);
        waterEffect = Mathf.Max(waterEffect, 0);
        if (waterEffect >= 100)
        {
            GameObject instParticle = Instantiate(torbellinoParticle, transform.position, transform.rotation);
            Destroy(instParticle, waterEffectTime);
            
            //waterParticles.SetActive(true);
            speed = 0;
            isWaterEffect = true;
            Invoke("DisableWaterEffect", waterEffectTime);
        }

        if (!isWaterEffect)
        {
            if (isBoss)
            {
                if (!isAttack)
                {
                    speed = (normalSpeed * ((100 - iceEffect) / 100));
                }
            }
            else
            {
                speed = (normalSpeed * ((100 - iceEffect) / 100));
            }
        }

        if (transformationEffect >= 100)
        {
            GameObject instEnemy = Instantiate(gameFlow.skeleton, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            instEnemy.SetActive(true);

            gameFlow.enemiesLeft2++;

            Dead();
        }

        if (terrain == Terrain.Ground)
        {
            nav.speed = speed * gameFlow.newSpeed;
        }
        else
        {
            Vector3 moveVec = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z).normalized;
            transform.LookAt(transform.position + moveVec);
            transform.position += moveVec * speed * gameFlow.newSpeed * Time.deltaTime;
        }

        if (infectationMode && terrain == Terrain.Ground)
        {
            InfectationMode();
        }
    }

    void InfectationMode()
    {
        RaycastHit[] enemiesInRange = Physics.SphereCastAll(transform.position, 50, transform.forward, 1.0f, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length > 0)
        {
            int enemyID = -1;

            for (int i = 0; i < enemiesInRange.Length; i++)
            {
                if (enemiesInRange[i].collider.gameObject != gameObject)
                {
                    enemyID = i;
                    break;
                }
            }

            if (enemyID != -1)
            {
                if (nav.isActiveAndEnabled)
                {
                    nav.destination = enemiesInRange[0].transform.position;
                }

                if (Vector3.Distance(transform.position, enemiesInRange[0].transform.position) < range)
                {
                    enemiesInRange[0].collider.GetComponent<Enemy>().health -= (damage * 10);
                    anim.SetTrigger("doHit");
                }
            }
            else
            {
                if (gameObject != null && nav.isActiveAndEnabled)
                {
                    nav.destination = target.position;
                }
            }
        }
        else
        {
            nav.destination = target.position;
        }
    }

    void DisableWaterEffect()
    {
        //waterParticles.SetActive(false);
        waterEffect = 0;
        speed = normalSpeed;
        isWaterEffect = false;
        waterEffectTime = 2;
    }

    void Zone0Attack1()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone1Attack1()
    {
        RaycastHit[] rayHitsPlayers = Physics.SphereCastAll(transform.position, range, transform.forward, 1.0f, LayerMask.GetMask("Tower"));
        if (rayHitsPlayers.Length > 0)
        {
            anim.SetTrigger("doHit");

            GameObject bulletGO = Instantiate(bullet, bulletPos.transform.position, transform.rotation);
            Bullet newBullet = bulletGO.GetComponent<Bullet>();

            newBullet.healthDamage = damage;

            newBullet.Seek(rayHitsPlayers[0].transform);
        }
    }
    void Zone1Attack2()
    {
        StartCoroutine(SpawnGoblins());
    }

    IEnumerator SpawnGoblins()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        isAttack = true;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(goblins, transform.position + (transform.forward * 2), transform.rotation);
            gameFlow.enemiesLeft1++;
            yield return new WaitForSeconds(0.1f);
        }

        canMove();
    }

    void Zone1Attack3()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        isAttack = true;

        Instantiate(mamut, transform.position + (transform.forward * 3), transform.rotation);
        gameFlow.enemiesLeft2++;

        Invoke("canMove", 1.15f);
    }

    void Zone2Attack1()
    {
        anim.SetTrigger("doInvoke");
        speed = 0;

        health += 200;
        health = Mathf.Min(health, healthMax);

        isAttack = true;
        Invoke("canMove", 1.15f);
    }

    void Zone2Attack2()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }
            
            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone3Attack1()
    {
        RaycastHit[] enemiesInrange = Physics.SphereCastAll(transform.position, range, transform.forward, 1, LayerMask.GetMask("Enemy"));
        if (enemiesInrange.Length > 0)
        {
            anim.SetTrigger("doInvoke");
            speed = 0;

            foreach (var enemy in enemiesInrange)
            {
                if (!enemy.collider.gameObject.GetComponent<Enemy>().poseidonBoost)
                {
                    enemy.collider.gameObject.GetComponent<Enemy>().normalSpeed *= 1.25f;
                    enemy.collider.gameObject.GetComponent<Enemy>().poseidonBoost = true;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone3Attack2()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone4Attack1()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone4Attack2()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        isAttack = true;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(dogs, transform.position + (transform.forward * 2), transform.rotation);
            gameFlow.enemiesLeft1++;
            yield return new WaitForSeconds(0.1f);
        }

        canMove();
    }

    void Zone5Attack1()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }
    void Zone5Attack2()
    {
        anim.SetTrigger("doInvoke");
        speed = 0;

        health += (numEnemiesDead * 3);
        numEnemiesDead = 0;

        isAttack = true;
        Invoke("canMove", 1.15f);
    }

    void Zone6Attack1()
    {
        RaycastHit[] towerInrange = Physics.SphereCastAll(transform.position, 5, transform.forward, range, LayerMask.GetMask("Tower"));
        if (towerInrange.Length > 0)
        {
            anim.SetTrigger("doHit");
            speed = 0;

            foreach (var tower in towerInrange)
            {
                if (tower.collider.gameObject.GetComponent<Tower>())
                {
                    tower.collider.gameObject.GetComponent<Tower>().health -= damage;
                }
            }

            isAttack = true;
            Invoke("canMove", 1.15f);
        }
    }

    void Zone6Attack2()
    {
        StartCoroutine(SpawnDeadEnemies());
    }

    IEnumerator SpawnDeadEnemies()
    {
        anim.SetTrigger("doHit");
        speed = 0;

        isAttack = true;

        for (int i = 0; i < 10; i++)
        {
            Instantiate(fireBlins, transform.position + (transform.forward * 2), transform.rotation);
            gameFlow.enemiesLeft1++;
            yield return new WaitForSeconds(0.1f);
        }

        canMove();
    }

    void canMove()
    {
        isAttack = false;
        speed = normalSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetGO)
        {
            canFindNextTile = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == targetGO)
        {
            canFindNextTile = true;
        }

        if (collision.collider.tag == "Tower")
        {
            if (collision.collider.GetComponent<Tower>())
            {
                if (collision.collider.GetComponent<Tower>().canColocate == Tower.CanColocate.Path)
                {
                    collision.collider.gameObject.GetComponentInParent<Tower>().health -= damage;
                    canFindNextTile = true;
                    
                    GameObject instParticle = Instantiate(hitParticle, transform.position, transform.rotation);
                    Destroy(instParticle, 3);
                    
                    if (anim != null && !isBoss)
                    {
                        anim.SetBool("isHit", true);
                    }

                    if (canBoom)
                    {
                        collision.collider.gameObject.GetComponentInParent<Tower>().health -= 250;

                        Dead();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainTower")
        {
            StartCoroutine(CameraController.instance.Shake(250, 3));

            SoundManager.instance.SoundSelection(19, 0.5f);

            MainTower.instance.health--;

            if (type == Type.Grande)
            {
                mainTower.health = -1;
            }

            Invoke("Dead", 0.2f);
        }

        if (other.tag == "Wave")
        {
            waterEffect = 120;
            waterEffectTime = 3;
        }

        if (other.tag == "SpecialGround")
        {
            switch (Generator.instance.zone)
            {
                case Generator.Zone.Hielo:

                    break;
                case Generator.Zone.Desierto:
                    igniteResistence *= 2;
                    break;
                case Generator.Zone.Atlantis:
                    
                    break;
                case Generator.Zone.Valhalla:
                    damage *= 2;
                    speed *= 2;
                    normalSpeed *= 2;
                    range *= 2;
                    health *= 2;
                    healthMax *= 2;
                    iceEffect *= 2;
                    igniteEffect = 0;
                    waterEffect = 0;
                    ascentEffect = 0;
                    bloodEffect = 0;
                    transformationEffect = 0;
                    iceResistence = 100;
                    igniteResistence = 100;
                    waterResistence = 100;
                    ascentResistence = 100;
                    bloodResistence = 100;
                    transformationResistence = 100;
                    BoxCollider[] boxcollidersTile = other.GetComponents<BoxCollider>();
                    foreach (var boxcolliderTile in boxcollidersTile)
                    {
                        if (boxcolliderTile.isTrigger)
                        {
                            boxcolliderTile.enabled = false;
                        }
                    }
                    break;
                case Generator.Zone.Fantasia:

                    break;
                case Generator.Zone.Infierno:
                    if (type != Type.Grande || enemyName != "Esqueleto")
                    {
                        transformationEffect += 10;
                    }
                    break;
            }
        }
        if (other.tag == "ImpactDamage")
        {
            health -= 1000;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Damage")
        {
            health -= (other.gameObject.GetComponentInParent<Tower>().healthDamage * 0.1f);
            iceEffect += ((other.gameObject.GetComponentInParent<Tower>().iceDamage * 0.1f) * iceResistence);
            bloodEffect += ((other.gameObject.GetComponentInParent<Tower>().bloodDamage * 0.1f) * bloodResistence);
            iceEffect = Mathf.Min(iceEffect, 50);

            if (anim != null && !isBoss)
            {
                anim.SetBool("isHit", true);
            }
        }
        else
        {
            if (anim != null && !isBoss)
            {
                anim.SetBool("isHit", false);
            }
        }

        if (other.tag == "SpecialGround")
        {
            switch (Generator.instance.zone)
            {
                case Generator.Zone.Hielo:
                    nav.speed = speed * 0.5f;
                    break;
                case Generator.Zone.Desierto:

                    break;
                case Generator.Zone.Atlantis:

                    break;
                case Generator.Zone.Valhalla:

                    break;
                case Generator.Zone.Fantasia:
                    bloodEffect += Time.deltaTime * 3;
                    health -= Time.deltaTime * 25;
                    break;
                case Generator.Zone.Infierno:

                    break;
            }
        }

        if (other.tag == "ImpactDamage")
        {
            health -= Time.deltaTime * 10;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Damage")
        {
            health -= 5;
            iceEffect += (1 * iceResistence);
            iceEffect = Mathf.Min(iceEffect, 50);
        }
        if (other.tag == "InstaIce")
        {
            iceEffect = 105;
        }
        if (other.tag == "Infectation")
        {
            infectationMode = true;

            Invoke("NoInfectationMode", mainTower.infectationDuration);
            
            GameObject instParticle = Instantiate(infectionParticle, transform.position + new Vector3(0, 2, 0), transform.rotation);
            instParticle.transform.localScale *= range;
            Destroy(instParticle, 3);
        }
    }

    void NoInfectationMode()
    {
        infectationMode = false;
        nav.destination = tileTargetPos;
    }

    void AutoDestroy()
    {
        Dead();
    }

    void Dead()
    {
        switch (type)
        {
            case (Type.Pequeño):
                gameFlow.enemiesLeft1--;
                gameFlow.kills1++;
                break;
            case (Type.Mediano):
                gameFlow.enemiesLeft2--;
                gameFlow.kills2++;
                break;
            case (Type.Grande):
                gameFlow.enemiesLeft3--;
                gameFlow.kills3++;
                break;
        }

        SoundManager.instance.SoundSelection(8, 0.5f);

        Destroy(gameObject);
    }

    void cameraShake()
    {
        print("1");
        CameraController.instance.transform.Translate(Vector3.down * 20f);
    }
    void ReturnCameraPosition()
    {
        print("2");
        CameraController.instance.transform.Translate(Vector3.up * 20f);
    }
}
