using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class WormHole : HuyMonoBehaviour
{
    [Header("Other")]
    [SerializeField] protected CircleCollider2D bodyCollider;

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
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    //==========================================Interact==========================================
    protected virtual void OnMouseDown()
    {
        Debug.Log(transform.name + ": You just click Worm Hole", transform.gameObject);
    }
}
