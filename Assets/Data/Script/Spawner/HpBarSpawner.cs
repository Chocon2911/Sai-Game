using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarSpawner : Spawner
{
    private static HpBarSpawner instance;
    public static HpBarSpawner Instance => instance;

    [Header("EnemySpawner")]
    [SerializeField] protected string hpBarOne = "HpBar_1";
    public string HpBarOne => hpBarOne;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + "One HpBarSpawner exists Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    //==========================================Spawner===========================================
    
}
