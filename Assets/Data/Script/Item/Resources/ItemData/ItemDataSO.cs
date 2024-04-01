using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item/Data")]
public class ItemDataSO : ScriptableObject
{
    public ItemCode ItemCode;
    public ItemType ItemType;
    public string ItemName = "Item";
    public int DefaultMaxStack = 7;
}
