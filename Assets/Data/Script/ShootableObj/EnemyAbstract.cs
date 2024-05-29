using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : HuyMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;
    public ShootableObjManager EnemyManager => enemyManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.parent.GetComponent<EnemyManager>();
        Debug.LogWarning(transform.name + ": LoadEnemyManager", transform.gameObject);
    }
}
