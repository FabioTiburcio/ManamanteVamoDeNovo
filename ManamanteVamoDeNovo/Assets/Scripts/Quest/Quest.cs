using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public Sprite npcFoto;
    public string title;
    [TextArea]
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
