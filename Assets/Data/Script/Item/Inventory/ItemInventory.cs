using System;

[Serializable]
public class ItemInventory
{
    public ItemDropSO ItemDropSO;
    public int ItemAmount = 0;
    public int MaxStack = 7;
    public int UpgradeLevel = 0;
}
