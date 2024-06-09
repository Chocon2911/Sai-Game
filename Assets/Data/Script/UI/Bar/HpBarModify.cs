using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarModify : HpBarAbstract
{
    [Header("Hp Bar Modify")]
    [Header("Script")]
    [SerializeField] protected ShootableObjManager shootableObjManager;
    public ShootableObjManager ShootableObjManager => shootableObjManager;

    [Header("Stat")]
    [SerializeField] protected bool isDead;

    protected virtual void FixedUpdate()
    {
        this.CheckIsDead();
        this.UpdateSliderHp();
    }

    //============================================Set=============================================
    public virtual void SetShootableObjManager(ShootableObjManager shootableObjManager)
    {
        this.shootableObjManager = shootableObjManager;
    }

    //=========================================Update Hp==========================================
    protected virtual void UpdateSliderHp()
    {
        if (this.isDead) return;
        if (this.shootableObjManager == null) return;
        float currHp = this.shootableObjManager.ShootableObjDamageReceiver.Health;
        float maxHp = this.shootableObjManager.ShootableObjDamageReceiver.MaxHealth;

        this.hpBarManager.SliderHp.SetCurrHp(currHp);
        this.hpBarManager.SliderHp.SetMaxHp(maxHp);
    }

    //============================================Dead============================================
    protected virtual void CheckIsDead()
    {
        if (!this.shootableObjManager.ShootableObjDamageReceiver.IsDead())
        {
            this.isDead = false;
            return;
        }

        this.OnDead();
        this.isDead = true;
    }

    protected virtual void OnDead()
    {
        this.HpBarManager.Spawner.Despawn(transform.parent);
    }
}
