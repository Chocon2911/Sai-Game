using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class WormHole : HuyMonoBehaviour
{
    [Header("Other")]
    [SerializeField] protected CircleCollider2D bodyCollider;
    [Header("Stat")]
    [SerializeField] protected string galaxyName = "Galaxy_1";
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
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    //==========================================Interact==========================================
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }

    //===========================================Galaxy===========================================
    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(this.galaxyName);
    }
}
