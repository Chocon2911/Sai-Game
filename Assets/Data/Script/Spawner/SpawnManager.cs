using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : HuyMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected SpawnRandom spawnRandom;
    public SpawnRandom SpawnRandom => spawnRandom;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadSpawnRandom();
    }

    //======================================Load Component=========================================
    protected virtual void LoadJunkSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", transform.gameObject);
    }

    protected virtual void LoadSpawnRandom()
    {
        if (this.spawnRandom != null) return;
        this.spawnRandom = transform.GetComponent<SpawnRandom>();
        Debug.Log(transform.name + ": LoadJunkRandom", transform.gameObject);
    }
}
