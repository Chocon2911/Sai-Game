using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : HuyMonoBehaviour
{
    [Header("Script")]
    [SerializeField] protected ItemDropDespawn itemDespawn;
    public ItemDropDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemPickedUp itemPickedUp;
    public ItemPickedUp ItemPickedUp => itemPickedUp;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script;
        this.LoadItemDespawn();
        this.LoadItemPickedUp();
    }
    //========================================Load Component======================================
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.Find("Despawn").GetComponent<ItemDropDespawn>();
        Debug.Log(transform.name + ": LoadItemDropDespawn", transform.gameObject);
    }

    protected virtual void LoadItemPickedUp()
    {
        if (this.ItemPickedUp != null) return;
        this.itemPickedUp = transform.Find("ItemPickedUp").GetComponent<ItemPickedUp>();
        Debug.Log(transform.name + ": LoadItemPickedUp", transform.gameObject);
    }
}
