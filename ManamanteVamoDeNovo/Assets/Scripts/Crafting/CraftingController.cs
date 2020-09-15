using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory craftingInvetory;
    public Inventory playerInventory;
    public Item item1;
    public Item item2;
    public Item item3;
    void Start()
    {
        item1 = null;
        item2 = null;
        item3 = null;
        //craftingInvetory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (craftingInvetory.Container.Items[0].item.Id >= 0 && craftingInvetory.Container.Items[1].item.Id >= 0)
        {
            item1 = craftingInvetory.Container.Items[0].item;
            item2 = craftingInvetory.Container.Items[1].item;
            if(item1.craftingItemType != CraftingItemType.Nenhum)
            {
                switch (item1.craftingItemType)
                {
                    case CraftingItemType.Fruta:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Fruta:
                                item3 = craftingInvetory.database.GetItem[1].CreateItem();
                                craftingInvetory.AddItem(item3, 1);
                                craftingInvetory.RemoveAmount(item1);
                                craftingInvetory.RemoveAmount(item2);
                                break;
                        }
                        break;
                }
            }
            else if(item1.potionType != PotionType.Nenhum)
            {
                switch (item1.potionType)
                {
                    case PotionType.HealLow:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Flor:
                                item3 = craftingInvetory.database.GetItem[2].CreateItem();
                                craftingInvetory.AddItem(item3, 1);
                                craftingInvetory.RemoveAmount(item1);
                                craftingInvetory.RemoveAmount(item2);
                                break;
                        }
                        break;
                }
            }
           
        }


    }
    private void OnApplicationQuit()
    {
        craftingInvetory.Clear();
    }
}
