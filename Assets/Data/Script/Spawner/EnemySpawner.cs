using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : HuyMonoBehaviour
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        if (JunkSpawner.Instance != null)
        {
            Debug.LogError(transform.name + "One EnemySpawner exists Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
