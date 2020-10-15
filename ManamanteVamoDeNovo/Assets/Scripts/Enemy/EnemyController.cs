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
    public SkillController PlayerSkillController;
    public Transform firePoint;
    public GameObject enemyFirePrefab;
    public GameObject TorfariosAttack;
    public GameObject enemyIcePrefab;
    private FieldOfView fieldOfView;

    public Transform spawnDirection;

    public string enemyName;
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
    public GameObject meleeAttackCol;

    GameObject enemySkill;

    private float initialSpeed;
    public bool hitPlayer;
    float attackTimer = 3f;
    private float attackCooldown = 3f;
    private bool attackAnimEnded;
    private bool SeeingPlayer;


    private void Start()
    {
        if (tipoInimigo == enemyType.MEELE)
        {
            attackRange = 1f;
        }
        else
        {
            attackRange = 2f;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        
        fieldOfView = GetComponentInChildren<FieldOfView>();
        aIPath = GetComponent<AIPath>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        initialSpeed = aIPath.maxSpeed;
    }
    private void OnEnable()
    {
        currentState = enemyState.IDLE;
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
                if(enemyName == "Alma")
                {
                    spawnDirection.transform.up = player.transform.position - this.transform.position;
                    if (attackTimer <= attackCooldown)
                    {
                        attackTimer += Time.deltaTime;
                        return;
                    }
                    //enemyAnim.Play("Attack");
                    attackTimer = 0;
                    PlayerSkillController = player.GetComponentInChildren<SkillController>();
                    switch (PlayerSkillController.activeSkill)
                    {
                        case 1:
                            enemySkill = Instantiate(enemyFirePrefab, firePoint.position, firePoint.rotation);
                            break;
                        case 2:
                            enemySkill = Instantiate(enemyIcePrefab, firePoint.position, firePoint.rotation);
                            break;
                        case 3:
                            enemySkill = Instantiate(enemyFirePrefab, firePoint.position, firePoint.rotation);
                            break;
                        case 4:
                            enemySkill = Instantiate(enemyIcePrefab, firePoint.position, firePoint.rotation);
                            break;
                    } 
                    Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                    rb.AddForce(spawnDirection.transform.up, ForceMode2D.Impulse);
                }
                else if(enemyName == "Torfarios")
                {
                    if (attackTimer <= attackCooldown/enemyAttackSpeed)
                    {
                        attackTimer += Time.deltaTime;
                        return;
                    }
                    enemyAnim.Play("Attack");
                    attackTimer = 0;
                    enemySkill = Instantiate(TorfariosAttack, firePoint.position, firePoint.rotation);
                    Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                    rb.AddForce(player.transform.position - this.transform.position, ForceMode2D.Impulse);
                }
                else if(enemyName == "Morcego")
                {
                    attackRange = 0.3f;
                    if (attackTimer <= attackCooldown / enemyAttackSpeed)
                    {
                        attackTimer += Time.deltaTime;
                        return;
                    }
                    attackTimer = 0;
                    enemySkill = Instantiate(meleeAttackCol, firePoint.position, firePoint.rotation);
                }
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
