using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMoveForward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.LogWarning(transform.name + ": LoadTarget", transform.gameObject);
    }

    //============================================Get=============================================
    protected virtual void GetMousePos()
    {
        this.targetPos = this.moveTarget.position;
        this.targetPos.z = 0;
    }
}
