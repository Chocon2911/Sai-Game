using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShipModify : EnemyModifyAbstract
{
    [Header("Mother Ship")]
    [SerializeField] protected float moveSpeed = 0.05f;
    [SerializeField] protected float rotSpeed = 0.1f;

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
