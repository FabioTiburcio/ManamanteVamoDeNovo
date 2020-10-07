using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public static int healAmount;
    public bool damageCooldown;
    public PlayerQuest activeQuest;
    private SpriteRenderer spr;
    public bool respawnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (damageCooldown)
        {
            StartCoroutine(DamageCooldown(1f));
        }
        if(health <= 0)
        {
            damageCooldown = false;
            if (this.name != "Player")
            {
                activeQuest.QuestAtt(this.gameObject.GetComponent<EnemyController>().enemyName, true);
            }
            else
            {
                respawnPlayer = true;
            }
            gameObject.SetActive(false);
            health = maxHealth;
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 255);
        }
        else if(health > 100)
        {
            health = 100;
        }
        if (healAmount != 0)
        {
            health += healAmount;
            healAmount = 0;
        }
    }
    public static void HealAmount(int amount)
    {
        healAmount = amount;
    }
    IEnumerator DamageCooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        damageCooldown = false;
    }
    public void DamageEffect()
    {
        spr.color = new Color(spr.color.r,spr.color.g,spr.color.b, 0);
        StartCoroutine(damageEffectTime());
    }
    IEnumerator damageEffectTime()
    {
        yield return new WaitForSeconds(0.1f);
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 255);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "Player" && collision.tag == "EnemyAttack" && !damageCooldown)
        {
            DamageEffect();
            health -= 10;
            damageCooldown = true;
        }
        else if(this.tag == "Enemy" && collision.tag == "Attack" && !damageCooldown)
        {
            DamageEffect();
            health -= 10;
            damageCooldown = true;
        }
    }
}
