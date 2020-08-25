using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Transform firePoint;
    private int activeSkill;
    
    public GameObject firePrefab;

    public GameObject icePrefab;

    public GameObject windPrefab;

    public GameObject earthPrefab;

    public float bulletForce = 20f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSkill = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSkill = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeSkill = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeSkill = 4;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        if (activeSkill == 1)
        {
            GameObject bullet = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 2)
        {
            GameObject bullet = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 3)
        {
            GameObject bullet = Instantiate(windPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 4)
        {
            GameObject bullet = Instantiate(earthPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
