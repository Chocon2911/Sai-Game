using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarpByInput : AbilityWarp
{
    protected override void Update()
    {
        base.Update();
        this.UpdateWarpDirection();
    }

    //===========================================Update===========================================
    protected virtual void UpdateWarpDirection()
    {
        this.keyDirection = InputManager.Instance.Direction;

        //if (this.keyDirection.x == 1) Debug.Log(transform.name + "Pressed A", transform.gameObject);
        //if (this.keyDirection.y == 1) Debug.Log(transform.name + ": Pressed D", transform.gameObject);
        //if (this.keyDirection.z == 1) Debug.Log(transform.name + ": Pressed W", transform.gameObject);
        //if (this.keyDirection.w == 1) Debug.Log(transform.name + ": Pressed S", transform.gameObject);
    }
}
