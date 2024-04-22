using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ShipMovement
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //=======================================Ship Movement========================================
    protected override void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }

    protected override void Moving()
    {
        if (InputManager.Instance.IsIdle) return;
        base.Moving();
    }
}
