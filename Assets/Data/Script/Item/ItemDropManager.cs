using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDropManager : HuyMonoBehaviour
{
    [Header("Script")]
    [SerializeField] protected ItemDropDespawn itemDespawn;
    public ItemDropDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemPickedUp itemPickedUp;
    public ItemPickedUp ItemPickedUp => itemPickedUp;

    [Header("Stat")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script;
        this.LoadItemDespawn();
        this.LoadItemPickedUp();
        //Stat
        this.LoadItemInventory();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //========================================Load Component======================================
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.Find("Despawn").GetComponent<ItemDropDespawn>();
        Debug.Log(transform.name + ": LoadItemDropDespawn", transform.gameObject);
    }

    protected virtual void LoadItemPickedUp()
    {
        if (this.ItemPickedUp != null) return;
        this.itemPickedUp = transform.Find("ItemPickedUp").GetComponent<ItemPickedUp>();
        Debug.Log(transform.name + ": LoadItemPickedUp", transform.gameObject);
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.ItemDropSO != null) return;
        string pathSO = "ItemDrop/" + transform.name;
        this.itemInventory.ItemDropSO = Resources.Load<ItemDropSO>(pathSO);
        this.itemInventory.MaxStack = this.itemInventory.ItemDropSO.DefaultMaxStack;
        this.itemInventory.ItemAmount = 1;
        this.itemInventory.UpgradeLevel = 0;
        Debug.LogWarning(transform.name + ": LoadItemInventory", transform.gameObject);
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.itemInventory.ItemAmount = 1;
        this.itemInventory.UpgradeLevel = 0;
    }
    
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.CloneObjStat();
    }
}
