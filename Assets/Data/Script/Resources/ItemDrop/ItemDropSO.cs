using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item/Drop")]
public class ItemDropSO : ScriptableObject
{
    public ItemCode ItemCode;
    public ItemType ItemType;
    public string ItemName = "Item";
    public int DefaultMaxStack = 7;
    public List<ItemUpgradeLevel> ItemUpgradeLevel;
}
