using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    [Header("UI Inventory Spawner")]
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    protected string itemOne = "UIItem_1";
    public string ItemOne => itemOne;

    [Header("Script")]
    [SerializeField] protected UIInventoryManager manager;
    public UIInventoryManager Manager => manager;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One UIInvItemSpawner Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        this.LoadUIInvManager();
        base.LoadComponent();
    }

    //==========================================Spawner===========================================
    protected virtual void LoadUIInvManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.parent.GetComponent<UIInventoryManager>();
        Debug.LogWarning(transform.name + ": LoadUIInvManager", transform.gameObject);
    }
    
    protected override void LoadHolderTrans()
    {
        if (this.holderTrans != null) return;
        if (this.manager == null) return;
        this.holderTrans = this.manager.ContentTrans;
        Debug.LogWarning(transform.name + ": LoadHolderTrans", transform.gameObject);
    }

    //============================================Item============================================
    public virtual void ClearItems()
    {
        foreach (Transform item in this.holderTrans)
        {
            this.Despawn(item);
        }
    }
}
