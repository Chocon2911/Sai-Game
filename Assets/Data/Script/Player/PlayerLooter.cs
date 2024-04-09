using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooter : PlayerAbstract
{
    //===========================================Looter===========================================
    public virtual void LootItem(ItemPickedUp itemPickedUp)
    {
        ItemInventory itemInventory = itemPickedUp.GetItemInventory();
        if (this.playerManager.CurrShip.Inventory.AddItem(itemInventory))
        {
            itemPickedUp.Picked();
        }
    }
}
