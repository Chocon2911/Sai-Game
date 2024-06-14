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

    //==========================================Add Item==========================================
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addAmount = itemInventory.ItemAmount;
        ItemDropSO itemDropSO = itemInventory.ItemDropSO;
        ItemCode itemCode = itemDropSO.ItemCode;
        ItemType itemType = itemDropSO.ItemType;

        if (itemType == ItemType.Equipment) return this.AddEquipment(itemInventory);
        else if (itemType == ItemType.Resource) return this.AddResource(itemCode, addAmount);

        return false;
    }

    public virtual bool AddEquipment(ItemInventory itemInventory)
    {
        if (this.IsInventoryFull()) return false;

        this.items.Add(itemInventory.CloneObjStat());

        return true;
    }

    //========================================Upgrade Item========================================
    public virtual bool CheckItemAmountEnough(ItemCode itemCode, int checkAmount)
    {
        int totalAmount = this.TotalItemAmount(itemCode);
        return totalAmount >= checkAmount;
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
        List<ItemInventory> removeItems = new List<ItemInventory>();
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.ItemAmount > 0) continue;
            removeItems.Add(itemInventory);
        }

        foreach(ItemInventory removeItemInventory in removeItems)
        {
            this.items.Remove(removeItemInventory);
        }
    }

    //=======================================ItemInventory========================================
    public virtual bool AddResource(ItemCode itemCode, int addCount)
    {
        ItemDropSO itemDrop = this.GetItemDropSO(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;

                itemExist = this.CreateEmptyItemInventory(itemDrop);
                this.items.Add(itemExist);
            }

            newCount = itemExist.ItemAmount + addCount;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemExist.MaxStack - itemExist.ItemAmount;
                newCount = itemExist.ItemAmount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.ItemAmount = newCount;
            if (addRemain <= 0) break;
        }
        return true;
    }

    //==========================================ItemDropSO========================================
    protected virtual ItemDropSO GetItemDropSO(ItemCode itemCode)
    {
        var itemDrops = Resources.LoadAll("ItemDrop", typeof(ItemDropSO));
        foreach (ItemDropSO itemDrop in itemDrops)
        {
            if (itemDrop.ItemCode != itemCode) continue;
            return itemDrop;
        }
        return null;
    }

    //============================================Stack===========================================
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        return itemInventory.ItemAmount >= itemInventory.MaxStack;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.ItemDropSO.ItemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.MaxStack;
    }

    //=========================================Inventory==========================================
    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }

    protected virtual ItemInventory CreateEmptyItemInventory(ItemDropSO itemDropSO)
    {
        int newItemAmount = 0;
        int newItemMaxStack = itemDropSO.DefaultMaxStack;
        int newItemUpgradeLevel = itemDropSO.ItemUpgradeLevel.Count;

        ItemInventory itemInventory = new ItemInventory(itemDropSO, newItemAmount, newItemMaxStack, newItemUpgradeLevel);
        return itemInventory;
    }
}
