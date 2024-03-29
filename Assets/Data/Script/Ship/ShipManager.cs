using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : HuyMonoBehaviour
{
    [Header("ShipManager")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ShipMovement shipMovement;
    public ShipMovement ShipMovement => shipMovement;

    [SerializeField] protected ShipShooting shipShooting;
    public ShipShooting ShipShooting => shipShooting;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadShipMovement();
        this.LoadShipShooting();
    }

    //=========================================Load Component=====================================
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", transform.gameObject);
    }

    protected virtual void LoadShipMovement()
    {
        if (this.shipMovement != null) return;
        this.shipMovement = transform.Find("ShipMovement").GetComponent<ShipMovement>();
        Debug.Log(transform.name + ": LoadShipMovement", transform.gameObject);
    }

    protected virtual void LoadShipShooting()
    {
        if (this.shipShooting != null) return;
        this.shipShooting = transform.Find("ShipShooting").GetComponent<ShipShooting>();
        Debug.Log(transform.name + ": LoadShipShooting", transform.gameObject);
    }
}
 