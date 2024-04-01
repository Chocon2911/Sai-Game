using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickedUp : HuyMonoBehaviour
{
    [SerializeField] protected CircleCollider2D bodyCollider;
    public CircleCollider2D BodyCollider => bodyCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollider();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = transform.GetComponent<CircleCollider2D>();
        this.bodyCollider.isTrigger = true;
        this.bodyCollider.radius = 0.1f;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }
}
