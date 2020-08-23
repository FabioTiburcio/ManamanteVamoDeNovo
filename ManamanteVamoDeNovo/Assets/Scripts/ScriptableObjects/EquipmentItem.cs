using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    PedraDeGelo,
    PedraDeFogo,
    PedraDeRaio,
    PedraDeVeneno
}

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Item/Equipment Item")]
public class EquipmentItem : Item
{
    public EquipmentType equipmentItem;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
