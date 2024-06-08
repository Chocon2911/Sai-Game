using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarModify : HpBarAbstract
{
    [Header("Hp Bar Modify")]
    [SerializeField] protected ShootableObjManager shootableObjManager;
    public ShootableObjManager ShootableObjManager => shootableObjManager;

    protected virtual void FixedUpdate()
    {
        this.UpdateSliderHp();
    }

    //=========================================Update Hp==========================================
    protected virtual void UpdateSliderHp()
    {
        if (this.shootableObjManager == null) return;
        float currHp = this.shootableObjManager.ShootableObjDamageReceiver.Health;
        float maxHp = this.shootableObjManager.ShootableObjDamageReceiver.MaxHealth;

        this.hpBarManager.SliderHp.SetCurrHp(currHp);
        this.hpBarManager.SliderHp.SetMaxHp(maxHp);
    }

    //============================================Set=============================================
    public virtual void SetShootableObjManager(ShootableObjManager shootableObjManager)
    {
        this.shootableObjManager = shootableObjManager;
    }
}
