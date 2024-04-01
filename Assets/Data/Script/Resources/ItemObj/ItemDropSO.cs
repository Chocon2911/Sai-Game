using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item/Obj")]
public class ItemDropSO : ScriptableObject
{
    public ItemCode ItemCode;
    public string ItemName = "Item";
}
