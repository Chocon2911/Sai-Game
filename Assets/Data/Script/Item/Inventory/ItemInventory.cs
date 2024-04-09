using System;

[Serializable]
public class ItemInventory
{
    public ItemDropSO ItemDropSO;
    public int ItemAmount = 0;
    public int MaxStack = 7;
    public int UpgradeLevel = 0;

    public virtual ItemInventory CloneObjStat()
    {
        ItemInventory itemInventory = new ItemInventory();
        itemInventory.ItemDropSO = this.ItemDropSO;
        itemInventory.ItemAmount = this.ItemAmount;
        itemInventory.MaxStack = this.MaxStack;
        itemInventory.UpgradeLevel = this.UpgradeLevel;
        return itemInventory;
    }
}
