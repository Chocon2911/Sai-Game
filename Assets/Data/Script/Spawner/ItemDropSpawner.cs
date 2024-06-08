using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    [Header("ItemSpawner")]
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [SerializeField] protected float gameDropRate = 1f;
    public float GameDropRate => gameDropRate;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one ItemSpawner exists at a time", transform.gameObject);
        instance = this;
    }

    //==========================================ItemDrop==========================================
    public virtual List<ItemDropSO> DropItem(List<ItemDropRate> dropList, Vector2 pos, Quaternion rot)
    {
        List<ItemDropSO> itemDrops = new List<ItemDropSO>();

        if (dropList.Count <= 0) return itemDrops;

        itemDrops = DropItemByRate(dropList);
        if (itemDrops.Count <= 0) return itemDrops;

        float distanceBtwObj = 0.5f;
        foreach (var itemDrop in itemDrops)
        {
            pos = new Vector2(pos.x + distanceBtwObj, pos.y); // Not good

            ItemCode itemCode = itemDrop.ItemCode;
            Transform itemObj = this.Spawn(itemCode.ToString(), pos, rot);

            if (itemObj == null) Debug.LogWarning(transform.name + "No Item name " + itemCode.ToString(), transform.gameObject); 
            itemObj.gameObject.SetActive(true);
            //Debug.Log("Drop");
        }

        return itemDrops;
    }

    public virtual void DropFromInventory(ItemInventory itemInventory, Vector2 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.ItemDropSO.ItemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) Debug.LogWarning(transform.name + ": No item name " + itemCode.ToString(), transform.gameObject);
        
        ItemDropManager itemDropManager = itemDrop.GetComponent<ItemDropManager>();
        itemDropManager.SetItemInventory(itemInventory);
        itemDrop.gameObject.SetActive(true);
    }

    protected virtual List<ItemDropSO> DropItemByAmount(ItemDropSO itemDropSO, int amount)
    {
        if (amount < 0) return null;

        List<ItemDropSO> newDroppedItems = new List<ItemDropSO>();
        for (int i = 0; i < amount; i++)
        {
            newDroppedItems.Add(itemDropSO);
        }

        return newDroppedItems;
    }

    //=========================================Drop Rate==========================================
    protected virtual List<ItemDropSO> DropItemByRate(List<ItemDropRate> itemDropRates)
    {
        List<ItemDropSO> itemDrops = new List<ItemDropSO>();

        foreach (ItemDropRate itemDropRate in itemDropRates)
        {
            float error = 0.0001f;
            int dropAmount = Mathf.CeilToInt(itemDropRate.DropRate / 100 * this.gameDropRate - Random.Range(0f, 1f) + error);

            if (dropAmount <= 0) continue;

            List<ItemDropSO> newDroppedItems = this.DropItemByAmount(itemDropRate.ItemDropSO, dropAmount);
            itemDrops.AddRange(newDroppedItems);
        }

        return itemDrops;
    }
}
