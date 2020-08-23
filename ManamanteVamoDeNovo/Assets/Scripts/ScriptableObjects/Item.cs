using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Potion,
    Equipment,
    Crafting
}
public class Item : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(10,10)]
    public string description;
}
