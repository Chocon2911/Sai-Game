using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TSTItemDrop : JunkAbstract
{
    [SerializeField] protected List<ItemDropCount> itemDropCounts = new List<ItemDropCount>();

    protected virtual void OnEnable()
    {
        InvokeRepeating(nameof(this.DropItem), 2, 1f);
    }

    protected virtual void DropItem()
    {
        List<ItemDropRate> itemDropRates = new List<ItemDropRate>();
        itemDropRates = this.junkManager.ShootableObjSO.DropList;

        if (itemDropRates.Count <= 0) return;
        this.IncreaseItemDropCount(itemDropRates);

        Vector2 spawnPos = transform.parent.position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        List<ItemDropSO> droppedItems = ItemDropSpawner.Instance.DropItem(itemDropRates, spawnPos, spawnRot);

        if (droppedItems.Count <= 0) return;
        this.IncreaseItemDropTimes(droppedItems);
    }

    //==========================================Increase==========================================
    protected virtual void IncreaseItemDropCount(List<ItemDropRate> itemDropRates)
    {
        foreach (ItemDropRate itemDropRate in itemDropRates)
        {
            ItemDropCount itemDropCount = this.itemDropCounts.
                Find(item => item.itemDropSO.ItemName == itemDropRate.ItemDropSO.ItemName);
            
            if (itemDropCount == null)
            {

                itemDropCount = new ItemDropCount();
                itemDropCount.itemDropSO = itemDropRate.ItemDropSO;
                itemDropCount.dropTimes = 0;
                itemDropCount.dropCount = 0;
                itemDropCount.rate = 0;
                this.itemDropCounts.Add(itemDropCount);
            }

            itemDropCount.dropCount++;
        }
    }

    protected virtual void IncreaseItemDropTimes(List<ItemDropSO> droppedItems)
    {
        foreach (ItemDropSO droppedItem in droppedItems)
        {
            ItemCode droppedItemCode = droppedItem.ItemCode;
            ItemDropCount itemDropCount = this.itemDropCounts.Find(item => item.itemDropSO.ItemName == droppedItem.ItemName);

            itemDropCount.dropTimes++;
            itemDropCount.rate = Mathf.Round((float)itemDropCount.dropTimes * 100 / itemDropCount.dropCount * 100) / 100;
        }
    }
}

[Serializable]
public class ItemDropCount
{
    public ItemDropSO itemDropSO;
    public int dropTimes;
    public int dropCount;
    public float rate;
}