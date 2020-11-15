using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailScreen : MonoBehaviour
{
    public Image fotoTela;
    public Text assuntoTela;
    public Text descricaoTela;
    public Text nomeTela;
    public Text acceptText;
    public PlayerQuest playerQuest;
    public QuestGiver[] quests;
    private int questsCompleted;
    private int questAccepted;
    public GameObject[] messageList;
    public GameObject acceptMission;

    private void Start()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("QuestAccepted", 0);

    }
    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        questAccepted = PlayerPrefs.GetInt("QuestAccepted");
        messageList[questsCompleted].SetActive(true);

    }

    public void AcceptQuest()
    {    
        quests[questsCompleted].AcceptQuest();
        PlayerPrefs.SetInt("QuestAccepted", questsCompleted+1);
    }

    public void openQuest(int questNumber)
    {
        Debug.Log(questAccepted);
        if(questAccepted == questNumber + 1)
        {
            acceptText.text = "Missão aceita";
            acceptMission.SetActive(false);
        } else
        {
            acceptText.text = "Aceitar Missão";
            acceptMission.SetActive(true);
        }
        fotoTela.sprite = quests[questNumber].quest.npcFoto;
        assuntoTela.text = quests[questNumber].quest.title;
        descricaoTela.text = quests[questNumber].quest.description;
        nomeTela.text = quests[questNumber].quest.npcName;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("QuestAccepted", 0);
    }
}