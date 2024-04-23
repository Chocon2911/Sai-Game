using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    //===========================================Summon===========================================
    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Spawn();
        this.Active();
    }

    protected virtual void Spawn()
    {
        Transform newPrefab = this.spawner.Spawn(this.GetSpawnObjName(), this.GetSpawnPos(), this.GetSpawnRot());

        if (newPrefab == null) return;
        newPrefab.gameObject.SetActive(true);
    }

    //==========================================Get Set===========================================
    protected virtual Vector3 GetSpawnPos()
    {
        return transform.parent.position;
    }

    protected virtual Quaternion GetSpawnRot()
    {
        return transform.parent.rotation;
    }

    protected virtual string GetSpawnObjName()
    {
        return "Enemy_1";
    }
}
