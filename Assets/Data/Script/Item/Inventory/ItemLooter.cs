using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : HuyMonoBehaviour
{
    [Header("Other")]
    [SerializeField] protected CircleCollider2D lootCollider;
    [SerializeField] protected Rigidbody2D rb;
    [Header("Script")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadLootCollider();
        this.LoadRigidbody();
        //Script
        this.LoadInventory();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadLootCollider()
    {
        if (this.lootCollider != null) return;
        this.lootCollider = transform.GetComponent<CircleCollider2D>();
        this.lootCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadLootCollider", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }
    //Script
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponent<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", transform.gameObject);
    }

    //==========================================Collide===========================================
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickedUp itemPickedUp = collision.GetComponent<ItemPickedUp>();
        if (itemPickedUp == null) return;
        //Loot Item here
    }
}
