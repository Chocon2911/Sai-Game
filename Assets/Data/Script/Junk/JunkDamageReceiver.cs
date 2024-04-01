using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("JunkDamageReceiver")]
    [SerializeField] protected JunkObjManager junkObjManager;
    public JunkObjManager JunkObjManager => junkObjManager;

    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadJunkManager();
        //Stat
        this.DefaultStat();
    }

    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadJunkManager()
    {
        if (this.junkObjManager != null) return;
        this.junkObjManager = transform.parent.GetComponent<JunkObjManager>();
        Debug.Log(transform.name + ": LoadJunkManager", transform.gameObject);
    }

    //Stat
    protected virtual void DefaultStat()
    {
        if (this.junkObjManager.JunkSO == null)
        {
            Debug.LogError(transform.name + ": No JunkSO", transform.gameObject);
            return;
        }

        this.maxHealth = this.junkObjManager.JunkSO.MaxHealth;
    }

    //============================================Dead============================================
    protected override void OnDead()
    {
        //base.OnDead();
        this.junkObjManager.JunkDespawn.DespawnObject();
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
        ItemDropSpawner.Instance.Drop(this.JunkObjManager.JunkSO.DropList, dropPos, dropRot);
    }
}
