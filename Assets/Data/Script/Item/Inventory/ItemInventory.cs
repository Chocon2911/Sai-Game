using System;

[Serializable]
public class ItemInventory
{
    public ItemDataSO ItemDataSO;
    public ItemType ItemTypes;
    public int ItemAmount = 0;
    public int MaxStack = 7;
}
