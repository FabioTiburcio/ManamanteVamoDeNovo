using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCtrl : MonoBehaviour
{

    public GameObject endGame;
    public int questCounter;
    public GameObject[] quests;
    // Start is called before the first frame update

    public void Update()
    {
        if (questCounter >= 3)
        {
            endGame.SetActive(true);
        }
    }

    public void NextQuestActivate()
    {
        questCounter++;               
        quests[questCounter].SetActive(true);
                               
    }
}
