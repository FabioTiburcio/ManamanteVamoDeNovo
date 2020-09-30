using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour {

    public QuestCtrl questController;
    public Quest quest;
    public bool questCompleted = false;
    private PlayerInventory inventario;
    public bool playerInRange;
    public ItemDatabaseObject itens;

    

// Start is called before the first frame update
void Start()
    {
        inventario = GetComponent<PlayerInventory>();
        Debug.Log(itens.Items[0].ToString());
        Debug.Log(itens.Items[1].ToString());
        Debug.Log(itens.Items[2].ToString());
        Debug.Log(itens.Items[3].ToString());
        Debug.Log(itens.Items[4].ToString());
        Debug.Log(itens.Items[5].ToString());
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true)
        {
            //Debug.Log("cara segunda interação aqui");
            if (questCompleted)
            {
                SearchItem();
                questController.NextQuestActivate();
                questCompleted = false;
            }

        }

        if (quest.isActive)
        {

            //Debug.Log(item.ToString());
            Debug.Log(quest.title);
            Debug.Log(quest.goal.requiredAmount);
            Debug.Log(quest.goal.goalTag);
            if (quest.goal.IsReached())
            {
                Debug.Log("DALE");
                quest.Complete();
                questCompleted = true;

            }

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
                } else if (quest.goal.goalType == GoalType.Gathering)
                {
                    Debug.Log("CRAFTEI");
                    quest.goal.ItemCrafted();
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

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Interacao1") playerInRange = true;
        
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Interacao1") playerInRange = false;
        
    }

     
}
