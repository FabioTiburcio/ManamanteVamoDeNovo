using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class EnemyController : MonoBehaviour {

    public enum enemyState { CHASING, FURIOUS, ATTACKING, STUN, DYING }

    private Rigidbody2D enemyRb;

    public int enemyDamage;
    public int enemyAttackSpeed;
    private int enemyStamina = 100;
    private AIPath aIPath;
    public enemyState currentState = enemyState.CHASING;
    private float timeChasing = 0f;
    private Animator enemyAnim;

    private float initialSpeed;
    private bool hitPlayer;
    private float attackAnimTime = 3f;
    private bool attackAnimEnded;


    private void Start()
    {
        aIPath = GetComponent<AIPath>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        initialSpeed = aIPath.maxSpeed;
    }
    private void Update()
    {
        if (enemyStamina <= 0)
        {
            currentState = enemyState.DYING;
        }
        switch (currentState)
        {
            case enemyState.CHASING:
                timeChasing += Time.deltaTime;
                if(aIPath.remainingDistance < 4)
                {
                    currentState = enemyState.ATTACKING;
                    
                }
                if(timeChasing > 10)
                {
                    currentState = enemyState.FURIOUS;
                    aIPath.maxSpeed *= 2f;
                }
                break;
            case enemyState.FURIOUS:
                if (aIPath.remainingDistance < 6)
                {
                    currentState = enemyState.ATTACKING;
                }
                break;
            case enemyState.ATTACKING:
                aIPath.canMove = false;
                //enemyAnim.Play("Attack");
                StartCoroutine(AttackCooldownCounter(attackAnimTime));
                if (attackAnimEnded)
                {
                    ResetEnemyState();
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
        attackAnimEnded = true;
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



}
