using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DamageReceiver : HuyMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected CircleCollider2D bodyCol;

    [Header("Stat")]
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected bool isDead;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollider();
    }

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    //=========================================Load Component=====================================
    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCol != null) return;
        this.bodyCol = transform.GetComponent<CircleCollider2D>();
        this.bodyCol.isTrigger = true;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    //=============================================Health=========================================
    public virtual void Reborn()
    {
        this.isDead = false;
        this.health = maxHealth;
    }

    public virtual void Add(float value)
    {
        this.health += value;
        if (this.health > maxHealth) this.health = maxHealth;
    }

    public virtual void Deduct(float value)
    {
        this.health -= value;
        if (this.health < 0) this.health = 0;
        this.CheckIsDead();
        
    }

    //=============================================Dead===========================================
    protected virtual bool IsDead()
    {
        return this.health <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For Override
    }
}
