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

    //==========================================Spawner===========================================
    public override Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        Transform newEnemyObj = base.Spawn(prefab, pos, rot);
        this.AddHpBar2Enemy(newEnemyObj, pos);

        return newEnemyObj;
    }

    //===========================================Hp Bar===========================================
    protected virtual void AddHpBar2Enemy(Transform enemy, Vector3 pos)
    {
        // EnemyManager
        ShootableObjManager enemyManager = enemy.GetComponent<ShootableObjManager>();
        
        // new HpBar Obj
        Vector3 spawnPos = pos;
        Quaternion spawnRot = Quaternion.identity;
        string hpBarName = HpBarSpawner.Instance.HpBarOne;
        Transform newHpBarObj = HpBarSpawner.Instance.Spawn(hpBarName, spawnPos, spawnRot);

        if (newHpBarObj == null)
        {
            Debug.LogError(transform.name + ": No HpBar Name: " + hpBarName, transform.gameObject);
            return;
        }

        // HpBarManager
        HpBarManager hpBarManager = newHpBarObj.GetComponent<HpBarManager>();
        
        // Add HpBar to Enemy
        hpBarManager.HpBarModify.SetShootableObjManager(enemyManager);
        hpBarManager.FollowTarget.SetTarget(enemy);

        //Turn On new HpBar Obj
        newHpBarObj.gameObject.SetActive(true);
    }
}
