using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrepShipModify : EnemyModifyAbstract
{
    [Header("Crep Ship")]
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected float rotSpeed = 0.5f;

    protected virtual void Start()
    {
        this.ShipModify();
    }

    //===========================================Modify===========================================
    protected virtual void ShipModify()
    {
        this.enemyManager.ObjMovement.SetSpeed(this.moveSpeed);
        this.enemyManager.ObjLookAtTarget.SetRotSpeed(this.rotSpeed);
    }
}
