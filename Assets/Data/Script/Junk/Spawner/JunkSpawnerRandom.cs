using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : HuyMonoBehaviour
{
    [SerializeField] protected JunkSpawnerManager junkManager;
    public JunkSpawnerManager JunkManager => junkManager;

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
        this.JunkSpawning();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkManager();
    }

    //===================================Load Component===========================================
    protected virtual void LoadJunkManager()
    {
        if (this.junkManager != null) return;
        this.junkManager = transform.GetComponent<JunkSpawnerManager>();
        Debug.Log(transform.name + ": LoadJunkManager", transform.gameObject);
    }

    //=======================================Spawn================================================
    protected virtual void JunkSpawning()
    {
        if (!this.canSpawn) return;
        this.canSpawn = false;
        Vector3 pos = this.junkManager.JunkSpawnPoints.GetRandom().position;
        Quaternion rot = this.junkManager.JunkSpawnPoints.GetRandom().rotation;
        string prefabName = JunkSpawner.Instance.RandomPrefab().name;

        Transform prefab = this.junkManager.JunkSpawner.Spawn(prefabName, pos, rot);
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
        if (this.randomLimit >= this.junkManager.JunkSpawner.SpawnCount) return true;
        return false;
    }

}
