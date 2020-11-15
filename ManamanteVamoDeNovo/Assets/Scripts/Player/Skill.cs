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

    float eletricDamageCooldown;
    private void Start()
    {
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
                Destroy(gameObject);
                Instantiate(hitEffect, transform.position, transform.rotation);
            }
            
        }

        if (this.tag == "Shield" && collision.tag == "EnemyAttack")
        {
            Destroy(gameObject);
        }

        if (this.tag == "Attack" && collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().DamageEffect();
            collision.GetComponent<Health>().health -= skillDamage;
            
            if (isProjectile)
            {
                skillSprite.gameObject.SetActive(false);
                hitSoundObject.SetActive(true);
                spawnSoundObject.SetActive(false);
                Destroy(gameObject, 2f);
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
