using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerQuest activeQuest;
    public Inventory craftingInvetory;
    public Inventory playerInventory;
    public Text feedBackCraftingText;
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



    }

    public void DoCraft()
    {
        if (craftingInvetory.Container.Items[0].item.Id >= 0 && craftingInvetory.Container.Items[1].item.Id >= 0)
        {
            item1 = craftingInvetory.Container.Items[0].item;
            item2 = craftingInvetory.Container.Items[1].item;
            if (item1.craftingItemType != CraftingItemType.Nenhum)
            {
                switch (item1.craftingItemType)
                {
                    case CraftingItemType.Fruta:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Fruta:
                                item3 = craftingInvetory.database.GetItem[12].CreateItem();
                                activeQuest.QuestAtt(item3.name, true);
                                craftingInvetory.AddItem(item3, 1);
                                craftingInvetory.RemoveAmount(item1);
                                craftingInvetory.RemoveAmount(item2);
                                break;
                        }
                        break;
                    case CraftingItemType.Cogumelo:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Cogumelo:
                                item3 = craftingInvetory.database.GetItem[11].CreateItem();
                                activeQuest.QuestAtt(item3.Id.ToString(), true);
                                craftingInvetory.AddItem(item3, 1);
                                craftingInvetory.RemoveAmount(item1);
                                craftingInvetory.RemoveAmount(item2);
                                break;
                        }
                        break;
                    case CraftingItemType.Flor:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Flor:
                                item3 = craftingInvetory.database.GetItem[10].CreateItem();
                                activeQuest.QuestAtt(item3.Id.ToString(), true);
                                craftingInvetory.AddItem(item3, 1);
                                craftingInvetory.RemoveAmount(item1);
                                craftingInvetory.RemoveAmount(item2);
                                break;
                        }
                        break;
                }
            }

        }
        if (craftingInvetory.Container.Items[2].item.Id >= 0)
        {
            feedBackCraftingText.text = item3.name + " construida";
        }
        else
        {
            feedBackCraftingText.text = "Nada construido";
        }

    }

    private void OnDisable()
    {
        feedBackCraftingText.text = "";
    }
    private void OnApplicationQuit()
    {
        craftingInvetory.Clear();
    }
}
