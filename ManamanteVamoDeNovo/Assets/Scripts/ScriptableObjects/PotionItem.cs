using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    Nenhum,
    HealLow,
    HealMedium,
    HealHigh,
    HealPoison,
    HealFire,
    HealEletric,
    HealIce,
    IntensifyFire,
    IntensifyIce,
    IntensifyEletric,
    IntensifyPoison
}
[CreateAssetMenu(fileName = "New Potion Item", menuName = "Inventory System/Item/Potion Item")]
public class PotionItem : ItemObject
{
    //public PotionType potionType;
    private void Awake()
    {
        type = ItemType.Potion;
    }
}
