using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RespawnSystem : MonoBehaviour
{
    public DayCycleController dayCycleController;
    public GameObject[] thingsToRespawn;
    public Vector3[] positionToRespawn;
    public Transform[] thingsPosition;

    public int[] separateTimes;
    private string[] separateTimesString;
    public int[] timeToRespawn;
    private string[] timeToRespawnString;

    public int completeTimeNow;

    //bool isAMorcegoDeDia;
    //bool isAMorcegoDeNotche;
    //bool morcegoVivo = true;

    // Start is called before the first frame update
    void Start()
    {
        thingsPosition = new Transform[thingsToRespawn.Length];
        positionToRespawn = new Vector3[thingsPosition.Length];
        separateTimes = new int[thingsToRespawn.Length];
        separateTimesString = new string[thingsToRespawn.Length];
        timeToRespawnString = new string[thingsToRespawn.Length];
        timeToRespawn = new int[thingsToRespawn.Length];

        for (int i = 0; i < thingsToRespawn.Length; i++)
        {
            thingsPosition[i] = thingsToRespawn[i].transform;
            positionToRespawn[i] = thingsPosition[i].position;
        }
        
    }

    private void Update()
    {
        completeTimeNow = Convert.ToInt32(dayCycleController.day.ToString() + (dayCycleController.dayHour<10 ? 0 + dayCycleController.dayHour.ToString() : dayCycleController.dayHour.ToString()) + (dayCycleController.dayMinute < 10 ? 0 + dayCycleController.dayMinute.ToString() : dayCycleController.dayMinute.ToString()));
        for (int i = 0; i < thingsToRespawn.Length; i++)
        {
            //if (thingsToRespawn[i].GetComponent<EnemyController>() != null)
            //{
            //    if (thingsToRespawn[i].GetComponent<EnemyController>().enemyName == "Morcego")
            //    {
            //        if (dayCycleController.dayHour < 19 && dayCycleController.dayHour >= 6)
            //        {
            //            thingsToRespawn[i].SetActive(false);
            //            isAMorcegoDeDia = true;
            //            isAMorcegoDeNotche = false;
            //        }
            //        else
            //        {
            //            isAMorcegoDeNotche = true;
            //            isAMorcegoDeDia = false;
            //            if (thingsToRespawn[i].activeSelf)
            //            {
            //                individualCounter(i);
            //                morcegoVivo = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        isAMorcegoDeDia = false;
            //    }
            //}
            //else
            //{
            //    isAMorcegoDeDia = false;
            //}
            
            if (!thingsToRespawn[i].activeSelf && separateTimes[i] == 0)
            {
                individualCounter(i);
            }
            else if(!thingsToRespawn[i].activeSelf && separateTimes[i] != 0)
            {
                if(completeTimeNow > timeToRespawn[i])
                {
                    RespawnObject(i);
                }
            }
        }

    }

    private void RespawnObject(int i)
    {
        thingsToRespawn[i].transform.position = positionToRespawn[i];
        thingsToRespawn[i].SetActive(true);
        separateTimesString[i] = "";
        timeToRespawnString[i] = "";
        separateTimes[i] = 0;
        timeToRespawn[i] = 0;
    }

    private void individualCounter(int i)
    {
        separateTimesString[i] = dayCycleController.day.ToString() + (dayCycleController.dayHour < 10 ? 0 + dayCycleController.dayHour.ToString() : dayCycleController.dayHour.ToString()) + (dayCycleController.dayMinute < 10 ? 0 + dayCycleController.dayMinute.ToString() : dayCycleController.dayMinute.ToString());
        separateTimes[i] = Convert.ToInt32(separateTimesString[i]);
        timeToRespawnString[i] = (dayCycleController.day + 1).ToString() + (dayCycleController.dayHour < 10 ? 0 + dayCycleController.dayHour.ToString() : dayCycleController.dayHour.ToString()) + (dayCycleController.dayMinute < 10 ? 0 + dayCycleController.dayMinute.ToString() : dayCycleController.dayMinute.ToString());
        timeToRespawn[i] = Convert.ToInt32(timeToRespawnString[i]);
    }
}
