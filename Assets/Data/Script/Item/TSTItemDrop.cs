using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTItemDrop : JunkAbstract
{
    [SerializeField] protected int dropTimes = 0;
    [SerializeField] protected int dropCount = 0;
    [SerializeField] protected int rate;

    protected virtual void Start()
    {
        InvokeRepeating(nameof(this.DropItem), 2, 1f);
    }

    protected virtual void DropItem()
    {
        List<ItemDropRate> itemDropRates = new List<ItemDropRate>();
        itemDropRates = this.junkManager.ShootableObjSO.DropList;

        Vector2 spawnPos = transform.parent.position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        List<ItemDropSO> droppedItems = ItemDropSpawner.Instance.DropItem(itemDropRates, spawnPos, spawnRot);

        this.dropTimes += itemDropRates.Count;
        this.dropCount += droppedItems.Count;
        this.rate = this.dropCount * 100 / this.dropTimes;
    }
}