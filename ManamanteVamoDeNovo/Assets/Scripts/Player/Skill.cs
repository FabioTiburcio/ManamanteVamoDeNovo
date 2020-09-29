using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isProjectile;
    public GameObject hitEffect;

    private void Start()
    {
    }
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.tag == "EnemyAttack" && collision.tag == "Player") Destroy(gameObject);
        if(this.tag == "Attack" && collision.tag == "Enemy") Destroy(gameObject);

    }
}
