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
    private int itemId1;
    private int itemId2;
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
        itemId1 = craftingInvetory.Container.Items[0].item.Id;
        itemId2 = craftingInvetory.Container.Items[1].item.Id;
        item1 = craftingInvetory.database.GetItem[itemId1].data;
        item2 = craftingInvetory.database.Items[itemId2].data;
    }
    
    public void DoCraft()
    {

        if (craftingInvetory.Container.Items[0].item.Id >= 0 && craftingInvetory.Container.Items[1].item.Id >= 0)
        {
            if (item1.craftingItemType != CraftingItemType.Nenhum)
            {
                switch (item1.craftingItemType)
                {
                    case CraftingItemType.Fruta:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Fruta:
                                item3 = craftingInvetory.database.GetItem[12].CreateItem();
                                activeQuest.QuestAtt(item3.nome, true);
                                craftingInvetory.AddItem(item3, 1);
                                clearCraftedItems();
                                break;
                            case CraftingItemType.Reagente:
                                switch (item1.craftingItemElement)
                                {
                                    case CraftingItemElement.Fogo:
                                        item3 = craftingInvetory.database.GetItem[21].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Gelo:
                                        item3 = craftingInvetory.database.GetItem[22].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Veneno:
                                        item3 = craftingInvetory.database.GetItem[23].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Eletrico:
                                        item3 = craftingInvetory.database.GetItem[24].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                }
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
                                clearCraftedItems();
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
                                clearCraftedItems();
                                break;
                        }
                        break;
                    case CraftingItemType.Partes:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Partes:
                                item3 = craftingInvetory.database.GetItem[28].CreateItem();
                                activeQuest.QuestAtt(item3.Id.ToString(), true);
                                craftingInvetory.AddItem(item3, 1);
                                clearCraftedItems();
                                break;
                        }
                        break;
                    case CraftingItemType.Essencia:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Reagente:
                                switch (item1.craftingItemElement)
                                {
                                    case CraftingItemElement.Fogo:
                                        item3 = craftingInvetory.database.GetItem[17].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Gelo:
                                        item3 = craftingInvetory.database.GetItem[18].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Veneno:
                                        item3 = craftingInvetory.database.GetItem[19].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Eletrico:
                                        item3 = craftingInvetory.database.GetItem[20].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                }
                                break;
                        }
                        break;
                    case CraftingItemType.Reagente:
                        switch (item2.craftingItemType)
                        {
                            case CraftingItemType.Essencia:
                                switch (item2.craftingItemElement)
                                {
                                    case CraftingItemElement.Fogo:
                                        item3 = craftingInvetory.database.GetItem[17].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Gelo:
                                        item3 = craftingInvetory.database.GetItem[18].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Veneno:
                                        item3 = craftingInvetory.database.GetItem[19].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Eletrico:
                                        item3 = craftingInvetory.database.GetItem[20].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                }
                                break;
                            case CraftingItemType.Fruta:
                                switch (item2.craftingItemElement)
                                {
                                    case CraftingItemElement.Fogo:
                                        item3 = craftingInvetory.database.GetItem[21].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Gelo:
                                        item3 = craftingInvetory.database.GetItem[22].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Veneno:
                                        item3 = craftingInvetory.database.GetItem[23].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                    case CraftingItemElement.Eletrico:
                                        item3 = craftingInvetory.database.GetItem[24].CreateItem();
                                        activeQuest.QuestAtt(item3.Id.ToString(), true);
                                        craftingInvetory.AddItem(item3, 1);
                                        clearCraftedItems();
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }

        }
        if (craftingInvetory.Container.Items[2].item.Id >= 0)
        {
            feedBackCraftingText.text = item3.nome + " construida";
        }
        else
        {
            feedBackCraftingText.text = "Nada construido";
        }

    }

    public void clearCraftedItems()
    {
        craftingInvetory.Container.Items[0].RemoveItem();
        craftingInvetory.Container.Items[1].RemoveItem();
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
