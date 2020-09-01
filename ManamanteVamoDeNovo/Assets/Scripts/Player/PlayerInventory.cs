using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public Inventory inventory;

    public bool collidingWithItem;
    public GameObject itemCollided;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Item")
        {
            collidingWithItem = true;
            itemCollided = other.gameObject;
        }
    }
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
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[20];
    }
}
