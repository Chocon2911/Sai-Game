using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByTarget : ShipShooting
{
    [Header("Ship Shoot By Target")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootableDistance = 3;

    //==========================================Get Set===========================================
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual float GetDistance()
    {
        return Vector2.Distance(transform.parent.position, this.target.position);
    }

    //=======================================Ship Shooting========================================
    protected override bool IsShooting()
    {
        this.distance = this.GetDistance();
        this.isShooting = this.distance < this.shootableDistance;
        return this.isShooting;
    }

    //===========================================Target===========================================

}
