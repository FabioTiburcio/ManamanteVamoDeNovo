using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour {

    public QuestCtrl questController;
    public Quest quest;
    public QuestGiver[] questsList;
    public bool questCompleted = false;
    private PlayerInventory inventario;
    public bool playerInRange;
    public GameObject newEmailIcon;
    public ItemDatabaseObject itens;
    public DiaryInfoController diaryInfoController;
    public NotesAndMissionDiary notesAndMissionDiary;
    public bool attDiaryInfo;
    public GameObject searchText;
    public AudioSource roboAudioSource;
    public AudioClip newMailArrives;
    private AudioSource playerAudioSource;
    public AudioClip writingDiaryClip;
    private bool hasEndNote;
    private int questsCompletas;
    public ItemObject[] receitasBrinde;
    public int receipReceived;
    public EmailScreen telaMensagens;
    public int feedbacksReceived;
    public int feedbacksCompleted;
    public bool canGiveRewards;


    /*para atualizar receitas usar a funcao dessa forma
     diaryInfoController.SetInfo(item.itemObject.nome, item.itemObject.uiDisplay, item.itemObject.craftingDescription, "Dicas", "");
     É parecido com oque ta no script ItemScanner, só a descricao que muda pra craftingDescription e o fim ali que muda pra Dicas e pra vazio ""
     */



    // Start is called before the first frame update
    void Start()
    {
        inventario = GetComponent<PlayerInventory>();
        playerAudioSource = GetComponent<AudioSource>();
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("FeedbacksReceived", 0);
        PlayerPrefs.SetInt("Feedback", 0);
        //Debug.Log(itens.Items[0].ToString());
        //Debug.Log(itens.Items[1].ToString());
        //Debug.Log(itens.Items[2].ToString());
        //Debug.Log(itens.Items[3].ToString());
        //Debug.Log(itens.Items[4].ToString());
        //Debug.Log(itens.Items[5].ToString());
    }

    // Update is called once per frame
    void Update()
    {

        questsCompletas = PlayerPrefs.GetInt("QuestsCompleted");
        feedbacksReceived = PlayerPrefs.GetInt("FeedbacksReceived");
        feedbacksCompleted = PlayerPrefs.GetInt("Feedback");

        if (questCompleted)
        {
            SearchItem();
            //questController.NextQuestActivate();
            questCompleted = false;
            newEmailIcon.SetActive(true);
        }

        Debug.Log(questsCompletas);

        if (questsCompletas == 4)
        {
            diaryInfoController.SetInfo(receitasBrinde[2].nome, receitasBrinde[2].uiDisplay, receitasBrinde[2].craftingDescription, "Dicas", "");
            receipReceived++;
        }

        //if (Input.GetKeyDown(KeyCode.E) && playerInRange == true)
        //{
        //    //Debug.Log("cara segunda interação aqui");
        //    if (questCompleted)
        //    {
        //        SearchItem();
        //        //questController.NextQuestActivate();
        //        questCompleted = false;
        //        newEmailIcon.SetActive(true);
        //    }

        //}

        if (quest.isActive)
        {
            newEmailIcon.SetActive(false);
            //Debug.Log(item.ToString());
            Debug.Log(quest.title);
            Debug.Log(quest.goal.requiredAmount);
            Debug.Log(quest.goal.goalTag2);
            if (!attDiaryInfo)
            {
                //diaryInfoController.SetInfo(quest.title, quest.npcFoto, quest.diaryDescription, "Tarefas", "Primaria");
                playerAudioSource.PlayOneShot(writingDiaryClip);
                attDiaryInfo = true;
            }
            if (quest.goal.IsReached())
            {
                PlaySoundMissionComplete();
                if (feedbacksCompleted == questsCompletas)
                    PlayerPrefs.SetInt("Feedback", PlayerPrefs.GetInt("Feedback") + 1);
                if (canGiveRewards == true)
                {
                    playerAudioSource.PlayOneShot(writingDiaryClip);
                    Debug.Log("DALE");
                    quest.Complete();
                    UpdateQuests();
                    notesAndMissionDiary.MissionComplete(quest.hasEndNote);
                    questCompleted = true;
                    canGiveRewards = false;
                }
            }

        } else
        {
            newEmailIcon.SetActive(true);
            attDiaryInfo = false;
        }
    }



    public void QuestAtt(string tag, bool add)
    {
        Debug.Log(tag);
        Debug.Log(add);

        for (int i = 0; i < quest.goal.goalTag2.Count; i++)
        {
            if (tag == quest.goal.goalTag2[i])
            {
                if (add)
                {
                    if (quest.goal.goalType == GoalType.Kill)
                    {
                        Debug.Log("MATEI");
                        quest.goal.EnemyKilled();
                    }
                    else if (quest.goal.goalType == GoalType.Gathering)
                    {
                        Debug.Log("PEGUEI");
                        quest.goal.ItemGathered();
                    }
                    else if (quest.goal.goalType == GoalType.Crafting)
                    {
                        Debug.Log("CRAFTEI");
                        quest.goal.ItemCrafted();
                        quest.goal.goalTag2.RemoveAt(i);
                    }
                    else if (quest.goal.goalType == GoalType.Searching)
                    {
                        Debug.Log("PESQUISEI");
                        quest.goal.Searched();
                        searchText.SetActive(true);
                    }
                    else if (quest.goal.goalType == GoalType.Walking)
                    {
                        Debug.Log("VIAJEI");
                        quest.goal.Walked();
                    } else if (quest.goal.goalType == GoalType.ElementalKill)
                    {
                        quest.goal.ElementalKilled();
                        quest.goal.goalTag2.RemoveAt(i);
                    } else if (quest.goal.goalType == GoalType.Read)
                    {
                        quest.goal.Readed();
                    }

                }
            }
        }

        

    }

    public void SearchItem()
    {
        for (int i = 0; i < itens.Items.Length; i++)
        {
            if (i == quest.rewardId)
            {
                Item _item = new Item(itens.Items[i]);
                inventario.inventory.AddItem(_item, quest.rewardAmount);
                Debug.Log("Adicionei o itemmm");
            }           
        }
    }

    public void UpdateQuests()
    {
        PlayerPrefs.SetInt("QuestsCompleted", PlayerPrefs.GetInt("QuestsCompleted") + 1);
        
        roboAudioSource.clip = newMailArrives;
        roboAudioSource.PlayDelayed(2);
        
    }

    void PlaySoundMissionComplete()
    {
        roboAudioSource.clip = newMailArrives;
        roboAudioSource.PlayDelayed(2);
    }

    //public void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "Interacao1") playerInRange = true;

    //}

    //public void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "Interacao1") playerInRange = false;

    //}


}
