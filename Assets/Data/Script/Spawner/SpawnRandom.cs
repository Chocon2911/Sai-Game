using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : HuyMonoBehaviour
{
    [Header("Script")]
    [SerializeField] protected SpawnManager spawnManager;
    public SpawnManager SpawnManager => spawnManager;

    [Header("Stat")]
    [SerializeField] protected float randomCooldown = 1;
    [SerializeField] protected float randomTimer = 0;
    [SerializeField] protected int randomLimit = 15;

    [SerializeField] protected bool canSpawn;

    protected virtual void Start()
    {
        //this.JunkSpawning();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckCanSpawn();
        this.ObjSpawning();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnManager();
    }

    //===================================Load Component===========================================
    protected virtual void LoadSpawnManager()
    {
        if (this.spawnManager != null) return;
        this.spawnManager = transform.GetComponent<SpawnManager>();
        Debug.LogWarning(transform.name + ": LoadSpawnManager", transform.gameObject);
    }

    //=======================================Spawn================================================
    protected virtual void ObjSpawning()
    {
        if (!this.canSpawn) return;
        this.canSpawn = false;
        Vector3 pos = this.spawnManager.SpawnPoints.GetRandom().position;
        Quaternion rot = this.spawnManager.SpawnPoints.GetRandom().rotation;
        string prefabName = this.spawnManager.Spawner.RandomPrefab().name;

        Transform prefab = this.spawnManager.Spawner.Spawn(prefabName, pos, rot);
        prefab.gameObject.SetActive(true);
        //Debug.Log(transform.name + ": Spawn Junk", transform.gameObject);
        //Invoke(nameof(this.JunkSpawning), 1f);
    }

    //======================================Checker===============================================
    protected virtual void CheckCanSpawn()
    {
        if (!this.IsRandomReachLimit()) return;
        if (!this.IsCooldown()) return;
        this.canSpawn = true;
    }

    //=======================================Bool=================================================
    protected virtual bool IsCooldown()
    {
        if (this.randomTimer < this.randomCooldown)
        {
            this.randomTimer += Time.fixedDeltaTime;
            return false;
        }
        this.randomTimer = 0;
        return true;
    }

    protected virtual bool IsRandomReachLimit()
    {
        if (this.spawnManager.Spawner.SpawnCount < this.randomLimit) return true;
        return false;
    }
}
