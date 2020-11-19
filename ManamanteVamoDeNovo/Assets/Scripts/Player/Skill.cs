using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isProjectile;
    public bool areaAttack;
    public int skillDamage;
    public bool poisonSkill;
    public bool iceSkill;
    public bool iceSkillArea;
    public bool fireShield;
    public bool thunderSkill;
    public bool thunderSkillArea;
    public GameObject hitEffect;
    public GameObject hitSoundObject;
    public GameObject spawnSoundObject;
    public SpriteRenderer skillSprite;
    private AudioSource skillAudioSource;
    public AudioClip shieldHit;

    float eletricDamageCooldown;
    private void Start()
    {
        skillAudioSource = GetComponent<AudioSource>();
        if (areaAttack)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
        }
        
    }
    private void Update()
    {
        if (thunderSkill)
        {
            return;
        }
        if (thunderSkillArea)
        {
            Destroy(gameObject, 0.75f);
        } if (fireShield)
        {
            StartCoroutine(RemoveAfterSeconds(3, gameObject));
        }
        else
        {
            Destroy(gameObject, 3.5f);
        }
        
        
       
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "EnemyAttack" && collision.tag == "Player")
        {
            collision.GetComponent<Health>().DamageEffect();
            collision.GetComponent<Health>().health -= skillDamage;
            if (isProjectile)
            {
                Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }

        if (this.tag == "EnemyAttack" && collision.tag == "Shield")
        {
            if(this.gameObject.GetComponent<Skill>().isProjectile) Destroy(gameObject);
        }

        if (this.tag == "Shield" && collision.gameObject.tag == "EnemyAttack")
        {
            if(collision.gameObject.GetComponent<Skill>().isProjectile) skillAudioSource.PlayOneShot(shieldHit);
        }

        if (this.tag == "Attack" && collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().DamageEffect();
            collision.GetComponent<Health>().health -= skillDamage;
            
            if (isProjectile)
            {
                //skillSprite.gameObject.SetActive(false);
                //hitSoundObject.SetActive(true);
                //spawnSoundObject.SetActive(false);
                Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
           
            //Instantiate(hitEffect);
            if (poisonSkill)
            {
                collision.GetComponent<Health>().ApplyPoison();
            }

            if (thunderSkill)
            {
                collision.GetComponent<Health>().ApplyEletric();
            }

            if (iceSkill)
            {
                collision.GetComponent<Health>().ApplyIce();
            }

            if (iceSkillArea)
            {
                collision.GetComponent<Health>().ApplyIce();
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.tag == "Attack" && collision.tag == "Enemy")
        {
            if (iceSkillArea)
            {
                collision.GetComponent<Health>().ApplyIce();
            }
            if (thunderSkill || thunderSkillArea)
            {
                collision.GetComponent<Health>().ApplyEletric();
                
                eletricDamageCooldown += Time.deltaTime;
                if (eletricDamageCooldown > 0.5f)
                {
                    collision.GetComponent<Health>().health -= skillDamage;
                    eletricDamageCooldown = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.tag == "Attack" && collision.tag == "Enemy")
        {
            
            if (iceSkillArea)
            {
                collision.GetComponent<Health>().RemoveIce();

            }
        }
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

}
