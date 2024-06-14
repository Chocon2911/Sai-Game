using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryShow : UiInventoryAbstract
{
    [Header("UI Inventory Show")]
    [Header("Script")]
    [SerializeField] protected UIInventorySort uiInvSort;
    public UIInventorySort UIInvSort => uiInvSort;

    [Header("Other")]

    [SerializeField] protected bool isOpen;
    public bool IsOpen => isOpen;

    [SerializeField] protected UIItemInventorySort uiInventorySort;
    public UIItemInventorySort UIInventorySort => uiInventorySort;

    protected virtual void Start()
    {
        this.CheckIfInvIsOpen();
        InvokeRepeating(nameof(ShowItems), 1, 1);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInvSort();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadUIInvSort()
    {
        if (this.uiInvSort != null) return;
        this.uiInvSort = transform.GetComponentInChildren<UIInventorySort>();
        Debug.LogWarning(transform.name + ":Load UIInvSort", transform.gameObject);
    }

    //==========================================Show UI===========================================
    public virtual void Open()
    {
        transform.parent.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        transform.parent.gameObject.SetActive(false);
        this.isOpen = false;
    }

    public virtual void Toggle()
    {
        if (this.IsOpen) this.Close();
        else this.Open();
    }

    //==========================================Checker===========================================
    protected virtual void CheckIfInvIsOpen()
    {
        if (transform.parent.gameObject.activeSelf) this.isOpen = true;
        else this.isOpen = false;
    }

    //=========================================Show Item==========================================
    protected virtual void ShowItems()
    {
        if (!this.IsOpen) return;

        this.manager.UIInvItemSpawner.ClearItems();

        Inventory playerInventory = PlayerManager.Instance.CurrShip.Inventory;
        List<ItemInventory> items = playerInventory.Items;
        if (playerInventory.Items.Count <= 0) return;

        this.SpawnAllUIInvItem(items);
        this.uiInvSort.SortItems();
    }

    //===========================================Spawn============================================
    protected virtual void SpawnAllUIInvItem(List<ItemInventory> items)
    {
        foreach(ItemInventory item in items)
        {
            Transform newUIItem = this.SpawnUIInvItem(item);
        }
    }

    protected virtual Transform SpawnUIInvItem(ItemInventory item)
    {
        string uiItemName = this.manager.UIInvItemSpawner.ItemOne;
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;

        Transform newUIItem = this.manager.UIInvItemSpawner.Spawn(uiItemName, spawnPos, spawnRot);

        if (newUIItem == null)
        {
            Debug.LogError(transform.name + ": new UIItem is null", transform.gameObject);
            return null;
        }

        UIInvItem uiInvItem = newUIItem.GetComponent<UIInvItem>();
        uiInvItem.SetItemInventory(item);
        uiInvItem.UpdateInvItem();

        newUIItem.localScale = Vector3.one;
        newUIItem.gameObject.SetActive(true);
        return newUIItem;
    }
}
