using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory craftingInvetory;
    public Item item1;
    public Item item2;
    public Item item3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(craftingInvetory.Container.Items);
        item1 = craftingInvetory.Container.Items[0].item;
        item2 = craftingInvetory.Container.Items[1].item;
        switch (item1.craftingItemType)
        {
            case CraftingItemType.Fruta:
                switch (item2.craftingItemType)
                {
                    case CraftingItemType.Fruta:
                        item3 = craftingInvetory.database.GetItem[1].CreateItem();
                        break;
                }
                craftingInvetory.AddItem(item3, 1);
                break;
        }
    }
}
