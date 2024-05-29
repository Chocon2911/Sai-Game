using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPoints : HuyMonoBehaviour
{
    [Header("SpawnPoints")]
    [Header("Other")]
    [SerializeField] protected List<Transform> spawnPoints;

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

        if (this.spawnPoints.Count <= 0) return;

        Debug.Log(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }

    public virtual Transform GetRandom()
    {
        int index = Random.Range(0, this.spawnPoints.Count);
        return spawnPoints[index];
    }
}
