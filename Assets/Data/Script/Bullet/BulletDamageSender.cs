using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletManager bulletManager;
    public BulletManager BulletManager => bulletManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletManager();
    }

    //=====================================Load Component=========================================
    protected virtual void LoadBulletManager()
    {
        if (this.bulletManager != null) return;
        this.bulletManager = transform.parent.GetComponent<BulletManager>();
        Debug.Log(transform.name + ": LoadBulletManager", transform.gameObject);
    }

    //=========================================Sender=============================================
    public override void SendByReceiver(DamageReceiver damageReceiver)
    {
        base.SendByReceiver(damageReceiver);
        this.DestroyObj();
    }

    //=========================================Object=============================================
    protected override void DestroyObj()
    {
        this.bulletManager.BulletDespawn.DespawnObject();
    }
}
