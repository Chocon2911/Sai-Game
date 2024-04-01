using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    [Header("FXSpawner")]
    private static FXSpawner instance;
    public static FXSpawner Instance => instance;

    protected string smoke_1 = "Smoke_1";
    public string Smoke_1 => smoke_1;

    protected string impact_1 = "Impact_1";
    public string Impact_1 => impact_1;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError(transform.name + ": One FXSpawner only", transform.gameObject);
        instance = this;
    }
}
