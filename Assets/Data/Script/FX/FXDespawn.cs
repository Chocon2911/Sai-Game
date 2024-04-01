using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    //=======================================Despawn==============================================
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
