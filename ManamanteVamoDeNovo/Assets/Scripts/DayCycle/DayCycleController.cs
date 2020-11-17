using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    public Light2D dayCycle;
    public Color corAmanhecer;
    public Color corTarde;
    public Color corEntardecer;
    public Color corNoite;
    public float daySeconds;
    public float dayMinute;
    public float dayHour;
    public float day;
    public float daySpeed;
    private float timeChangingColor = 1f;
    private float minRainChance = 0;
    private float rainingChance;
    private float rainingTimer;
    private bool isRaining;
    public GameObject chuva;
    
    public AudioSource noiteAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        daySeconds += Time.deltaTime * daySpeed;
        if (daySeconds>=60)
        {
            daySeconds = 0;
            dayMinute++;
            changeIntensity();
        }
        if(dayMinute == 60)
        {
            dayMinute = 0;
            dayHour++;
            changeColor();
        }
        if(dayHour == 24)
        {
            dayHour = 0;
            day++;
            RainingController();
        }
        if (isRaining)
        {
            
            rainingTimer += Time.deltaTime;
            if (rainingTimer > 240)
            {
                
                isRaining = false;
                rainingTimer = 0;
                chuva.SetActive(false);
                minRainChance = 0;
            }
        }
    }

    public void RainingController()
    {
        rainingChance = Random.Range(minRainChance, 100);
        if(rainingChance > 50)
        {
            isRaining = true;
            chuva.SetActive(true);
        }
        else
        {
            minRainChance += 10;
            isRaining = false;
            chuva.SetActive(false);
        }
    }
    public void changeIntensity()
    {
        if (dayHour == 5)
        {
            dayCycle.intensity = 0.5f;
        }
        else if (dayHour >= 6 && dayHour <= 15)
        {
            if (dayCycle.intensity <= 1.3f)
            {
                dayCycle.intensity += 0.0015f;
            }
        }
        else if (dayHour >= 15 && dayHour <= 19)
        {
            if (dayCycle.intensity >= 0.5f)
            {
                dayCycle.intensity -= 0.004f;
            }
        }
        else if (dayHour == 20)
        {
            dayCycle.intensity = 0.5f;
        }
    }

    public void changeColor()
    {
        switch (dayHour)
        {
            case 6:
                dayCycle.color = Color.Lerp(corNoite, corTarde, timeChangingColor);
                noiteAudio.Stop();
                break;
            case 12:
                dayCycle.color = Color.Lerp(corAmanhecer, corTarde, timeChangingColor);
                break;
            case 17:
                dayCycle.color = Color.Lerp(corTarde, corEntardecer, timeChangingColor);
                break;
            case 19:
                dayCycle.color = Color.Lerp(corEntardecer, corNoite, timeChangingColor);
                noiteAudio.Play();
                break;
        }

    }
    private void OnApplicationQuit()
    {
    }
}
