using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearDeadMinion();
        this.Summoning();
    }

    //===========================================Summon===========================================
    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        if (this.IsMinionLimitReached()) return;
        this.Summon();
        this.RestartCooldownAbility();
    }

    protected virtual Transform Summon()
    {
        Transform newPrefab = this.spawner.Spawn(this.GetSpawnObjName(), this.GetSpawnPos(), this.GetSpawnRot());

        if (newPrefab == null) return newPrefab;

        this.minions.Add(newPrefab);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    //==========================================Checker===========================================
    protected virtual bool IsMinionLimitReached()
    {
        return minionLimit <= this.minions.Count;
    }

    //========================================Dead Minion=========================================
    protected virtual void ClearDeadMinion()
    {
        if (this.minions.Count <= 0) return;

        foreach (Transform minion in this.minions)
        {
            if (!minion.gameObject.activeSelf)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }

    //==========================================Get Set===========================================
    protected virtual Vector3 GetSpawnPos()
    {
        Vector3 spawnPos = abilitites.AbilityObjManager.SpawnPoints.GetRandom().position;
        return spawnPos;
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
