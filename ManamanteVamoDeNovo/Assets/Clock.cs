using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public DayCycleController dayCycleController;
    public Text clockText;

    // Update is called once per frame
    void Update()
    {
        clockText.text = (dayCycleController.dayHour < 10 ? 0 + dayCycleController.dayHour.ToString() : dayCycleController.dayHour.ToString()) + ":" +
            (dayCycleController.dayMinute < 10 ? 0 + dayCycleController.dayMinute.ToString() : dayCycleController.dayMinute.ToString());
    }
}
