using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropAbstract : HuyMonoBehaviour
{
    [Header("IteamDropAbstract")]
    [Header("Script")]
    [SerializeField] protected ItemDropManager itemDropManager;
    public ItemDropManager ItemDropManager => itemDropManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadItemManager();
    }

    //========================================Load Component======================================
    protected virtual void LoadItemManager()
    {
        if (this.itemDropManager != null) return;
        this.itemDropManager = transform.parent.GetComponent<ItemDropManager>();
        Debug.Log(transform.name + ": LoadItemDropManager", transform.gameObject);
    }
}
