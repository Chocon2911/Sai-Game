using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    [Header("JunkSpawner")]
    private static JunkSpawner instance;
    public static JunkSpawner Instance => instance;

    protected string junkOne = "Junk_1";
    public string JunkOne => junkOne;

    protected string junkTwo = "Junk_2";
    public string JunkTwo => junkTwo;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one JunkSpawner exists at a time", transform.gameObject);
        instance = this;
    }
}
