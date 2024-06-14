using System;

[Serializable]
public class ItemInventory
{
    public string ItemId;
    public ItemDropSO ItemDropSO;
    public int ItemAmount = 0;
    public int MaxStack = 7;
    public int UpgradeLevel = 0;

    public virtual ItemInventory CloneObjStat()
    {
        ItemInventory itemInventory = new ItemInventory();
        itemInventory.ItemId = ItemInventory.RandomId();
        itemInventory.ItemDropSO = this.ItemDropSO;
        itemInventory.ItemAmount = this.ItemAmount;
        itemInventory.MaxStack = this.MaxStack;
        itemInventory.UpgradeLevel = this.UpgradeLevel;
        return itemInventory;
    }

    public ItemInventory()
    {

    }

    public ItemInventory(ItemDropSO itemDropSO, int itemAmount, int maxStack, int upgradeLevel)
    {
        this.ItemId = ItemInventory.RandomId();
        this.ItemDropSO = itemDropSO;
        this.ItemAmount = itemAmount;
        this.MaxStack = maxStack;
        this.UpgradeLevel = upgradeLevel;
    }

    public static string RandomId()
    {
        int length = 10;

        return RandomString.GetRandomString(length);
    }
}
