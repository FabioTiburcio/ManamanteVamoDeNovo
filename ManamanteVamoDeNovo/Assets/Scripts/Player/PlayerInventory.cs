using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public Inventory playerTrash;

    public bool collidingWithItem;
    public bool collidingWithCraftingTable;
    public GameObject craftingTableUI;
    public GameObject mailboxUI;
    public GameObject robotUI;
    public GameObject itemCollided;
    public bool collidingWithMailBox;
    public bool collidingWithRobot;
    public PlayerQuest activeQuest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //inventory.Load();
        }
        if (Input.GetKeyDown(KeyCode.E) && collidingWithItem)
        {
            var item = itemCollided.GetComponent<GroundItem>().itemObject;
            if (item)
            {
                Item _item = new Item(item);
                if (inventory.AddItem(_item, 1))
                {
                    activeQuest.QuestAtt(_item.name, true);
                    itemCollided.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && collidingWithCraftingTable)
        {
            if (craftingTableUI.activeSelf)
            {
                craftingTableUI.SetActive(false);
                robotUI.SetActive(false);
            }
            else
            {
                craftingTableUI.SetActive(true);
                robotUI.SetActive(true);
            }

        }
        else if (Input.GetKeyDown(KeyCode.E) && collidingWithMailBox)
        {
            mailboxUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && collidingWithRobot)
        {
            if (robotUI.activeSelf)
            {
                robotUI.SetActive(false);
            }
            else
            {
                robotUI.SetActive(true);
            }
        }
        if (!collidingWithCraftingTable && !collidingWithRobot)
        {
            craftingTableUI.SetActive(false);
            robotUI.SetActive(false);
        }
        if (!collidingWithMailBox)
        {
            mailboxUI.SetActive(false);
        }
        if (!collidingWithRobot)
        {
            robotUI.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            collidingWithItem = true;
            itemCollided = other.gameObject;
        }
        else if(other.name == "CraftingTable")
        {
            collidingWithCraftingTable = true;
        }
        else if (other.name == "Correio")
        {
            collidingWithMailBox = true;
        }
        else if (other.name == "Robo")
        {
            collidingWithRobot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            collidingWithItem = false;
            itemCollided = null;
        }
        if(collision.name == "CraftingTable")
        {
            collidingWithCraftingTable = false;
        }
        if(collision.name == "Correio")
        {
            collidingWithMailBox = false;
        }
        if(collision.name == "Robo")
        {
            collidingWithRobot = false;
        }
        
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        playerTrash.Container.Clear();
    }
}
