using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : HuyMonoBehaviour
{
    [Header("Inventory")]
    [Header("Script")]
    [SerializeField] protected ItemLooter itemLooter;
    public ItemLooter ItemLooter => itemLooter;

    [SerializeField] protected ItemUpgrade itemUpgrade;
    public ItemUpgrade ItemUpgrade => itemUpgrade;

    [Header("Stat")]
    [SerializeField] protected int maxSlot = 70;
    public int MaxSlot => maxSlot;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemLooter();
        this.LoadItemUpgrade();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadItemLooter()
    {
        if (this.itemLooter != null) return;
        this.itemLooter = transform.Find("ItemLooter").GetComponent<ItemLooter>();
        Debug.LogWarning(transform.name + ": LoadItemLooter", transform.gameObject);
    }

    protected virtual void LoadItemUpgrade()
    {
        if (this.itemUpgrade != null) return;
        this.itemUpgrade = transform.Find("ItemUpgrade").GetComponent<ItemUpgrade>();
        Debug.Log(transform.name + ": LoadItemUpgrade", transform.gameObject);
    }

    //=========================================Modify Item========================================
    public virtual bool AddItem(ItemCode itemCode, int addAmount)
    {
        if (addAmount <= 0) return false;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.ItemDropSO.ItemCode) continue;
            if (itemInventory.ItemAmount >= itemInventory.MaxStack) continue;

            int newAmount = addAmount - (itemInventory.MaxStack - itemInventory.ItemAmount);
            if (newAmount <= 0)
            {
                itemInventory.ItemAmount += addAmount;
                addAmount = 0;
                break;
            }

            addAmount = newAmount;
            itemInventory.ItemAmount = itemInventory.MaxStack;
        }

        if (addAmount <= 0) return true;
        for (int i = 0; i < this.maxSlot; i++)
        {
            if (this.IsInventoryFull()) return false;

            ItemInventory newItemInvemtory = this.CreateEmptyItemInventory(itemCode);
            if (newItemInvemtory == null) return false;

            int newAmount = addAmount - newItemInvemtory.MaxStack;
            if (newAmount <= 0)
            {
                newItemInvemtory.ItemAmount = addAmount;
                break;
            }

            addAmount -= newItemInvemtory.MaxStack;
            newItemInvemtory.ItemAmount = newItemInvemtory.MaxStack;
        }

        return true;
    }

    protected virtual ItemInventory CreateEmptyItemInventory(ItemCode itemCode)
    {
        var itemDrops = Resources.LoadAll("ItemDrop", typeof(ItemDropSO));
        foreach (ItemDropSO itemDrop in itemDrops)
        {
            if (itemDrop.ItemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                ItemDropSO = itemDrop,
                MaxStack = itemDrop.DefaultMaxStack,
                ItemAmount = 0,
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }

    //========================================Upgrade Item========================================
    public virtual bool CheckItemAmountEnough(ItemCode itemCode, int checkAmount)
    {
        int totalAmount = this.TotalItemAmount(itemCode);
        return totalAmount > checkAmount;
    }

    public virtual void DeduceItem(ItemCode itemCode, int totalDeduceAmount)
    {
        ItemInventory itemInventory;
        int deduceAmount = 0;

        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (totalDeduceAmount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.ItemDropSO.ItemCode != itemCode) continue;

            if (totalDeduceAmount > itemInventory.ItemAmount)
            {
                deduceAmount = itemInventory.ItemAmount;
                totalDeduceAmount -= deduceAmount;
            }
            else
            {
                deduceAmount = totalDeduceAmount;
                totalDeduceAmount = 0;
            }

            this.items[i].ItemAmount -= deduceAmount;
            //Debug.Log(transform.name + ": DeduceItem", transform.gameObject);
        }

        this.RemoveEmptyItemInventory();
    }

    protected virtual int TotalItemAmount(ItemCode itemCode)
    {
        int totalAmount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemDropSO.ItemCode != itemCode) continue;
            totalAmount += itemInventory.ItemAmount;
        }

        return totalAmount;
    }

    public virtual void RemoveEmptyItemInventory()
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemAmount > 0) continue;
            this.items.Remove(itemInventory);
        }
    }

    ////=========================================Modify Item========================================
    //public virtual bool AddItem(ItemCode itemCode, int addCount)
    //{
    //    ItemDropSO itemDrop = this.GetItemDropSO(itemCode);

    //    int addRemain = addCount;
    //    int newCount;
    //    int itemMaxStack;
    //    int addMore;
    //    ItemInventory itemExist;
    //    for (int i = 0; i < this.maxSlot; i++)
    //    {
    //        itemExist = this.GetItemNotFullStack(itemCode);
    //        if (itemExist == null)
    //        {
    //            if (this.IsInventoryFull()) return false;

    //            itemExist = this.CreateEmptyItemInventory(itemDrop);
    //            this.items.Add(itemExist);
    //        }

    //        newCount = itemExist.ItemAmount + addCount;

    //        itemMaxStack = this.GetMaxStack(itemExist);
    //        if (newCount > itemMaxStack)
    //        {
    //            addMore = itemExist.MaxStack - itemExist.ItemAmount;
    //            newCount = itemExist.ItemAmount + addMore;
    //            addRemain -= addMore;
    //        }
    //        else
    //        {
    //            addRemain -= newCount;
    //        }

    //        itemExist.ItemAmount = newCount;
    //        if (addRemain <= 0) break;
    //    }
    //    return true;
    //}

    ////==========================================ItemDropSO========================================
    //protected virtual ItemDropSO GetItemDropSO(ItemCode itemCode)
    //{
    //    var itemDrops = Resources.LoadAll("ItemDrop", typeof(ItemDropSO));
    //    foreach (ItemDropSO itemDrop in itemDrops)
    //    {
    //        if (itemDrop.ItemCode != itemCode) continue;
    //        return itemDrop;
    //    }
    //    return null;
    //}

    ////============================================Stack===========================================
    //protected virtual bool IsFullStack(ItemInventory itemInventory)
    //{
    //    if (itemInventory == null) return true;
    //    return itemInventory.ItemAmount >= itemInventory.MaxStack;
    //}

    //protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    //{
    //    foreach (ItemInventory itemInventory in this.items)
    //    {
    //        if (itemCode != itemInventory.ItemDropSO.ItemCode) continue;
    //        if (this.IsFullStack(itemInventory)) continue;
    //        return itemInventory;
    //    }

    //    return null;
    //}

    //protected virtual int GetMaxStack(ItemInventory itemInventory)
    //{
    //    if (itemInventory == null) return 0;

    //    return itemInventory.MaxStack;
    //}

    ////=========================================Inventory==========================================
    //protected virtual bool IsInventoryFull()
    //{
    //    if (this.items.Count >= this.maxSlot) return true;
    //    return false;
    //}

    //protected virtual ItemInventory CreateEmptyItemInventory(ItemDropSO itemDropSO)
    //{
    //    ItemInventory itemInventory = new ItemInventory
    //    {
    //        ItemDropSO = itemDropSO,
    //        ItemAmount = 0,
    //        MaxStack = itemDropSO.DefaultMaxStack,
    //    };

    //    return itemInventory;
    //}
}
