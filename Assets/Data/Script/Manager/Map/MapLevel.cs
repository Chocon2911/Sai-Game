using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    [Header("MapLevel")]
    [SerializeField] protected MapManager mapManager;
    public MapManager MapManager => mapManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStartTrans();
        this.LoadMapManager();
    }

    protected override void FixedUpdate()
    {
        this.MapSetTarget();
        base.FixedUpdate();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadStartTrans()
    {
        if (this.startTrans != null) return;
        this.startTrans = transform.parent;
        Debug.Log(transform.name + ": LoadStartTrans", transform.gameObject);
    }

    protected virtual void LoadMapManager()
    {
        if (this.mapManager != null) return;
        this.mapManager = transform.parent.GetComponent<MapManager>();
        Debug.Log(transform.name + ": LoadMapManager", transform.gameObject);
    }

    //==========================================Get Set===========================================
    protected virtual void MapSetTarget()
    {
        if (this.targetTrans != null) return;
        this.SetTarget(PlayerManager.Instance.CurrShip.transform);
    }
}
