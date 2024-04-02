using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooter : PlayerAbstract
{
    //===========================================Looter===========================================
    public virtual void LootItem(ItemPickedUp itemPickedUp)
    {
        Debug.Log(transform.name + ": Loot Item", transform.gameObject);

        ItemCode itemCode = itemPickedUp.GetItemCode();
        if (this.playerManager.CurrShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickedUp.Picked();
        }
    }
}
