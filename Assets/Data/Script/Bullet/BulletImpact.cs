using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected CircleCollider2D bodyCol;
    [SerializeField] protected Rigidbody2D rb;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollider();
        this.LoadRigidbody();
    }

    //========================================Load Component======================================
    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCol != null) return;
        this.bodyCol = transform.GetComponent<CircleCollider2D>();
        this.bodyCol.isTrigger = true;
        this.bodyCol.radius = 0.05f;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        Debug.Log(transform.name + ": LoadRigibidbody", transform.gameObject);
    }

    //============================================Impact==========================================
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.bulletManager.BulletDamageSender.SendByObj(collision.transform);
    }
}
