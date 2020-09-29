using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class EnemyController : MonoBehaviour {

    public enum enemyState { IDLE, CHASING, FURIOUS, ATTACKING, STUN, DYING }
    public enum enemyType { RANGED, MEELE}
    private Rigidbody2D enemyRb;

    public GameObject player;
    private FieldOfView fieldOfView;
    
    public int enemyDamage;
    public int enemyAttackSpeed;
    private int enemyHP = 100;
    private float attackRange;
    private AIPath aIPath;
    public enemyState currentState = enemyState.IDLE;
    public enemyState lastState;
    public enemyType tipoInimigo;
    private float timeChasing = 0f;
    private Animator enemyAnim;

    private float initialSpeed;
    private bool hitPlayer;
    private float attackCooldown = 3f;
    private bool attackAnimEnded;
    private bool SeeingPlayer;


    private void Start()
    {
        if(tipoInimigo == enemyType.MEELE)
        {
            attackRange = 0.75f;
        }
        else
        {
            attackRange = 3;
        }
        fieldOfView = GetComponentInChildren<FieldOfView>();
        aIPath = GetComponent<AIPath>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        initialSpeed = aIPath.maxSpeed;
    }
    private void Update()
    {
        FindTargetPlayer();
        if (enemyHP <= 0)
        {
            currentState = enemyState.DYING;
        }
        switch (currentState)
        {
            case enemyState.IDLE:
                enemyAnim.Play("Idle");
                aIPath.canMove = false;
                break;
            case enemyState.CHASING:
                enemyAnim.Play("Idle");
                aIPath.canMove = true;
                timeChasing += Time.deltaTime;
                if(aIPath.remainingDistance < attackRange)
                {
                    currentState = enemyState.ATTACKING;
                }
                //if(timeChasing > 10)
                //{
                //    currentState = enemyState.FURIOUS;
                //    aIPath.maxSpeed *= 2f;
                //}
                break;
            case enemyState.FURIOUS:
                if (aIPath.remainingDistance <= attackRange)
                {
                    currentState = enemyState.ATTACKING;
                }
                break;
            case enemyState.ATTACKING:
                aIPath.canMove = false;
                enemyAnim.Play("Attack");
                StartCoroutine(AttackCooldownCounter(attackCooldown));
                if (aIPath.remainingDistance > attackRange)
                {
                    currentState = enemyState.CHASING;
                }
                break;
            case enemyState.STUN:
                aIPath.canMove = false;
                StartCoroutine(stunCooldown(4f));
                //anim.setBool("Stun",true);
                break;
            case enemyState.DYING:
                break;
        }
    }

    private void FindTargetPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < fieldOfView.viewDistance && !SeeingPlayer)
        {
            // Player inside viewDistance
            currentState = enemyState.CHASING;
            SeeingPlayer = true;
        }
        else if(Vector3.Distance(transform.position, player.transform.position) > fieldOfView.viewDistance)
        {
            SeeingPlayer = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hitPlayer = true;
        }
    }

    private IEnumerator AttackCooldownCounter(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        enemyRb.velocity = Vector3.zero;
        enemyRb.rotation = 0;
        
    }
    private IEnumerator hitPlayerCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        ResetEnemyState();
    }

    private IEnumerator stunCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        //anim.setBool("Stun",false);
        ResetEnemyState();
    }

    private void ResetEnemyState()
    {
        aIPath.maxSpeed = initialSpeed;
        timeChasing = 0;
        aIPath.canMove = true;
        currentState = enemyState.CHASING;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
