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
    }

    // Update is called once per frame
    void Update()
    {
        TorfariosStates();
        battleTime += Time.deltaTime;
        switch (currentFightState)
        {
            case FightState.BeginOfFight:
                if (battleTime > 120f || bossHealth.health < 475)
                {
                    currentFightState = FightState.SecondMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.SecondMomentum:
                if (battleTime > 500f || bossHealth.health < 250)
                {
                    currentFightState = FightState.ThirdMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.ThirdMomentum:
                if (battleTime > 800f || bossHealth.health < 125)
                {
                    currentFightState = FightState.HardestMomentum;
                    ChangeFightStates();
                }
                break;
            case FightState.HardestMomentum:
                if (bossHealth.health <= 0)
                {
                    //TorfariosMorre
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
                stateChangerRandomMin = 51;
                stateChangerRandomMax = 100;
                break;
        }
    }

    void BossStateChanger()
    {
        int randomState = Random.Range(stateChangerRandomMin, stateChangerRandomMax);
        if (randomState <= 30)
        {
            currentTorfariosState = TorfariosState.Idle;
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
                break;
            case TorfariosState.Attacking:
                if (attackTimer <= attackCooldown)
                {
                    attackTimer += Time.deltaTime;
                    return;
                }
                enemyAnim.Play("Attack");
                attackTimer = 0;
                enemySkill = Instantiate(torfariosAttack, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                rb.AddForce(player.transform.position - this.transform.position, ForceMode2D.Impulse);
                break;
            case TorfariosState.AreaAttack:
                break;
            case TorfariosState.Sumonning:
                break;
        }
    }
}
