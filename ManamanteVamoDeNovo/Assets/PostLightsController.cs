using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostLightsController : MonoBehaviour
{

    public DayCycleController dayCycleController;
    public GameObject postOn;
    public GameObject postOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dayCycleController.dayHour >= 19 || dayCycleController.dayHour <= 6)
        {
            postOn.SetActive(true);
            postOff.SetActive(false);
        }
        else
        {
            postOn.SetActive(false);
            postOff.SetActive(true);
        }
    }
}
