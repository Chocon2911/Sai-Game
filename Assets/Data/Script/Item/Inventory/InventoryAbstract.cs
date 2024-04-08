using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : HuyMonoBehaviour
{
    [Header("InventoryAbstract")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", transform.gameObject);
    }
}
