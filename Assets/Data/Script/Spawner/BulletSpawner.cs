using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    private string bulletOne = "Bullet_1";
    public string BulletOne => bulletOne;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One Instance only", transform.gameObject);
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
