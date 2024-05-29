using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : AbilityObjManager
{
    [Header("Enemy Manager")]
    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected ObjAppear objAppear;
    public ObjAppear ObjAppear => objAppear;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjAppear();
        this.LoadObjLookAtTarget();
    }

    //========================================Load Component=======================================
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.LogWarning(transform.name + ": LoadObjShooting", transform.gameObject);
    }

    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.LogWarning(transform.name + ": LoadObjMovement", transform.gameObject);
    }

    protected virtual void LoadObjAppear()
    {
        if (this.objAppear != null) return;
        this.objAppear = GetComponentInChildren<ObjAppear>();
        if (this.objAppear != null) return;
        Debug.LogWarning(transform.name + ": LoadObjAppear", transform.gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {
        if (this.ObjLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjLookAtTarget", transform.gameObject);
    }

    //===================================Shootable Obj Manager====================================
    protected override string GetShootableObjTypeStr()
    {
        return ShootableObjType.Enemy.ToString();
    }
}
