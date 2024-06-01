using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : HuyMonoBehaviour
{
    [Header("ShipManager")]
    [Header("Other")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [Header("Script")]
    [SerializeField] protected ObjMovement shipMovement;
    public ObjMovement ShipMovement => shipMovement;

    [SerializeField] protected ObjShooting shipShooting;
    public ObjShooting ShipShooting => shipShooting;

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        //Script
        this.LoadShipMovement();
        this.LoadShipShooting();
        this.LoadInventory();
        this.LoadShipDamageReceiver();
    }

    //=========================================Load Component=====================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", transform.gameObject);
    }

    //Script
    protected virtual void LoadShipMovement()
    {
        if (this.shipMovement != null) return;
        this.shipMovement = GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + ": LoadShipMovement", transform.gameObject);
    }

    protected virtual void LoadShipShooting()
    {
        if (this.shipShooting != null) return;
        this.shipShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadShipShooting", transform.gameObject);
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", transform.gameObject);
    }

    protected virtual void LoadShipDamageReceiver()
    {
        if (this.shipDamageReceiver != null) return;
        this.shipDamageReceiver = GetComponentInChildren<ShipDamageReceiver>();
        Debug.Log(transform.name + ": LoadShipDamageReceiver", transform.gameObject);
    }
}
 