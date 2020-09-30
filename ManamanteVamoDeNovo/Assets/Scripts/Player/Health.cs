using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public bool damageCooldown;
    public PlayerQuest activeQuest;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (damageCooldown)
        {
            StartCoroutine(DamageCooldown(1f));
        }
        if(health <= 0)
        {
            activeQuest.QuestAtt(this.gameObject.GetComponent<EnemyController>().enemyName, true);
            Destroy(gameObject);
        }
    }
    IEnumerator DamageCooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        damageCooldown = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "Player" && collision.tag == "EnemyAttack" && !damageCooldown)
        {
            health -= 10;
            damageCooldown = true;
        }
        else if(this.tag == "Enemy" && collision.tag == "Attack" && !damageCooldown)
        {
            health -= 10;
            damageCooldown = true;
        }
    }
}
