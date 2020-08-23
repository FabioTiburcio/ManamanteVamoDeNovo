using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<ItemObject>();
        if (item)
        {
            inventory.AddItem(item.itemObject, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
