using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : HuyMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected SpawnRandom spawnRandom;
    public SpawnRandom SpawnRandom => spawnRandom;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadSpawnRandom();
        this.LoadSpawnPoints();
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

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        GameObject spawnPointsTrans = GameObject.Find("SceneSpawnPoints");
        this.spawnPoints = spawnPointsTrans.GetComponent<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }
}
