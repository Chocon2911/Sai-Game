using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{
    [Header("Obj Look At Player")]
    [SerializeField] protected Transform player; // Sai uses GameObject but i use Transform 

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindWithTag("Player").transform;
        Debug.LogWarning(transform.name + ": LoadPlayer", transform.gameObject);
    }

    //=====================================Obj Look At Target=====================================
    protected override void GetTargetPos()
    {
        if (this.player == null) return;
        this.targetPos = this.player.position;
        this.targetPos.z = 0;
    }
}
