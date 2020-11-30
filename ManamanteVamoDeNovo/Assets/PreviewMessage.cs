using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewMessage : MonoBehaviour
{

    public Image fotoTela;
    public Text assuntoTela;
    public Text nomeTela;
    public int questNumber;
    public EmailScreen email;
    private int questsCompleted;
    private int questAccepted;
    public GameObject newMessage;
    public bool isFeedback;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        questAccepted = PlayerPrefs.GetInt("QuestAccepted");
        
        if (questAccepted == questNumber + 1 || questAccepted > questNumber + 1)
        {
            newMessage.SetActive(false);
        }
        else
        {
            newMessage.SetActive(true);
        }
        fotoTela.sprite = email.quests[questNumber].quest.npcFoto;
        if (isFeedback)
        {
            assuntoTela.text = "Resposta: " + email.quests[questNumber].quest.title;
        } else
        {
            assuntoTela.text = email.quests[questNumber].quest.title;
        }
        
        nomeTela.text = email.quests[questNumber].quest.npcName;
    }
}
