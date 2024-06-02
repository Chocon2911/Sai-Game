using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawner", transform.gameObject);
    }

    //=======================================Ability Summon=======================================
    protected override Transform Summon()
    {
        Transform newEnemy = base.Summon();
        newEnemy.parent = this.abilitites.transform;
        return newEnemy;
    }
}
