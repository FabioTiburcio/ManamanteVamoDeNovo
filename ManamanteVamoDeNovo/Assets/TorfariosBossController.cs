using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorfariosBossController : MonoBehaviour
{
    public enum TorfariosState { Idle, Attacking, Sumonning, Berseker, AreaAttack};

    public int attackDamage;
    public int attackCooldown;
    public TorfariosState currentState;
    public Health bossHealth;
    public GameObject player;
    public GameObject torfariosAttack;
    private float projectileVelocity = 3f;
    public Transform firePoint;
    GameObject enemySkill;

    private Animator enemyAnim;
    private float attackTimer;

    public GameObject enemyToSummon;
    public Transform[] enemysSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        firePoint.LookAt(player.transform);
        switch (currentState)
        {
            case TorfariosState.Idle:
                Debug.Log("Speaking");
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
                rb.AddForce(firePoint.forward * projectileVelocity, ForceMode2D.Impulse);
                break;
            case TorfariosState.Sumonning:
                Instantiate(enemyToSummon, enemysSpawnPoints[0]);
                Instantiate(enemyToSummon, enemysSpawnPoints[1]);
                Instantiate(enemyToSummon, enemysSpawnPoints[2]);
                Instantiate(enemyToSummon, enemysSpawnPoints[3]);
                currentState = TorfariosState.Idle;
                break;
            case TorfariosState.Berseker:
                break;
            case TorfariosState.AreaAttack:
                break;
        }
    }
}
