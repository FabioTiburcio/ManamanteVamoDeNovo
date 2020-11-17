using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{

    public PlayerMovement player;
    public Material glowMaterial;
    [ColorUsage(false,hdr:true)]
    public Color fireHairColor;
    [ColorUsage(false, hdr: true)]
    public Color iceHairColor;
    [ColorUsage(false, hdr: true)]
    public Color thunderHairColor;
    [ColorUsage(false, hdr: true)]
    public Color poisonHairColor;
    public Transform firePoint;
    public int activeSkill;
    public float attackCooldown;
    public bool isShotting;

    public float colorIntensity = 1f;
    float timeToAddMana;
    float timeToConsumeMana;

    public bool canIce;
    public bool canPoison;
    public bool canElectric;

    public bool isShieldOn;

    public GameObject computadorScreen;
    public GameObject diaryScreen;
    public GameObject inventoryScreen;
    public GameObject craftScreen;
    
    public GameObject firePrefab;
    public GameObject fireArea;

    public GameObject icePrefab;
    public GameObject iceArea;

    public GameObject thunderSkill;
    public GameObject thunderArea;

    public GameObject posionPrefab;
    public GameObject poisonArea;

    private AudioSource skillSpawnSource;
    public AudioClip[] trocaDeSkills;

    public float bulletForce = 20f;
    public int habilityToUnlock;
    private void Start()
    {
        activeSkill = 1;
        skillSpawnSource = gameObject.GetComponent<AudioSource>();
        glowMaterial.SetColor("_Color", fireHairColor);
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown += Time.deltaTime;
        firePoint.transform.up = player.lookDir;
        timeToAddMana += Time.deltaTime;
        if(timeToAddMana >= 9)
        {
            if (colorIntensity < 1)
            {
                colorIntensity += 0.2f;
            }
            glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
            timeToAddMana = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            glowMaterial.SetColor("_Color", fireHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[0]);
            activeSkill = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && canIce)
        {
            glowMaterial.SetColor("_Color", iceHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[1]);
            activeSkill = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && canElectric)
        {
            glowMaterial.SetColor("_Color", thunderHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[2]);
            activeSkill = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && canPoison)
        {
            glowMaterial.SetColor("_Color", poisonHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[3]);
            activeSkill = 4;
        }
        if (colorIntensity <= 0)
        {
            colorIntensity = 0;
            glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
            return;
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
                if (activeSkill != 3)
                {
                    colorIntensity -= 0.2f;
                    glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
                    StartCoroutine(timeAttacking());
                }
                Shoot();
                attackCooldown = 0;
            }

        }

        //EletricSkillController
        if (Input.GetButton("Fire1") && activeSkill == 3)
        {
            player.freezePlayer = true;
            timeToConsumeMana += Time.deltaTime;
            if (timeToConsumeMana > 1)
            {
                colorIntensity -= 0.2f;
                glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
                timeToConsumeMana = 0;
            }
            thunderSkill.transform.up = player.lookDir;
        }
        if (Input.GetButtonUp("Fire1") || colorIntensity <= 0)
        {
            player.freezePlayer = false;
            isShotting = false;
            thunderSkill.SetActive(false);
        }
        //EndOfEletricSkillController


        if (Input.GetButtonDown("Fire2") && attackCooldown > 1.5f)
        {
            if (inventoryScreen.activeSelf == true || diaryScreen.activeSelf == true || craftScreen.activeSelf == true || computadorScreen.activeSelf == true)
            {
                Debug.Log("n vo matar n");
            }
            else
            {
                colorIntensity -= 0.4f;
                glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
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
            fireArea.SetActive(true);
            
        }
        else if (activeSkill == 2)
        {
            GameObject area = Instantiate(iceArea, player.mousePos, Quaternion.identity);
            
        }
        else if (activeSkill == 3)
        {
            GameObject area = Instantiate(thunderArea, player.mousePos, Quaternion.identity);
            
        }
        else if (activeSkill == 4)
        {
            
            
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
            thunderSkill.SetActive(true);
        } else if (activeSkill == 4)
        {
            GameObject bullet = Instantiate(posionPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void unlockHability()
    {
        switch (habilityToUnlock)
        {
            case 1:
                canIce = true;
                break;
            case 2:
                canElectric = true;
                break;
            case 3:
                canPoison = true;
                break;
        }
    }

    IEnumerator timeAttacking()
    {
        yield return new WaitForSeconds(0.5f);
        player.freezePlayer = false;
        isShotting = false;
    }

    private void OnApplicationQuit()
    {
        glowMaterial.SetColor("_Color", Color.white);
    }
}
