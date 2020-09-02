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
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [Header ("Arrumar apenas o referente ao tipo do item acima.")]
    public PotionType potionType;
    public CraftingItemType craftingItemType;
    public EquipmentType equipmentType;
    [Header("")]
    [TextArea(10,10)]
    public string description;
    public ItemBuff[] buffs;
    public float marketValue;
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    public ItemBuff[] buffs;
    public ItemType type;
    public PotionType potionType;
    public CraftingItemType craftingItemType;
    public EquipmentType equipmentType;
    public Item()
    {
        name = "";
        Id = -1;
        type = ItemType.Default;
    }
    public Item(ItemObject item)
    {
        name = item.name;
        Id = item.Id;
        type = item.type;
        potionType = item.potionType;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max)
            {
                attribute = item.buffs[i].attribute
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