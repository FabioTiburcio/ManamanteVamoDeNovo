using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isProjectile;

    public GameObject hitEffect;

    private void Update()
    {
        
            Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isProjectile) Destroy(gameObject);
    }
}
