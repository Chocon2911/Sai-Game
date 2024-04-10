using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("LevelByDistance")]
    [Header("Other")]
    [SerializeField] protected Transform target;
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
        this.target = target;
    }

    //===========================================Level============================================
    protected virtual void Leveling()
    {
        if (this.target == null) return;

        this.distance = Vector3.Distance(transform.parent.position, this.target.position);
        int newLevel = this.GetLevelByDistance();
        this.SetCurrLevel(newLevel);
    }
}
