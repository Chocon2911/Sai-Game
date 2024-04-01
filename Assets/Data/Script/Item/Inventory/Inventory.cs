using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : HuyMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected virtual void Start()
    {
        this.AddItem(ItemCode.Iron, 1);
        this.AddItem(ItemCode.Iron, 1);
        this.AddItem(ItemCode.Gold, 3);
        this.AddItem(ItemCode.Gold, 6);
    }

    //===========================================Public===========================================
    public virtual bool AddItem(ItemCode itemCode, int addAmount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newAmount = itemInventory.ItemAmount + addAmount;
        if (newAmount > itemInventory.MaxStack) return false;

        itemInventory.ItemAmount = newAmount;
        return true;
    }

    //============================================Item============================================
    protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.ItemDataSO.ItemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyItemData(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyItemData(ItemCode itemCode)
    {
        var itemDatas = Resources.LoadAll("ItemData", typeof(ItemDataSO));
        foreach(ItemDataSO itemData in itemDatas)
        {
            if (itemData.ItemCode != itemCode) continue;

            ItemInventory itemInventory = new ItemInventory
            {
                ItemDataSO = itemData,
                MaxStack = itemData.DefaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }
}
