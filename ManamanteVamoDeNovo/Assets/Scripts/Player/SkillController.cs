using System;
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
    public GameObject fireHairEffect;
    public GameObject iceHairEffect;
    public GameObject poisonHairEffect;
    public GameObject eletricHairEffect;
    private ParticleSystem fireHairParticles;
    private ParticleSystem iceHairParticles;
    private ParticleSystem eletricHairParticles;
    private ParticleSystem poisonHairParticles;

    public float colorIntensity = 1f;
    float timeToAddMana;
    float timeToConsumeMana;

    public bool canFire2;
    public bool canIce;
    public bool canIce2;
    public bool canPoison;
    public bool canPoison2;
    public bool canElectric;
    public bool canElectric2;

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

    public int manaCooldown;

    private void Awake()
    {
        fireHairParticles = fireHairEffect.GetComponent<ParticleSystem>();
        iceHairParticles = iceHairEffect.GetComponent<ParticleSystem>();
        eletricHairParticles = eletricHairEffect.GetComponent<ParticleSystem>();
        poisonHairParticles = poisonHairEffect.GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        activeSkill = 1;
        skillSpawnSource = gameObject.GetComponent<AudioSource>();
        glowMaterial.SetColor("_Color", fireHairColor);
        ActiveHairEffect("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown += Time.deltaTime;
        firePoint.transform.up = player.lookDir;
        timeToAddMana += Time.deltaTime * manaCooldown;
        NumberOfHeadParticlesController(colorIntensity);
        if (timeToAddMana >= 9)
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
            ActiveHairEffect("Fire");
            glowMaterial.SetColor("_Color", fireHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[0]);
            activeSkill = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && canIce)
        {
            ActiveHairEffect("Ice");
            glowMaterial.SetColor("_Color", iceHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[1]);
            activeSkill = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && canElectric)
        {
            ActiveHairEffect("Eletric");
            glowMaterial.SetColor("_Color", thunderHairColor);
            skillSpawnSource.PlayOneShot(trocaDeSkills[2]);
            activeSkill = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && canPoison)
        {
            ActiveHairEffect("Poison");
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
        if (!Input.GetButton("Fire1") && activeSkill == 3 || Input.GetButtonUp("Fire1") && activeSkill == 3 || colorIntensity <= 0)
        {
            player.freezePlayer = false;
            isShotting = false;
            thunderSkill.SetActive(false);
        }
        //EndOfEletricSkillController

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
                StartCoroutine(AnimDelay(1));
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
                if(activeSkill == 1 && canFire2 || activeSkill == 2 && canIce2 || activeSkill == 3 && canElectric2 || activeSkill == 4 && canPoison2)
                {
                    colorIntensity -= 0.4f;
                    glowMaterial.SetFloat("_ColorIntensity", colorIntensity);
                    isShotting = true;
                    StartCoroutine(timeAttacking());
                    StartCoroutine(AnimDelay(2));
                    attackCooldown = 0;
                }

            }
        }


    }
    private void NumberOfHeadParticlesController(float value)
    {
        var fireEmission = fireHairParticles.emission;
        fireEmission.rateOverTime = value * 10;
        var iceEmission = iceHairParticles.emission;
        iceEmission.rateOverTime = value * 10;
        var eletricEmission = eletricHairParticles.emission;
        eletricEmission.rateOverTime = value * 20;
        var poisonEmission = poisonHairParticles.emission;
        poisonEmission.rateOverTime = value * 5;
    }
    private void ActiveHairEffect(string element)
    {
        switch (element)
        {
            case "Fire":
                fireHairEffect.SetActive(true);
                iceHairEffect.SetActive(false);
                eletricHairEffect.SetActive(false);
                poisonHairEffect.SetActive(false);
                break;
            case "Ice":
                fireHairEffect.SetActive(false);
                iceHairEffect.SetActive(true);
                eletricHairEffect.SetActive(false);
                poisonHairEffect.SetActive(false);
                break;
            case "Eletric":
                fireHairEffect.SetActive(false);
                iceHairEffect.SetActive(false);
                eletricHairEffect.SetActive(true);
                poisonHairEffect.SetActive(false);
                break;
            case "Poison":
                fireHairEffect.SetActive(false);
                iceHairEffect.SetActive(false);
                eletricHairEffect.SetActive(false);
                poisonHairEffect.SetActive(true);
                break;

        }
    }

    IEnumerator AnimDelay(int hability)
    {
        yield return new WaitForSeconds(0.32f);
        if(hability == 1)
        {
            Shoot();
        }
        else
        {
            Cast();
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
            case 0:
                canFire2 = true;
                break;
            case 1:
                canIce = true;
                canIce2 = true;
                break;
            case 2:
                canElectric = true;
                break;
            case 3:
                canPoison = true;
                break;
            case 4:
                canElectric2 = true;
                break;
            case 5:
                canPoison2 = true;
                break;
            case 6:
                player.upgradedRobo = true;
                break;
        }
    }

    IEnumerator timeAttacking()
    {
        yield return new WaitForSeconds(1f);
        player.freezePlayer = false;
        isShotting = false;
    }

    private void OnApplicationQuit()
    {
        glowMaterial.SetColor("_Color", Color.white);
    }
}
