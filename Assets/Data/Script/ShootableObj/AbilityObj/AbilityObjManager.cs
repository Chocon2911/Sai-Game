using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityObjManager : ShootableObjManager
{
    [Header("Ability Obj")]
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = GetComponentInChildren<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
