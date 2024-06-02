using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    [Header("Mother Ship Spawner")]
    [SerializeField] protected string bossOne = "MotherShip_1";
    public string BossOne => bossOne;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + "One MotherShipSpawner exists Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
