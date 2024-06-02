using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    protected virtual void Start()
    {
        //Invoke("Test", 10);
    }

    //protected virtual void Test()
    //{
    //    this.DropItemByIndex(0);
    //    Debug.Log("Hello tesing here");
    //}

    //=========================================Item Drop==========================================
    public virtual void DropItemByIndex(int itemIndex, Vector2 dropPos, Quaternion dropRot)
    {
        if (itemIndex < 0 || itemIndex > this.inventory.Items.Count) Debug.LogError(transform.name + ": Wrong itemIndex", transform.gameObject);

        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
        this.inventory.RemoveEmptyItemInventory();
    }
}
