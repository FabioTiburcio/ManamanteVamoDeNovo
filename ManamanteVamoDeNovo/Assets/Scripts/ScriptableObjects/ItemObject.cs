using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Potion,
    Equipment,
    Crafting, 
    Default
}

public enum Attributes
{
    Agility,
    Intelligence,
    Stamina,
    Strength,
}

public class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public string nome;
    public bool stackable;
    public ItemType type;
    [Header ("Arrumar apenas o referente ao tipo do item acima.")]
    public PotionType potionType;
    public CraftingItemType craftingItemType;
    public CraftingItemElement craftingItemElement;
    public EquipmentType equipmentType;
    [Header("")]
    [TextArea(10,10)]
    public string description;
    [TextArea(10, 10)]
    public string craftingDescription;
    public float marketValue;
    public Item data = new Item();
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string nome;
    public int Id = -1;
    public ItemBuff[] buffs;
    public ItemType type;
    public PotionType potionType;
    public CraftingItemType craftingItemType;
    public CraftingItemElement craftingItemElement;
    public EquipmentType equipmentType;
    public float marketValue;
    public Item()
    {
        nome = "";
        Id = -1;
        type = ItemType.Default;
    }
    public Item(ItemObject item)
    {
        nome = item.nome;
        Id = item.data.Id;
        type = item.type;
        potionType = item.potionType;
        craftingItemType = item.craftingItemType;
        craftingItemElement = item.craftingItemElement;
        equipmentType = item.equipmentType;
        marketValue = item.marketValue;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
            {
                attribute = item.data.buffs[i].attribute
            };
            
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }
    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}