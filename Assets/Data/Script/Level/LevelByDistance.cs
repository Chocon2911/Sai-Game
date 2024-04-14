using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByDistance : Level
{
    [Header("LevelByDistance")]
    [Header("Other")]
    [SerializeField] protected Transform startTrans;
    [SerializeField] protected Transform targetTrans;
    [Header("Stat")]
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 10;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    //==========================================Get Set===========================================   
    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }

    public virtual void SetTarget(Transform target)
    {
        this.targetTrans = target;
    }

    //===========================================Level============================================
    protected virtual void Leveling()
    {
        if (this.targetTrans == null) return;

        this.distance = Vector3.Distance(startTrans.position, this.targetTrans.position);
        int newLevel = this.GetLevelByDistance();
        this.SetCurrLevel(newLevel);
    }
}
