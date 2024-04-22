using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }


    //=======================================Despawn==============================================
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
        //Debug.Log(transform.name + ": Despawn Object", transform.gameObject);
    }
}
