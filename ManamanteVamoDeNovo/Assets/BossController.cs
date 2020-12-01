using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossController : MonoBehaviour
{
    public enum BossState { Idle, Chasing, MeleeAttack, RangeAttack, AreaAttack };

    public enum FightState { BeginOfFight, BelowHalfLife};

    public AIPath aIPath;

    public int attackDamage;
    public int attackCooldown;
    public BossState currentBosssState;
    public FightState currentFightState;
    public Health bossHealth;
    public float battleTime;
    public GameObject player;
    public GameObject bossMeleeAttack;
    public GameObject bossRangedAttack;
    public GameObject bossAreaAttack;
    private float projectileVelocity = 3f;
    public Transform firePoint;
    public Transform meleefirePoint;
    GameObject enemySkill;

    private Animator enemyAnim;
    private float attackTimer;
    float idleTime = 0;
    bool isBelowHalfHP = false;

    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        currentFightState = FightState.BeginOfFight;
        bossHealth.health = 500;
    }

    // Update is called once per frame
    void Update()
    {
        BossStates();
        firePoint.transform.up = player.transform.position - this.transform.position;
        battleTime += Time.deltaTime;
        if ((battleTime > 120 || bossHealth.health < bossHealth.maxHealth/2) && !isBelowHalfHP)
        {
            attackDamage = 2;
            attackCooldown = 3;
            aIPath.maxSpeed = 0.75f;
            isBelowHalfHP = true;
        }
        if (currentBosssState == BossState.Chasing)
        {
            aIPath.canMove = true;
        }
        else
        {
            aIPath.canMove = false;
        }
        attackTimer += Time.deltaTime;
    }
    void BossStates()
    {
        switch (currentBosssState)
        {
            case BossState.Idle:
                idleTime += Time.deltaTime;
                if (idleTime >= 2.5)
                {
                    idleTime = 0;
                    currentBosssState = BossState.Chasing;
                    enemyAnim.Play("Idle");
                }
                break;
            case BossState.Chasing:
                if (aIPath.remainingDistance <= 0.2 && attackTimer > attackCooldown)
                {
                    currentBosssState = BossState.MeleeAttack;
                }
                else if( aIPath.remainingDistance > 3 && attackTimer > attackCooldown)
                {
                    int chanceOfAreaAttack = Random.Range(1, 100);
                    if(chanceOfAreaAttack > 50)
                    {
                        currentBosssState = BossState.AreaAttack;
                    }
                    else
                    {
                        currentBosssState = BossState.RangeAttack;
                    }
                    
                }
                break;
            case BossState.RangeAttack:
                if (gameObject.name == "BossRobozao")
                {
                    enemyAnim.Play("AttackRangedChoque");
                }

                //enemyAnim.Play("MeleeAttack");
                attackTimer = 0;
                enemySkill = Instantiate(bossRangedAttack, firePoint.position, firePoint.transform.rotation);
                Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.transform.up * projectileVelocity, ForceMode2D.Impulse);
                currentBosssState = BossState.Idle;
                break;
            case BossState.MeleeAttack:
                
                if(gameObject.name == "BossRobozao")
                {
                    enemyAnim.Play("AttackRangedChoque");
                }
                else if(gameObject.name == "BossFogo")
                {
                    enemyAnim.Play("AttackMelee");
                }
                else
                {
                    enemyAnim.Play("Attack");
                }
                attackTimer = 0;
                Instantiate(bossMeleeAttack, meleefirePoint.position, bossMeleeAttack.transform.rotation);
                currentBosssState = BossState.Idle;
                break;
            case BossState.AreaAttack:
                if(gameObject.name == "BossRobozao")
                {
                    enemyAnim.Play("AttackRangedChoque");
                }
                else if (gameObject.name == "BossFogo")
                {
                    enemyAnim.Play("AttackArea");
                }
                currentBosssState = BossState.Idle;
                Instantiate(bossAreaAttack, player.transform.position, player.transform.rotation);
                break;
        }
    }
}
