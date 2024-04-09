using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("TemUpgrade")]
    [SerializeField] protected int maxLevel = 9;
    public int MaxLevel => maxLevel;

    protected virtual void Start()
    {
        //Invoke("Test", 5);
    }

    //protected virtual void Test()
    //{
    //    this.UpgradeItemByIndex(0);
    //    Debug.Log("Test");
    //}

    //===========================================public===========================================
    public virtual bool UpgradeItemByIndex(int itemsIndex)
    {
        ItemInventory itemInventory = GetItemInventoryByIndex(itemsIndex);
        if (itemInventory == null) return false;
        if (itemInventory.ItemAmount <= 0) return false;

        List<ItemUpgradeLevel> itemUpgradeLevels = itemInventory.ItemDropSO.ItemUpgradeLevel;
        if (!this.IsItemUpgradable(itemUpgradeLevels, itemInventory.UpgradeLevel)) return false;
        if (!this.HaveEnoughUpgradeMaterials(itemUpgradeLevels, itemInventory.UpgradeLevel)) return false;

        this.DeduceUpgradeMaterials(itemUpgradeLevels, itemInventory.UpgradeLevel);
        itemInventory.UpgradeLevel++;
        return true;
    }

    //=======================================ItemInventory========================================
    protected virtual ItemInventory GetItemInventoryByIndex(int index)
    {
        if (index < 0 || index > this.inventory.Items.Count) return null;
        return this.inventory.Items[index];
    }

    //========================================Upgrade Item========================================        
    protected virtual bool IsItemUpgradable(List<ItemUpgradeLevel> itemUpgradeLevels, int currLevel)
    {
        if (itemUpgradeLevels.Count <= 0) return false;
        if (itemUpgradeLevels.Count < currLevel) return false;

        //Debug.Log(transform.name + ": IsItemUpgradable", transform.gameObject);
        return true;
    }

    public virtual bool HaveEnoughUpgradeMaterials(List<ItemUpgradeLevel> itemUpgradeLevels, int currLevel)
    {
        List<ItemInventory> items = this.inventory.Items;
        foreach (ItemUpgradeRequire itemUpgradeRequire in itemUpgradeLevels[currLevel].ItemUpgradeRequires)
        {
            ItemCode itemCode = itemUpgradeRequire.ItemDropSO.ItemCode;
            int upgradeRequireAmount = itemUpgradeRequire.ItemAmount;
            if (!this.inventory.CheckItemAmountEnough(itemCode, upgradeRequireAmount)) return false;

            //Debug.Log(transform.name + ": EnoughItem " + itemUpgradeRequire.ItemDropSO.ItemCode.ToString(), transform.gameObject);
        }

        //Debug.Log(transform.name + ": HaveEnoughUpgradeMaterials", transform.gameObject);
        return true;
    }

    protected virtual void DeduceUpgradeMaterials(List<ItemUpgradeLevel> itemUpgradeLevels, int currLevel)
    {
        ItemCode itemCode;
        int requireAmount = 0;
        ItemUpgradeLevel currItemUpgradeLevel = itemUpgradeLevels[currLevel];

        foreach (ItemUpgradeRequire requireItem in currItemUpgradeLevel.ItemUpgradeRequires)
        {
            itemCode = requireItem.ItemDropSO.ItemCode;
            requireAmount = requireItem.ItemAmount;

            this.inventory.DeduceItem(itemCode, requireAmount);
        }

        //Debug.Log(transform.name + ": DeduceUpgradeMaterials", transform.gameObject);
    }
}
