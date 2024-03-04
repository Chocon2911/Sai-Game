using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : HuyMonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;

    protected virtual void Start()
    {
        this.Reborn();
    }

    //==============================================Public=========================================
    public virtual void AddHealth(float value)
    {
        this.health += value;
        if (this.health > this.maxHealth) this.health = this.maxHealth;
    }

    public virtual void Reborn()
    {
        this.health = this.maxHealth;
    }

    public virtual void DeductHealth(float value)
    {
        this.health -= value;
        if (this.health <= 0) this.health = 0;
    }

    //==============================================Checker========================================
    protected virtual bool IsDead()
    {
        return this.health <= 0;
    }
}
