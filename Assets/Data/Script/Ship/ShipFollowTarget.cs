using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ShipMovement
{
    [Header("ShipFollowTarget")]
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        this.SetTarget(PlayerManager.Instance.CurrShip.transform);
        base.FixedUpdate();
    }

    //===========================================Target===========================================
    protected virtual void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }

    //=======================================Ship Movement========================================
    protected override void GetTargetPos()
    {
        this.targetPos = this.target.position;
        this.targetPos.z = 0;
    }
}
