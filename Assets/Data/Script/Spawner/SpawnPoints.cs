using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPoints : HuyMonoBehaviour
{
    [Header("SpawnPoints")]
    private static SpawnPoints instance;
    public static SpawnPoints Instance => instance;

    [Header("Other")]
    [SerializeField] protected List<Transform> spawnPoints;

    protected override void Awake()
    {
        if (instance != this)
        {
            Debug.LogError(transform.name + ": One SpawnPoints exists Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
    }

    //======================================Load Component=========================================
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        Transform spawnPointTrans = transform;
        foreach (Transform point in spawnPointTrans) this.spawnPoints.Add(point);
        Debug.Log(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }

    public virtual Transform GetRandom()
    {
        int index = Random.Range(0, this.spawnPoints.Count);
        return spawnPoints[index];
    }
}
