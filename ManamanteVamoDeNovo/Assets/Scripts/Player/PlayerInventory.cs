using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public Inventory inventory;
    public Inventory playerTrash;

    public bool collidingWithItem;
    public bool collidingWithCraftingTable;
    public GameObject craftingTableUI;
    public GameObject itemCollided;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            inventory.Load();
        }
        if (Input.GetKeyDown(KeyCode.E) && collidingWithItem)
        {
            var item = itemCollided.GetComponent<GroundItem>();
            if (item)
            {
                inventory.AddItem(new Item(item.itemObject), 1);
                Destroy(itemCollided.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && collidingWithCraftingTable)
        {
            craftingTableUI.SetActive(true);
        }
        if (!collidingWithCraftingTable)
        {
            craftingTableUI.SetActive(false);
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
        
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        playerTrash.Container.Clear();
    }
}
