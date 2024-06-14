using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseUIInventory : BaseBtn
{
    [SerializeField] protected UIInventoryManager inv;
    public UIInventoryManager Int => inv;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInventory();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadUIInventory()
    {
        if (this.inv != null) return;
        this.inv = transform.parent.parent.GetComponent<UIInventoryManager>();
        Debug.LogWarning(transform.name + ": LoadUIInventory", transform.gameObject);
    }

    //========================================Base Button=========================================
    protected override void OnClick()
    {
        this.inv.InvShow.Close();   
    }
}
