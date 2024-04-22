using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    [Header("EnemySpawner")]
    [SerializeField] protected string enemyOne = "Enemy_1";
    public string EnemyOne => enemyOne;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + "One EnemySpawner exists Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
