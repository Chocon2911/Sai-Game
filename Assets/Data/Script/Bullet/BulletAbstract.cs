using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : HuyMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletManager bulletManager;
    public BulletManager BulletManager => bulletManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletManager();
    }

    protected virtual void LoadBulletManager()
    {
        if (this.bulletManager != null) return;
        this.bulletManager = transform.parent.GetComponent<BulletManager>();
        Debug.Log(transform.name + ": LoadBulletManager", transform.gameObject);
    }
}
