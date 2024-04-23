using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : HuyMonoBehaviour
{
    [Header("base Ability")]
    [SerializeField] protected float timer;
    [SerializeField] protected float delay;
    [SerializeField] protected bool isReady;

    protected virtual void FixedUpdate()
    {
        this.Timing();
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
