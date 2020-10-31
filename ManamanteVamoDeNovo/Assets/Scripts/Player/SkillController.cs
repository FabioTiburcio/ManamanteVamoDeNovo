using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public PlayerMovement player;
    public Transform firePoint;
    public int activeSkill;
    public float attackCooldown;
    public bool isShotting;

    public bool canIce;
    public bool canPoison;
    public bool canElectric;

    public GameObject computadorScreen;
    public GameObject diaryScreen;
    public GameObject inventoryScreen;
    public GameObject craftScreen;
    
    public GameObject firePrefab;
    public GameObject fireArea;

    public GameObject icePrefab;
    public GameObject iceArea;

    public GameObject windPrefab;
    public GameObject windArea;

    public GameObject posionPrefab;
    public GameObject poisonArea;

    public float bulletForce = 20f;
    private void Start()
    {
        activeSkill = 1;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown += Time.deltaTime;
        firePoint.transform.up = player.lookDir;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSkill = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && canIce)
        {
            activeSkill = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && canElectric)
        {
            activeSkill = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && canPoison)
        {
            activeSkill = 4;
        }

        if (Input.GetButtonDown("Fire1") && attackCooldown > 1.5f)
        {
            if(inventoryScreen.activeSelf == true || diaryScreen.activeSelf == true || craftScreen.activeSelf == true || computadorScreen.activeSelf == true)
            {
                Debug.Log("n vo matar n");
            } else
            {
                player.freezePlayer = true;
                isShotting = true;
                StartCoroutine(timeAttacking());
                Shoot();
                attackCooldown = 0;
            }

        }

        if (Input.GetButtonDown("Fire2") && attackCooldown > 1.5f)
        {
            if (inventoryScreen.activeSelf == true || diaryScreen.activeSelf == true || craftScreen.activeSelf == true || computadorScreen.activeSelf == true)
            {
                Debug.Log("n vo matar n");
            }
            else
            {
                player.freezePlayer = true;
                isShotting = true;
                StartCoroutine(timeAttacking());
                Cast();
                attackCooldown = 0;
            }
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
            GameObject area = Instantiate(poisonArea, player.mousePos, Quaternion.identity);
            
        }
    }

    void Shoot()
    {
        if (activeSkill == 1)
        {
            GameObject bullet = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 2)
        {
            GameObject bullet = Instantiate(icePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 3)
        {
            GameObject bullet = Instantiate(windPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        } else if (activeSkill == 4)
        {
            GameObject bullet = Instantiate(posionPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator timeAttacking()
    {
        yield return new WaitForSeconds(0.5f);
        player.freezePlayer = false;
        isShotting = false;
    }
}
