using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UiInventoryAbstract : HuyMonoBehaviour
{
    [Header("UI Inventory Abstract")]
    [SerializeField] protected UIInventoryManager manager;
    public UIInventoryManager Manager => manager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInv();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadInv()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<UIInventoryManager>();
        Debug.LogWarning(transform.name + ": LoadInv", transform.gameObject);
    }
}
