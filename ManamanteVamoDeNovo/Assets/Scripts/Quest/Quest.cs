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
    public string npcName;
    public string title;
    [TextArea]
    public string description;
    [TextArea]
    public string feedback;
    //[TextArea]
    //public string diaryDescription;
    public int rewardId;
    public int rewardAmount;
    //[TextArea]
    //public string diaryComplete;
    public bool hasEndNote;

    public QuestGoal goal;

    //public GameObject conclusionDialogue;

        

    public void Complete()
    {
        
        isActive = false;
        //conclusionDialogue.SetActive(true);
        Debug.Log(title + " foi completada");
    }

   
}
