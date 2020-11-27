using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public static int healAmount;
    public bool damageCooldown;
    public PlayerQuest activeQuest;
    public SkillController playerSkillController;
    public SpriteRenderer spriteMerinha;
    public Color corLaranja;
    private SpriteRenderer spr;
    public bool respawnPlayer;
    public Material normalMaterial;
    public Material dissolveMaterial;
    public Material poisonMaterial;
    public GameObject poisonParticle;
    public GameObject poisonExplosionParticle;
    public int poisonStack;
    public bool isPlayer;
    public AudioSource saidaDeSom;
    public AudioClip coracaoBatendo1;
    public AudioClip coracaoBatendo2;
    public AudioClip coracaoBatendo3;
    public AudioClip damageTaken;
    public AudioClip deadSound;
    public GameObject shieldSkill;
    public GameObject healEffect;
    float soundCooldown;
    bool isPoisoned;
    float poisonTimer;
    float poisonTimerRunOff;
    int poisonDamageOverTime = 2;
    int poisonAreaDamage = 3;
    bool isFrozen;
    float iceTimer;
    float iceTimerRunOff;
    int iceDamageOverTime = 1;
    float speed;
    bool isStuned;
    float stunTimer;
    bool isShieldOn = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spr = GetComponent<SpriteRenderer>();
        activeQuest = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuest>();
        if(this.tag == "Enemy" && this.name != "Torfarios")
        {
            speed = GetComponent<AIPath>().maxSpeed;
        }
    }

    private void Update()
    {
        if(isPlayer)
        {
            if (shieldSkill.activeSelf)
            {
                isShieldOn = true;
            }
            else
            {
                isShieldOn = false;
            }
        }


        if (damageCooldown)
        {
            StartCoroutine(DamageCooldown(1f));
        }
        if (isFrozen)
        {
            IceState();
            isPoisoned = false;
        }
        else if (isPoisoned)
        {
            PoisonState();
            isFrozen = false;
        } else if (isStuned)
        {
            StunState();
            isStuned = false;
        }
        else if (!isPoisoned)
        {
            poisonParticle.SetActive(false);
            spr.color = new Color(255, 255, 255, 255);
        }
        else if(!isFrozen)
        {
            spr.color = new Color(255, 255, 255, 255);
        } else if (!isStuned)
        {
            spr.color = new Color(255, 255, 255, 255);
        }

        if(health <= 0)
        {
            //damageCooldown = false;
            if (this.name != "Player")
            {
                spr.material = dissolveMaterial;
                StartCoroutine(DissolveEffect());
            }

            if (this.name == "Player")
            {
                saidaDeSom.PlayOneShot(deadSound);
                respawnPlayer = true;
                health = maxHealth;
            }
            
        }
        else if(health > maxHealth)
        {
            health = maxHealth;
        }
        if (healAmount != 0)
        {
            health += healAmount;
            healEffect.SetActive(true);
            StartCoroutine(DisableHealEffect());
            healAmount = 0;
        }
        if (isPlayer)
        {
            
            soundCooldown += Time.deltaTime;
            if (soundCooldown > 3)
            {
                if(health > 75)
                {
                    spriteMerinha.color = Color.green;
                }
                else if (health <= 75 && health > 50)
                {
                    spriteMerinha.color = Color.yellow;
                    saidaDeSom.clip = coracaoBatendo1;
                    saidaDeSom.Play();
                }
                else if (health <= 50 && health > 25)
                {
                    spriteMerinha.color = corLaranja;
                    saidaDeSom.clip = coracaoBatendo2;
                    saidaDeSom.Play();
                }
                else if (health <= 25)
                {
                    spriteMerinha.color = Color.red;
                    saidaDeSom.clip = coracaoBatendo3;
                    saidaDeSom.Play();
                }
                soundCooldown = 0;
            }
        }
        
        
    }
    public static void HealAmount(int amount)
    {
        healAmount = amount;
    }

    IEnumerator DisableHealEffect()
    {
        yield return new WaitForSeconds(1.5f);
        healEffect.SetActive(false);
    }
    IEnumerator DissolveEffect()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        health = maxHealth;
        dissolveMaterial.SetFloat("Vector1_7A56B514", -1);
        spr.material = normalMaterial;
    }

    IEnumerator DamageCooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        damageCooldown = false;
    }
    public void DamageEffect()
    {
        spr.enabled = false;
        //spr.color = new Color(spr.color.r,spr.color.g,spr.color.b, 0);
        StartCoroutine(damageEffectTime());
    }
    IEnumerator damageEffectTime()
    {
        yield return new WaitForSeconds(0.1f);
        spr.enabled = true;
        //spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1);
    }

    public void ApplyPoison()
    {
        poisonStack += 1;
        isPoisoned = true;
        poisonTimerRunOff = 0;
    }
    public void PoisonState()
    {
        if (Input.GetButtonDown("Fire2") && playerSkillController.colorIntensity>= 0.6f)
        {
            poisonExplosionParticle.SetActive(true);
            StartCoroutine(StopPoisonExplosion());
            playerSkillController.colorIntensity -= 0.6f;
            health -= poisonAreaDamage * poisonStack;
            poisonTimerRunOff = 0;
        }
        poisonParticle.SetActive(true);
        spr.color = new Color(0.4f,1,0.4f);
        poisonTimer += Time.deltaTime;
        poisonTimerRunOff += Time.deltaTime;
        if (poisonTimer >= 2f)
        {
            poisonTimer = 0;
            health -= poisonDamageOverTime;
        }
        if (poisonTimerRunOff >= 10f)
        {
            isPoisoned = false;
            poisonStack = 0;
        }
    }

    public void RemoveIce()
    {
        isFrozen = false;
        this.gameObject.GetComponent<AIPath>().maxSpeed = speed;
        iceTimerRunOff = 0;
    }

    public void ApplyIce()
    {
        isFrozen = true;
        this.gameObject.GetComponent<AIPath>().maxSpeed = speed / 2;
        
    }

    public void RemoveEletric()
    {
        this.gameObject.GetComponent<AIPath>().maxSpeed = speed;
    }

    public void ApplyEletric()
    {
        isStuned = true;
        this.gameObject.GetComponent<AIPath>().maxSpeed = 0;
    }

    public void IceState()
    {
        spr.color = new Color(0.4f,0.99f,0.97f);
        iceTimer += Time.deltaTime;
        iceTimerRunOff += Time.deltaTime;
        if (iceTimer >= 1f)
        {
            iceTimer = 0;
            health -= iceDamageOverTime;
        }
        if (iceTimerRunOff >= 3f)
        {
            RemoveIce();
        }
    }

    public void StunState()
    {
        spr.color = new Color(0.92f, 0.93f, 0.23f);
        stunTimer += Time.deltaTime;
        
        if (stunTimer >= 2f)
        {
            RemoveEletric();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isShieldOn)
        {
            if (!collision.gameObject.GetComponent<Skill>().isProjectile)
            {
                if (this.name == "Player" && collision.tag == "EnemyAttack" && !damageCooldown)
                {
                    if (health > 0)
                    {
                        saidaDeSom.PlayOneShot(damageTaken);
                    }

                    damageCooldown = true;
                }
            }
        } else
        {
            if (this.name == "Player" && collision.tag == "EnemyAttack" && !damageCooldown)
            {
                if (health > 0)
                {
                    saidaDeSom.PlayOneShot(damageTaken);
                }

                damageCooldown = true;
            }
        }

        //if (this.name == "Player" && collision.tag == "EnemyAttack" && !damageCooldown && !isShieldOn)
        //{
        //    if(health > 0)
        //    {
        //        saidaDeSom.PlayOneShot(damageTaken);
        //    }
            
        //    damageCooldown = true;
        //}
        //else 
        if(this.tag == "Enemy" && collision.tag == "Attack" && !damageCooldown)
        {

            //if (health <= 0)
            //{
            //    saidaDeSom.PlayOneShot(deadSound);
            //}
            //else if (health > 0)
            //{
            //    saidaDeSom.PlayOneShot(damageTaken);
            //}
            if (health <= 0)
            {
                damageCooldown = false;
                if (this.name != "Player")
                {
                    if (this.name == "Torfarios")
                    {
                        activeQuest.QuestAtt("Torfarios", true);
                        //spr.material = dissolveMaterial;
                        //StartCoroutine(DissolveEffect());
                    } else
                    {
                        activeQuest.QuestAtt(this.gameObject.GetComponent<EnemyController>().enemyName, true);
                        //spr.material = dissolveMaterial;
                        //StartCoroutine(DissolveEffect());
                    }                   
                }               
            }

                DamageEffect();
            damageCooldown = true;
        }
    }

    IEnumerator StopPoisonExplosion()
    {
        yield return new WaitForSeconds(2f);
        poisonExplosionParticle.SetActive(false);
    }
}
