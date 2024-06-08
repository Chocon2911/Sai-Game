using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HpBarAbstract : HuyMonoBehaviour
{
    [Header("Hp Bar Abstract")]
    [SerializeField] protected HpBarManager hpBarManager;
    public HpBarManager HpBarManager => hpBarManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpBarManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadHpBarManager()
    {
        if (this.hpBarManager != null) return;
        this.hpBarManager = transform.parent.GetComponent<HpBarManager>();
        Debug.LogWarning(transform.name + ": LoadHpBarManager", transform.gameObject);
    }
}
