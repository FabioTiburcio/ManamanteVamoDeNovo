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
    public bool attDiaryInfo;
    public GameObject searchText;
    public AudioSource roboAudioSource;
    public AudioClip newMailArrives;
    private AudioSource playerAudioSource;
    public AudioClip writingDiaryClip;


    // Start is called before the first frame update
    void Start()
    {
        inventario = GetComponent<PlayerInventory>();
        playerAudioSource = GetComponent<AudioSource>();

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

        if (questCompleted)
        {
            SearchItem();
            //questController.NextQuestActivate();
            questCompleted = false;
            newEmailIcon.SetActive(true);
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
            Debug.Log(quest.goal.goalTag);
            if (!attDiaryInfo)
            {
                diaryInfoController.SetInfo(quest.title, quest.npcFoto, quest.diaryDescription, "Tarefas", "Primaria");
                playerAudioSource.PlayOneShot(writingDiaryClip);
                attDiaryInfo = true;
            }
            if (quest.goal.IsReached())
            {
                Debug.Log("DALE");
                quest.Complete();
                UpdateQuests();
                questCompleted = true;               
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

        if (tag == quest.goal.goalTag)
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
                } else if (quest.goal.goalType == GoalType.Crafting)
                {
                    Debug.Log("CRAFTEI");
                    quest.goal.ItemCrafted();
                } else if (quest.goal.goalType == GoalType.Searching)
                {
                    Debug.Log("PESQUISEI");
                    quest.goal.Searched();
                    searchText.SetActive(true);
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


    //public void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "Interacao1") playerInRange = true;
        
    //}

    //public void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "Interacao1") playerInRange = false;
        
    //}

     
}
