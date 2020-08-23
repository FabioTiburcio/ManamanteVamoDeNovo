using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CraftingItemType
{
    Fruta,
    Flor,
    Cogumelo,
    Asas,
    Coracao, 
    Presas,
    Folha,
    Olhos,
    Penas,
    Pele,
    Osso,
    Essencia,
    Musgo,
    Chifres
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
public class CraftingItem : Item
{
    public CraftingItemType craftingItemType;
    public CraftingItemElement craftingItemElement;
    private void Awake()
    {
        type = ItemType.Crafting;
    }
}
