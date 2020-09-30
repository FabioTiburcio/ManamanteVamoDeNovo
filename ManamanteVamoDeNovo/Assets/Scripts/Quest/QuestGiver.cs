using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerQuest player;
    public bool playerInRange = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true && quest.isActive == false)
        {
            AcceptQuest();
        }
    }

    public void AcceptQuest()
    {
        quest.isActive = true;
        player.quest = quest;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = true;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") playerInRange = false;
    }

}
