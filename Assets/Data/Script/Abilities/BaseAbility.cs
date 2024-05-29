using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : HuyMonoBehaviour
{
    [Header("base Ability")]
    [Header("Script")]
    [SerializeField] protected Abilities abilitites;
    public Abilities Abilities => abilitites;

    [Header("Stat")]
    [SerializeField] protected float timer;
    [SerializeField] protected float delay;
    [SerializeField] protected bool isReady;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadAbilities()
    {
        if (this.abilitites != null) return;
        this.abilitites = transform.parent.GetComponent<Abilities>();
        Debug.LogWarning(transform.name + ": LoadAbilities", transform.gameObject);
    }

    //===========================================Public===========================================
    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }

    //==========================================Cooldown==========================================
    protected virtual void Timing()
    {
        if (this.isReady) return;
        
        this.timer += Time.fixedDeltaTime;
        if (this.timer < delay) return;

        this.isReady = true;
    }
}
