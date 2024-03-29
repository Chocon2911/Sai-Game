using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("JunkDamageReceiver")]
    [SerializeField] protected JunkObjManager junkObjManager;
    public JunkObjManager JunkObjManager => junkObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadJunkManager()
    {
        if (this.junkObjManager != null) return;
        this.junkObjManager = transform.parent.GetComponent<JunkObjManager>();
        Debug.Log(transform.name + ": LoadJunkManager", transform.gameObject);
    }
    //=======================================DamageReceiver=======================================
    protected override void OnDead()
    {
        base.OnDead();
        this.junkObjManager.JunkDespawn.DespawnObject();
    }
}
