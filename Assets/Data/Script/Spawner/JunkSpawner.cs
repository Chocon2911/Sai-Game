using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance => instance;

    protected string junkOne = "Junk_1";
    public string JunkOne => junkOne;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one instance exists at a time", transform.gameObject);
        instance = this;
    }
}
