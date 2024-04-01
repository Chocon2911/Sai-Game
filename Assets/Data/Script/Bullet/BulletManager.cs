using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : HuyMonoBehaviour
{
    //Other
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    //Script
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public DamageSender BulletDamageSender => bulletDamageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected BulletFly bulletFly;
    public BulletFly BulletFly => bulletFly;

    [SerializeField] protected BulletImpact bulletImpact;
    public BulletImpact BulletImpact => bulletImpact;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletFly();
        this.LoadBulletImpact();
    }

    //==========================================Load Component====================================
    //Script
    protected virtual void LoadDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.Find("DamageSender").GetComponent<BulletDamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", transform.gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.Find("Despawn").GetComponent<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", transform.gameObject);
    }

    protected virtual void LoadBulletFly()
    {
        if (this.bulletFly != null) return;
        this.bulletFly = transform.Find("BulletFly").GetComponent<BulletFly>();
        Debug.Log(transform.name + ": LoadBulletFLy", transform.gameObject);
    }

    protected virtual void LoadBulletImpact()
    {
        if (this.bulletImpact != null) return;
        this.bulletImpact = transform.Find("BulletImpact").GetComponent<BulletImpact>();
        Debug.Log(transform.name + ": LoadBulletImpact", transform.gameObject);
    }

    //==============================================Setter========================================
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
