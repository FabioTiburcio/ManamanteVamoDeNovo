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
    private int feedbacksCompleted;
    private int questAccepted;
    private int feedbacksReceived;
    public GameObject[] messageList;
    public GameObject[] feedbackList;
    public GameObject acceptMission;
    
    public bool feedbackReceived = false;

    private void Start()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("QuestAccepted", 0);
        PlayerPrefs.SetInt("Feedback", 0);
        PlayerPrefs.SetInt("FeedbacksReceived", 0);

    }
    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        questAccepted = PlayerPrefs.GetInt("QuestAccepted");
        feedbacksReceived = PlayerPrefs.GetInt("FeedbacksReceived");
        feedbacksCompleted = PlayerPrefs.GetInt("Feedback");
        messageList[questsCompleted].SetActive(true);
        if(feedbacksCompleted > 0)
        {
            feedbackList[feedbacksCompleted - 1].SetActive(true);
        }
        
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

    public void openFeedback(int questNumber)
    {       
            acceptText.text = "Feedback recebido";
            acceptMission.SetActive(false);
        
        if (feedbacksReceived < questNumber + 1)
        {
            PlayerPrefs.SetInt("FeedbacksReceived", PlayerPrefs.GetInt("FeedbacksReceived") + 1);
            playerQuest.canGiveRewards = true;
            
        }
        fotoTela.sprite = quests[questNumber].quest.npcFoto;
        assuntoTela.text = quests[questNumber].quest.title;
        descricaoTela.text = quests[questNumber].quest.feedback;
        nomeTela.text = quests[questNumber].quest.npcName;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("QuestAccepted", 0);
        PlayerPrefs.SetInt("Feedback", 0);
        PlayerPrefs.SetInt("FeedbacksReceived", 0);
    }
}