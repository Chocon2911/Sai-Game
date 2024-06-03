using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTItemDrop : JunkAbstract
{
    protected virtual void Start()
    {
        InvokeRepeating(nameof(this.DropItem), 2, 1f);
    }

    protected virtual void DropItem()
    {
        List<ItemDropRate> itemDropRates = new List<ItemDropRate>();
        itemDropRates = this.junkManager.ShootableObjSO.DropList;

        ItemDropSpawner.Instance.DropItem(itemDropRates, transform.parent.position, Quaternion.Euler(0, 0, 0));
    }
}
