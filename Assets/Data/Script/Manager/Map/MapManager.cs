using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : LevelByDistance
{
    //[Header("MapManager")]

    protected override void FixedUpdate()
    {
        this.MapSetTarget();
        base.FixedUpdate();
    }

    //==========================================Get Set===========================================
    protected virtual void MapSetTarget()
    {
        if (this.target != null) return;
        this.SetTarget(PlayerManager.Instance.CurrShip.transform);
    }
}
