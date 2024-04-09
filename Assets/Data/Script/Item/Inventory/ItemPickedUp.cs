using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickedUp : ItemDropAbstract
{
    [Header("Other")]
    [SerializeField] protected CircleCollider2D bodyCollider;
    public CircleCollider2D BodyCollider => bodyCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadBodyCollider();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = transform.GetComponent<CircleCollider2D>();
        this.bodyCollider.isTrigger = true;
        this.bodyCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    //=========================================Pick Up============================================
    public virtual ItemCode GetItemCode()
    {
        string itemName = transform.parent.name.Replace("(Clone)", null);
        return this.String2ItemCode(itemName);
    }

    public virtual ItemInventory GetItemInventory()
    {
        ItemInventory itemInventory = this.itemDropManager.ItemInventory;
        return itemInventory;
    }

    public virtual void Picked()
    {
        this.itemDropManager.ItemDespawn.DespawnObject();
    }

    public virtual void OnMouseDown()
    {
        PlayerManager.Instance.PlayerLooter.LootItem(this);
    }

    //==========================================Other=============================================
    protected virtual ItemCode String2ItemCode(string name)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), name);
        }
        catch (ArgumentException error)
        {
            Debug.LogError(error.ToString());
            return ItemCode.NoItem;
        }
    }
}