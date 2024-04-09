using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    //=========================================Item Drop==========================================
    public virtual void DropItemByIndex(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex < this.inventory.Items.Count) return;

        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Vector2 dropPos = transform.parent.parent.position;
        dropPos += new Vector2(1, 0);
        Quaternion dropRot = transform.parent.parent.rotation;

        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropRot);
    }
}
