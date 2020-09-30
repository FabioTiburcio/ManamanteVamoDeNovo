using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;  

    public string title;
    public string description;
    public int rewardId;
    public int rewardAmount;

    public QuestGoal goal;

    //public GameObject conclusionDialogue;

    public void Complete()
    {
        isActive = false;
        //conclusionDialogue.SetActive(true);
        Debug.Log(title + " foi completada");
    }

}
