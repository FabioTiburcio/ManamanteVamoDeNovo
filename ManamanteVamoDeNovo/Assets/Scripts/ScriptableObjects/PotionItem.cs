using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    HealLow,
    HealMedium,
    HealHigh,
    HealPoison,
    HealFire,
    HealEletric,
    HealIce
}
[CreateAssetMenu(fileName = "New Potion Item", menuName = "Inventory System/Item/Potion Item")]
public class PotionItem : Item
{
    public PotionType potionType;
    private void Awake()
    {
        type = ItemType.Potion;
    }
}
