using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailScreen : MonoBehaviour
{
    public Image fotoTela;
    public Text assuntoTela;
    public Text descricaoTela;
    public PlayerQuest playerQuest;
    public QuestGiver[] quests;
    private int questsCompleted;

    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");

        fotoTela.sprite = quests[questsCompleted].quest.npcFoto;
        assuntoTela.text = quests[questsCompleted].quest.title;
        descricaoTela.text = quests[questsCompleted].quest.description;
    }

    public void AcceptQuest()
    {    
            quests[questsCompleted].AcceptQuest();      
    }
}
