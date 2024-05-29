using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtMouse : ObjLookAtTarget
{
    //=====================================Obj Look At Mouse======================================
    protected override void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }

}
