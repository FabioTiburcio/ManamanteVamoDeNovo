using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CraftingItemType
{
    Nenhum,
    Fruta,
    Flor,
    Cogumelo,
    Partes,
    Essencia,
    Reagente
}

public enum CraftingItemElement
{
    Normal,
    Fogo,
    Veneno,
    Eletrico,
    Gelo
}

[CreateAssetMenu(fileName = "New Crafting Item", menuName = "Inventory System/Item/Crafting Item")]
public class CraftingItem : ItemObject
{
    //public CraftingItemType craftingItemType;
    //public CraftingItemElement craftingItemElement;
    private void Awake()
    {
        type = ItemType.Crafting;
    }
}
