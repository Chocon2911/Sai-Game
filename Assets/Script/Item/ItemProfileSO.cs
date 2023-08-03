using UnityEngine;

[CreateAssetMenu(fileName = "ItemProFileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no_name";
    public int defaultMaxStack = 7;
}
