using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HuyMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    //============================================Item============================================
    protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.ItemDropSO.ItemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyItemData(itemCode);
        return itemInventory;
    }

    //=========================================Modify Item========================================
    public virtual bool AddItem(ItemCode itemCode, int addAmount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newAmount = itemInventory.ItemAmount + addAmount;
        if (newAmount > itemInventory.MaxStack) return false;

        itemInventory.ItemAmount = newAmount;
        return true;
    }

    protected virtual ItemInventory AddEmptyItemData(ItemCode itemCode)
    {
        var itemDatas = Resources.LoadAll("ItemDrop", typeof(ItemDropSO));
        foreach(ItemDropSO itemData in itemDatas)
        {
            if (itemData.ItemCode != itemCode) continue;

            ItemInventory itemInventory = new ItemInventory
            {
                ItemDropSO = itemData,
                MaxStack = itemData.DefaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }

    public virtual bool DeduceItem(ItemCode itemCode, int deduceAmount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newAmount = itemInventory.ItemAmount - deduceAmount;
        if (newAmount < 0) return false;
        
        itemInventory.ItemAmount = newAmount;
        return true;
    }

    public virtual bool TryDeduceItem(ItemCode itemCode, int deduceAmount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newAmount = itemInventory.ItemAmount - deduceAmount;
        if (newAmount < 0) return false;
        return true;
    }
}
