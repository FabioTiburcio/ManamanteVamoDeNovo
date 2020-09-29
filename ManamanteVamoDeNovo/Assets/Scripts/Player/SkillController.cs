using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public PlayerMovement player;
    public Transform firePoint;
    public int activeSkill;
    
    public GameObject firePrefab;
    public GameObject fireArea;

    public GameObject icePrefab;
    public GameObject iceArea;

    public GameObject windPrefab;
    public GameObject windArea;

    public GameObject earthPrefab;
    public GameObject earthArea;

    public float bulletForce = 20f;

    private void Start()
    {
        activeSkill = 1;
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

        if (Input.GetButtonDown("Fire2"))
        {
            Cast();
        }


    }

    void Cast()
    {
        if (activeSkill == 1)
        {
            GameObject area = Instantiate(fireArea, player.mousePos, Quaternion.identity);
            
        }
        else if (activeSkill == 2)
        {
            GameObject area = Instantiate(iceArea, player.mousePos, Quaternion.identity);
            
        }
        else if (activeSkill == 3)
        {
            GameObject area = Instantiate(windArea, player.mousePos, Quaternion.identity);
            
        }
        else if (activeSkill == 4)
        {
            GameObject area = Instantiate(earthArea, player.mousePos, Quaternion.identity);
            
        }
    }

    void Shoot()
    {
        if (activeSkill == 1)
        {
            GameObject bullet = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(player.lookDir * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 2)
        {
            GameObject bullet = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(player.lookDir * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 3)
        {
            GameObject bullet = Instantiate(windPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(player.lookDir * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 4)
        {
            GameObject bullet = Instantiate(earthPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(player.lookDir * bulletForce, ForceMode2D.Impulse);
        }
    }
}
