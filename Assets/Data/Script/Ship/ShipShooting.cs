using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipShooting : HuyMonoBehaviour
{
    [Header("Ship Shooting")]
    [SerializeField] protected Transform bulletObj;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected bool isReloaded = false;

    private void Update()
    {
        this.IsShooting();
        this.IsReloaded();
        this.Shooting();
    }

    //==========================================Checker===========================================
    protected abstract bool IsShooting();

    protected virtual bool IsReloaded()
    {
        if (this.shootTimer < shootDelay) this.shootTimer += Time.deltaTime;
        this.isReloaded = shootTimer >= shootDelay;
        return this.isReloaded;
    }

    //===========================================Shoot============================================
    protected virtual void Shooting()
    {
        if (!this.IsShooting() || !this.IsReloaded()) return;

        Vector2 bulletPos = transform.parent.position;
        Quaternion bulletRot = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.BulletOne , bulletPos, bulletRot);
        
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletManager bulletManager = newBullet.GetComponent<BulletManager>();
        bulletManager.SetShooter(transform.parent);
        //Debug.Log(transform.name + ": Shooting", transform.gameObject);

        this.shootTimer = 0f;
        //Debug.Log(transform.name + ": Reloading", transform.gameObject);
    }
}
