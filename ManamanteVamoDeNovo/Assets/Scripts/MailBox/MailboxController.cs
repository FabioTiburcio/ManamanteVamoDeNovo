using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxController : MonoBehaviour
{
    public Inventory mailboxInventory;
    public int emptySlots;
    public float totalValue;
    public float tempValue;
    private void Start()
    {
        emptySlots = mailboxInventory.EmptySlotCount;
    }
    private void Update()
    {
        if (mailboxInventory.EmptySlotCount < emptySlots)
        {
            ValueCalculator(true);
            emptySlots = mailboxInventory.EmptySlotCount;
        }
        else if (mailboxInventory.EmptySlotCount > emptySlots)
        {
            ValueCalculator(false);
            emptySlots = mailboxInventory.EmptySlotCount;
        }
        else if (mailboxInventory.changedItem)
        {
            ValueCalculator(true);
            mailboxInventory.changedItem = false;
        }
    }

    public void ValueCalculator(bool enterItem)
    {
        if (enterItem)
        {
            totalValue = 0;
        }
        for (int i = 0; i < mailboxInventory.Container.Items.Length; i++)
        {
            if (enterItem)
            {
                tempValue = mailboxInventory.Container.Items[i].item.marketValue * mailboxInventory.Container.Items[i].amount;
                totalValue += tempValue;
            }
            else
            {
                tempValue = mailboxInventory.itemRemovedFromMailbox.marketValue * mailboxInventory.itemRemovedAmount;
                totalValue -= tempValue;
                break;
            }
            tempValue = 0;
        }     
    }

    private void OnApplicationQuit()
    {
        mailboxInventory.Clear();
    }
}
