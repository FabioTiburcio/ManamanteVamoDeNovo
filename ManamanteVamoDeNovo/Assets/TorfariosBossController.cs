using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorfariosBossController : MonoBehaviour
{
    public enum TorfariosState { Idle, Attacking, Sumonning, AreaAttack};
    public enum FightState { BeginOfFight, SecondMomentum, ThirdMomentum, HardestMomentum};

    public int attackDamage;
    public int attackCooldown;
    public TorfariosState currentTorfariosState;
    public FightState currentFightState;
    public Health bossHealth;
    public float battleTime;
    public GameObject player;
    public GameObject torfariosAttack;
    private float projectileVelocity = 3f;
    public Transform firePoint;
    GameObject enemySkill;

    private Animator enemyAnim;
    private float attackTimer;
    float idleTime = 0;
    float summonCooldown = 0;

    public GameObject enemyToSummon;
    public GameObject basicEnemyToSummon;
    public GameObject mediumEnemyToSummon;
    public GameObject hardEnemyToSummon;
    public GameObject hardestEnemyToSummon;
    public Transform[] enemysSpawnPoints;

    int stateChangerRandomMin;
    int stateChangerRandomMax;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        currentFightState = FightState.BeginOfFight;
        ChangeFightStates();
        bossHealth.health = 500;
    }

    // Update is called once per frame
    void Update()
    {
        TorfariosStates();
        firePoint.transform.up = player.transform.position - this.transform.position;
        battleTime += Time.deltaTime;
        summonCooldown += Time.deltaTime;
        switch (currentFightState)
        {
            case FightState.BeginOfFight:
                if (battleTime > 120 || bossHealth.health < bossHealth.maxHealth/4)
                {
                    currentFightState = FightState.SecondMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.SecondMomentum:
                if (battleTime > 500 || bossHealth.health < bossHealth.maxHealth / 2)
                {
                    currentFightState = FightState.ThirdMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.ThirdMomentum:
                if (battleTime > 800 || bossHealth.health < bossHealth.maxHealth / 1.3)
                {
                    currentFightState = FightState.HardestMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.HardestMomentum:
                if (bossHealth.health <= 0)
                {
                    gameObject.SetActive(false);
                }
                break;
        }


    }

    void ChangeFightStates()
    {
        switch (currentFightState)
        {
            case FightState.BeginOfFight:
                attackDamage = 5;
                attackCooldown = 4;
                enemyToSummon = basicEnemyToSummon;
                stateChangerRandomMin = 1;
                stateChangerRandomMax = 100;
                break;
            case FightState.SecondMomentum:
                attackDamage = 10;
                attackCooldown = 3;
                enemyToSummon = mediumEnemyToSummon;
                stateChangerRandomMin = 31;
                stateChangerRandomMax = 100;
                break;
            case FightState.ThirdMomentum:
                attackDamage = 15;
                attackCooldown = 2;
                enemyToSummon = hardEnemyToSummon;
                stateChangerRandomMin = 31;
                stateChangerRandomMax = 100;
                break;
            case FightState.HardestMomentum:
                attackDamage = 20;
                attackCooldown = 2;
                enemyToSummon = hardestEnemyToSummon;
                stateChangerRandomMin = 31;
                stateChangerRandomMax = 100;
                break;
        }
    }

    void BossStateChanger()
    {
        int randomState = Random.Range(stateChangerRandomMin, stateChangerRandomMax);
        if (randomState <= 30)
        {
            if(currentTorfariosState == TorfariosState.Idle)
            {
                BossStateChanger();
            }
            else
            {
                currentTorfariosState = TorfariosState.Idle;
            }
        }
        else if(randomState >30 && randomState <= 50)
        {
            currentTorfariosState = TorfariosState.Attacking;
        }
        else if(randomState >50 && randomState <= 80)
        {
            currentTorfariosState = TorfariosState.AreaAttack;
        }
        else if(randomState > 80)
        {
            currentTorfariosState = TorfariosState.Sumonning;
        }
    }

    void TorfariosStates()
    {
        switch (currentTorfariosState)
        {
            case TorfariosState.Idle:
                idleTime += Time.deltaTime;
                if (idleTime >= 2.5)
                {
                    idleTime = 0;
                    BossStateChanger();
                }
                break;
            case TorfariosState.Attacking:
                if (attackTimer <= attackCooldown)
                {
                    attackTimer += Time.deltaTime;
                    return;
                }
                enemyAnim.Play("Attack");
                attackTimer = 0;
                enemySkill = Instantiate(torfariosAttack, firePoint.position, torfariosAttack.transform.rotation);
                Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.transform.up * projectileVelocity, ForceMode2D.Impulse);
                BossStateChanger();
                break;
            case TorfariosState.AreaAttack:
                BossStateChanger();
                break;
            case TorfariosState.Sumonning:
                if (summonCooldown > 50)
                {
                    Instantiate(enemyToSummon, enemysSpawnPoints[0].position, enemysSpawnPoints[0].rotation, transform.parent);
                    Instantiate(enemyToSummon, enemysSpawnPoints[1].position, enemysSpawnPoints[1].rotation, transform.parent);
                    Instantiate(enemyToSummon, enemysSpawnPoints[2].position, enemysSpawnPoints[2].rotation, transform.parent);
                    Instantiate(enemyToSummon, enemysSpawnPoints[3].position, enemysSpawnPoints[3].rotation, transform.parent);
                    summonCooldown = 0;
                }
                BossStateChanger();
                break;
        }
    }
}
