using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isProjectile;
    public int skillDamage;
    public bool poisonSkill;
    public bool iceSkill;
    public bool iceSkillArea;
    public GameObject hitEffect;
    public GameObject hitSoundObject;
    public GameObject spawnSoundObject;
    public SpriteRenderer skillSprite;


    private void Start()
    {
        
    }
    private void Update()
    {
        Destroy(gameObject, 3f);
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "EnemyAttack" && collision.tag == "Player")
        {
            collision.GetComponent<Health>().health -= skillDamage;
            Destroy(gameObject);
            //Instantiate(hitEffect);
        }
        if (this.tag == "Attack" && collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().health -= skillDamage;
            if (isProjectile)
            {
                skillSprite.gameObject.SetActive(false);
                spawnSoundObject.SetActive(false);
                Destroy(gameObject, 1f);
            }
            hitSoundObject.SetActive(true);
            //Instantiate(hitEffect);
            if (poisonSkill)
            {
                collision.GetComponent<Health>().ApplyPoison();
            }

            if (iceSkill)
            {
                
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

}
