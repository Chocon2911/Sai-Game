using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyModifyAbstract : HuyMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.GetComponent<EnemyManager>();
        Debug.LogWarning(transform.name + ": LoadEnemyManager");
    }
}
