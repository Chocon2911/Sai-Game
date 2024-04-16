using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjManager : HuyMonoBehaviour
{
    [Header("ShootableObjManager")]
    [Header("Other")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ShootableObjSO shootableObjSO;
    public ShootableObjSO ShootableObjSO => shootableObjSO;

    [Header("Script")]
    [SerializeField] protected Despawner despawner;
    public Despawner Despawner => despawner;

    [SerializeField] protected ShootableObjDamageReceiver shootableObjDamageReceiver;
    public ShootableObjDamageReceiver ShootableObjDamageReceiver => shootableObjDamageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadShootableObjSO();
        //Script
        this.LoadDespawner();
        this.LoadShootableObjDamageReceiver();
    }

    //========================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", transform.gameObject);
    }

    protected virtual void LoadShootableObjSO()
    {
        if (this.shootableObjSO != null) return;
        string pathSO = "ShootableObj/" + this.GetShootableObjTypeStr() + "/" + transform.name;
        this.shootableObjSO = Resources.Load<ShootableObjSO>(pathSO);
        Debug.LogWarning(transform.name + ": LoadJunkSO", transform.gameObject);
    }

    //Script
    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.Find("Despawn").GetComponent<Despawner>();
        Debug.Log(transform.name + ": LoadDespawner", transform.gameObject);
    }

    protected virtual void LoadShootableObjDamageReceiver()
    {
        if (this.ShootableObjDamageReceiver != null) return;
        this.shootableObjDamageReceiver = transform.Find("DamageReceiver").GetComponent<ShootableObjDamageReceiver>();
        Debug.Log(transform.name + ": LoadShootableObjDamageReceiver", transform.gameObject);
    }

    //============================================Get=============================================
    protected abstract string GetShootableObjTypeStr();
}
