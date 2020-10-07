using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory",menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public InventoryCallback Container;
    public Item itemRemovedFromMailbox;
    public int itemRemovedAmount;
    public bool changedItem = false;
    
    public bool AddItem(Item _item, int _amount)
    {
        if(EmptySlotCount <= 0)
        {
            return false;
        }
        InventorySlot slot = FindItemOnInventory(_item);
        if (!database.GetItem[_item.Id].stackable || slot == null)
        {
            SetEmptySlot(_item, _amount);
            return true;
        }
        slot.AddAmount(_amount);
        return true;
    }
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < Container.Items.Length; i++)
            {
                if (Container.Items[i].item.Id <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].item.Id == _item.Id)
            {
                return Container.Items[i];
            }
        }
        return null;
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].item.Id <= -1)
            {
                Container.Items[i].UpdateSlot(_item, _amount);
                return Container.Items[i];
            }
        }
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.item, item2.amount);
            if (item2.parent.inventory.name == "CraftingSystem")
            {
                item2.UpdateSlot(item1.item, 1);
                if (item1.amount > 1)
                {
                    item1.UpdateSlot(item1.item, item1.amount - 1);
                }
                else
                {
                    item2.UpdateSlot(item1.item, item1.amount);
                    item1.UpdateSlot(temp.item, temp.amount);
                }
                return;
            }
            if(item1.parent.inventory.name == "MailboxInventory")
            {
                itemRemovedFromMailbox = item1.item;
                itemRemovedAmount = item1.amount;
            }
            if (item1.parent.inventory.name == "MailboxInventory" || item2.parent.inventory.name == "MailboxInventory")
            {
                changedItem = true;
                item2.parent.inventory.changedItem = true;
            }
            if (item2.item.Id == item1.item.Id && item2.parent != item1.parent)
            {
                item2.AddAmount(item1.amount);
                item1.RemoveItem();
            }
            else
            {
                item2.UpdateSlot(item1.item, item1.amount);
                item1.UpdateSlot(temp.item, temp.amount);
            }
        }
    }
    public void UseItem(Item _item)
    {
        
        switch (_item.type)
        {
            case ItemType.Crafting:
                switch (_item.craftingItemType)
                {
                    case CraftingItemType.Asas:
                        break;
                    case CraftingItemType.Chifres:
                        break;
                    case CraftingItemType.Cogumelo:
                        break;
                    case CraftingItemType.Coracao:
                        break;
                    case CraftingItemType.Essencia:
                        break;
                    case CraftingItemType.Flor:
                        break;
                    case CraftingItemType.Folha:
                        break;
                    case CraftingItemType.Fruta:
                        break;
                    case CraftingItemType.Musgo:
                        break;
                    case CraftingItemType.Olhos:
                        break;
                    case CraftingItemType.Osso:
                        break;
                    case CraftingItemType.Pele:
                        break;
                    case CraftingItemType.Penas:
                        break;
                    case CraftingItemType.Presas:
                        break;
                }
                break;
            case ItemType.Equipment:
                switch (_item.equipmentType)
                {
                    case EquipmentType.PedraDeFogo:
                        Debug.Log("Habilidade de fogo");
                        break;
                    case EquipmentType.PedraDeGelo:
                        Debug.Log("Habilidade de gelo");
                        break;
                    case EquipmentType.PedraDeRaio:
                        Debug.Log("Habilidade de raio");
                        break;
                    case EquipmentType.PedraDeVeneno:
                        Debug.Log("Habilidade de Veneno");
                        break;
                }
                break;
            case ItemType.Potion:
                switch (_item.potionType)
                {
                    case PotionType.HealLow:
                        Health.HealAmount(10);
                        break;
                    case PotionType.HealMedium:
                        Health.HealAmount(20);
                        break;
                    case PotionType.HealHigh:
                        Health.HealAmount(30);
                        break;
                    case PotionType.HealFire:
                        Debug.Log("Curou Queimadura");
                        break;
                    case PotionType.HealEletric:
                        Debug.Log("Curou eletricidade");
                        break;
                    case PotionType.HealPoison:
                        Debug.Log("Curou Veneno");
                        break;
                    case PotionType.HealIce:
                        Debug.Log("Curou Gelo");
                        break;
                }
                RemoveAmount(_item);
                break;
        }
    }
    public void RemoveAmount(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].item == _item)
            {
                if (Container.Items[i].amount > 1)
                {
                    Container.Items[i].UpdateSlot(_item, Container.Items[i].amount-1);
                }
                else
                {
                    Container.Items[i].RemoveItem();
                }
            }
        }
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].item == _item)
            {
                Container.Items[i].RemoveItem();
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();
        //Debug.Log("save");

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {

        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            InventoryCallback newContainer = (InventoryCallback)formatter.Deserialize(stream);
            for (int i = 0; i < Container.Items.Length; i++)
            {
                Container.Items[i].UpdateSlot(newContainer.Items[i].item, newContainer.Items[i].amount);
            }
            stream.Close();
        }
        Debug.Log("Load");
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }
}
[System.Serializable]
public class InventoryCallback
{
    public InventorySlot[] Items = new InventorySlot[20];
    public void Clear()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].RemoveItem();
        }
    }
}
[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0];
    public UserInterface parent;
    public Item item;
    public int amount;

    public ItemObject ItemObject
    {
        get
        {
            if(item.Id >= 0)
            {
                return parent.inventory.database.GetItem[item.Id];
            }
            return null;
        }
    }

    public InventorySlot()
    {
        item = new Item();
        amount = 0;
    }
    public InventorySlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void UpdateSlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void RemoveItem()
    {
        item = new Item();
        amount = 0;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if (AllowedItems.Length <= 0 || _itemObject == null || _itemObject.data.Id < 0)
            return true;
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if (_itemObject.type == AllowedItems[i])
                return true;
        }
        return false;
    }
}
