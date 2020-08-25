using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Potion,
    Equipment,
    Crafting
}
public class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(10,10)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    public Item(ItemObject item)
    {
        name = item.name;
        Id = item.Id;
    }
}