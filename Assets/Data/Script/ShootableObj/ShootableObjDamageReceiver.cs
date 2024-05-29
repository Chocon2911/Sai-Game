using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootableObjDamageReceiver : DamageReceiver
{
    [Header("JunkDamageReceiver")]
    [SerializeField] protected ShootableObjManager shootableObjManager;
    public ShootableObjManager ShootableObjManager => shootableObjManager;

    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadShootableObjManager();
        //Stat
        this.DefaultStat();
    }

    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadShootableObjManager()
    {
        if (this.shootableObjManager != null) return;
        this.shootableObjManager = transform.parent.GetComponent<ShootableObjManager>();
        Debug.LogWarning(transform.name + ": LoadShootableObjManager", transform.gameObject);
    }

    //Stat
    protected virtual void DefaultStat()
    {
        if (this.shootableObjManager.ShootableObjSO == null)
        {
            Debug.LogError(transform.name + ": No ShootableObjSO", transform.gameObject);
            return;
        }

        this.maxHealth = this.shootableObjManager.ShootableObjSO.MaxHealth;
    }

    //============================================Dead============================================
    protected override void OnDead()
    {
        //base.OnDead();
        this.shootableObjManager.Despawner.DespawnObject();
        this.OnDeadFX();
        this.DropOnDead();
    }

    protected virtual void OnDeadFX()
    {
        Vector2 fxPos = transform.parent.position;
        Quaternion fxRot = transform.parent.rotation;
        string fxName = FXSpawner.Instance.Smoke_1;

        Transform fxPrefab = FXSpawner.Instance.Spawn(fxName, fxPos, fxRot);
        if (fxPrefab == null) Debug.LogError(transform.name + ": No FXPrefab", transform.gameObject);
        fxPrefab.gameObject.SetActive(true);
    }

    protected virtual void DropOnDead()
    {
        Vector2 dropPos = transform.parent.position;
        Quaternion dropRot = transform.parent.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjManager.ShootableObjSO.DropList, dropPos, dropRot);
    }
}
