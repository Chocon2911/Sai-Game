using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
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
    protected override void GetTargetPos()
    {
        if (this.moveTarget == null) return;
        this.targetPos = this.moveTarget.position;
        this.targetPos.z = 0;
    }
}
