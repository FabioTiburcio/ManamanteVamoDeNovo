using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class EnemyController : MonoBehaviour {

    public enum enemyState { IDLE, CHASING, FURIOUS, ATTACKING, STUN, DYING }
    public enum enemyType { RANGED, MEELE}

    public enum enemyElement {NORMAL, FIRE, ICE, ELETRIC, POISON}
    private Rigidbody2D enemyRb;

    public GameObject dropItemPrefab;
    public ItemObject dropMorcego;
    public ItemObject dropAlma;
    public ItemObject dropGelo;
    public GameObject player;
    public SkillController PlayerSkillController;
    public Transform firePoint;
    public GameObject enemyFirePrefab;
    public GameObject enemyIcePrefab;
    public GameObject enemyEletricPrefab;
    public GameObject enemyPoisonPrefab;
    private FieldOfView fieldOfView;

    public Transform spawnDirection;

    public string enemyName;
    public float enemyAttackSpeed;
    private Health enemyHP;
    private float attackRange;
    private AIPath aIPath;
    public enemyState currentState = enemyState.IDLE;
    public enemyState lastState;
    public enemyType tipoInimigo;
    public enemyElement elementoInimigo;
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

    float t;
    private bool dropedItem;

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
        enemyHP = GetComponent<Health>();
        fieldOfView = GetComponentInChildren<FieldOfView>();
        aIPath = GetComponent<AIPath>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        initialSpeed = aIPath.maxSpeed;
    }
    private void OnEnable()
    {
        currentState = enemyState.IDLE;
        dropedItem = false;
        t = 0;
    }
    private void OnDisable()
    {
        enemyHP.health = enemyHP.maxHealth;
    }
    private void Update()
    {
        if (enemyHP.health <= 0)
        {            
            currentState = enemyState.DYING;
        }
        else
        {
            FindTargetPlayer();
        }
        switch (currentState)
        {
            case enemyState.IDLE:
                enemyAnim.Play("Idle");
                aIPath.canMove = false;
                break;
            case enemyState.CHASING:
                if(enemyName == "Slime")
                {
                    enemyAnim.Play("Jump");
                }
                else
                {
                    enemyAnim.Play("Idle");
                }
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
                            enemySkill = Instantiate(enemyEletricPrefab, firePoint.position, firePoint.rotation);
                            break;
                        case 4:
                            enemySkill = Instantiate(enemyPoisonPrefab, firePoint.position, firePoint.rotation);
                            break;
                    } 
                    Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                    rb.AddForce(spawnDirection.transform.up, ForceMode2D.Impulse);
                }
                else if (enemyName == "GeloRanged")
                {
                    spawnDirection.transform.up = player.transform.position - this.transform.position;
                    if (attackTimer <= attackCooldown)
                    {
                        attackTimer += Time.deltaTime;
                        return;
                    }
                    //enemyAnim.Play("Attack");
                    attackTimer = 0;
                    enemySkill = Instantiate(enemyIcePrefab, firePoint.position, firePoint.rotation);
                    Rigidbody2D rb = enemySkill.GetComponent<Rigidbody2D>();
                    rb.AddForce(spawnDirection.transform.up, ForceMode2D.Impulse);
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
                else if (enemyName == "GolemEletrico")
                {
                    enemyAnim.Play("Attack");
                    if (attackTimer <= attackCooldown / enemyAttackSpeed)
                    {
                        attackTimer += Time.deltaTime;
                        return;
                    }
                    else if(currentState == enemyState.ATTACKING && attackTimer >= attackCooldown / enemyAttackSpeed)
                    {
                        attackTimer = 0;
                        enemySkill = Instantiate(meleeAttackCol, firePoint);
                    }

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
                aIPath.canMove = false;
                t += 0.5f * Time.deltaTime;
                enemyHP.dissolveMaterial.SetFloat("Vector1_7A56B514", Mathf.Lerp(-1, 1, t));
                if (!dropedItem)
                {
                    DropItem();
                    dropedItem = true;
                }
                
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
        currentState = enemyState.CHASING;
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

    private void DropItem()
    {
        int chanceOfDrop = Random.Range(0, 100);
        if(chanceOfDrop <= 50)
        {
            if (enemyName == "Alma")
            {
                dropItemPrefab.GetComponent<GroundItem>().itemObject = dropAlma;
            }
            else if (enemyName == "Morcego")
            {
                dropItemPrefab.GetComponent<GroundItem>().itemObject = dropMorcego;
            }
            else if(enemyName == "GeloRanged")
            {
                dropItemPrefab.GetComponent<GroundItem>().itemObject = dropGelo;
            }
            Instantiate(dropItemPrefab, transform.position, transform.rotation, transform.parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
