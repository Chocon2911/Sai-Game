using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : DespawnByDistance
{
    [Header("ItemDropDespawn")]
    [Header("Script")]
    [SerializeField] protected ItemDropManager itemDropManager;
    public ItemDropManager ItemDropManager => itemDropManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadItemManager();
        //Stat
        this.DefaultStat();
    }

    //========================================Load Component======================================
    protected virtual void LoadItemManager()
    {
        if (this.itemDropManager != null) return;
        this.itemDropManager = transform.parent.GetComponent<ItemDropManager>();
        Debug.Log(transform.name + ": LoadItemDropManager", transform.gameObject);
    }

    //============================================Despawn=========================================
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
    //============================================Other===========================================
    protected virtual void DefaultStat()
    {
        this.disLimit = 70;
    }
}
