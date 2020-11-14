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
    public GameObject[] messageList;

    private void Start()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        messageList[questsCompleted].SetActive(true);

    }

    public void AcceptQuest()
    {    
            quests[questsCompleted].AcceptQuest();      
    }

    public void openQuest(int questNumber)
    {
        fotoTela.sprite = quests[questNumber].quest.npcFoto;
        assuntoTela.text = quests[questNumber].quest.title;
        descricaoTela.text = quests[questNumber].quest.description;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
}
