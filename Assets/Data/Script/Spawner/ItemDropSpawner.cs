using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    [Header("ItemSpawner")]
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one ItemSpawner exists at a time", transform.gameObject);
        instance = this;
    }

    //==========================================ItemDrop==========================================
    public virtual void Drop(List<DropRate> dropList, Vector2 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].ItemDropSO.ItemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) Debug.LogWarning(transform.name + ": No Item name " + itemCode.ToString(), transform.gameObject);
        itemDrop.gameObject.SetActive(true);
    }
}
