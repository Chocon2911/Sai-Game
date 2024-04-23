using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByInput : ShipShooting
{
    //=======================================Ship Shooting========================================
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.IsFiring;
        return this.isShooting;
    }
}
