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

    private void Start()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
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
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
}
