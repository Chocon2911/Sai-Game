using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : AbilityObjManager
{
    [Header("ShipManager")]

    [Header("Script")]
    [SerializeField] protected ObjMovement shipMovement;
    public ObjMovement ShipMovement => shipMovement;

    [SerializeField] protected ObjShooting shipShooting;
    public ObjShooting ShipShooting => shipShooting;

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        //Script
        this.LoadShipMovement();
        this.LoadShipShooting();
        this.LoadInventory();
    }

    //=========================================Load Component=====================================
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

    //====================================ShootableObjManager=====================================
    protected override string GetShootableObjTypeStr()
    {
        return ShootableObjType.Ship.ToString();
    }
}
