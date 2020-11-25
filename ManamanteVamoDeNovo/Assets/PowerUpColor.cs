using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpColor : MonoBehaviour
{
    public SkillController skillController;
    public  Color fireColor;
    public  Color iceColor;
    public  Color eletricColor;
    public  Color poisonColor;
    public  SpriteRenderer ballSpr;
    public  TrailRenderer trailRenderer;
    public  SpriteRenderer baseSpr;

    public int fireMultiplier;
    public int iceMultiplier;
    public int eletricMultiplier;
    public int poisonMultiplier;

    
    static int powerToUp;
    static bool canPowerUp;

    private void Start()
    {
        fireMultiplier = 1;
        iceMultiplier = 1;
        eletricMultiplier = 1;
        poisonMultiplier = 1;
    }

    private void Update()
    {
        if (canPowerUp)
        {
            fireMultiplier = 1;
            iceMultiplier = 1;
            eletricMultiplier = 1;
            poisonMultiplier = 1;
            switch (powerToUp)
            {
                case 1:
                    FirePower();
                    canPowerUp = false;
                    break;
                case 2:
                    IcePower();
                    canPowerUp = false;
                    break;
                case 3:
                    EletricPower();
                    canPowerUp = false;
                    break;
                case 4:
                    PoisonPower();
                    canPowerUp = false;
                    break;
            }
            ballSpr.gameObject.SetActive(true);
            baseSpr.gameObject.SetActive(true);
        }
    }

    IEnumerator DisablePowerUp(string power)
    {
        yield return new WaitForSeconds(60f);
        switch (power)
        {
            case "Fire":
                fireMultiplier = 1;
                break;
            case "Ice":
                iceMultiplier = 1;
                break;
            case "Eletric":
                eletricMultiplier = 1;
                break;
            case "Poison":
                poisonMultiplier = 1;
                break;
        }
        ballSpr.gameObject.SetActive(false);
        baseSpr.gameObject.SetActive(false);
    }

    public  void FirePower()
    {
        fireMultiplier = 2;
        ballSpr.color = fireColor;
        baseSpr.color = fireColor;
        trailRenderer.startColor = fireColor;
        StartCoroutine(DisablePowerUp("Fire"));
    }
    public  void IcePower()
    {
        iceMultiplier = 2;
        ballSpr.color = iceColor;
        baseSpr.color = iceColor;
        trailRenderer.startColor = iceColor;
        StartCoroutine(DisablePowerUp("Ice"));
    }
    public  void EletricPower()
    {
        eletricMultiplier = 2;
        ballSpr.color = eletricColor;
        baseSpr.color = eletricColor;
        trailRenderer.startColor = eletricColor;
        StartCoroutine(DisablePowerUp("Eletric"));
    }
    public  void PoisonPower()
    {
        poisonMultiplier = 2;
        ballSpr.color = poisonColor;
        baseSpr.color = poisonColor;
        trailRenderer.startColor = poisonColor;
        StartCoroutine(DisablePowerUp("Poison"));
    }

    public static void IntensifyPower(int Power)
    {
        powerToUp = Power;
        canPowerUp = true;
    }
}
