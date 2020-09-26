using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    public Image dayCyclePanel;
    float R = 212;
    float G = 212;
    float B = 212;
    public float daySeconds;
    public float dayMinute;
    public float dayHour;
    public float daySpeed = 1;
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
        }
        if(dayMinute == 60)
        {
            dayMinute = 0;
            dayHour++;
        }
        if(dayHour == 24)
        {
            dayHour = 0;
        }
        

    }

    private void OnApplicationQuit()
    {
    }
}
