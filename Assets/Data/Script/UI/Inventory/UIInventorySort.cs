using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventorySort : HuyMonoBehaviour
{
    [Header("UI Inventory Sort")]
    [SerializeField] protected UIInventoryShow uiInventoryShow;
    public UIInventoryShow UIInventoryShow => uiInventoryShow;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInvShow();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadUIInvShow()
    {
        if (this.uiInventoryShow != null) return;
        this.uiInventoryShow = transform.parent.GetComponent<UIInventoryShow>();
        Debug.LogWarning(transform.name + ": Load UIInvShow", transform.gameObject);
    }

    //============================================Sort============================================
    public virtual void SortItems()
    {
        int itemAmount = this.uiInventoryShow.Manager.ContentTrans.childCount;
        Transform currItemObj, nextItemObj;
        bool isSorting = false;

        for (int i = 0; i < itemAmount - 1; i++)
        {
            currItemObj = this.uiInventoryShow.Manager.ContentTrans.GetChild(i);
            nextItemObj = this.uiInventoryShow.Manager.ContentTrans.GetChild(i + 1);

            UIInvItem currInvItem = currItemObj.GetComponent<UIInvItem>();
            UIInvItem nextInvItem = nextItemObj.GetComponent<UIInvItem>();

            isSorting = this.SortType(currItemObj, nextItemObj, currInvItem, nextInvItem);
        }

        if (isSorting)
        {
            SortItems();
            return;
        }
    }

    //=========================================By Amount==========================================
    protected virtual bool SortByAmount(UIInvItem currInvItem, UIInvItem nextInvItem)
    {
        int currItemAmount = currInvItem.ItemInventory.ItemAmount;
        int nextItemAmount = nextInvItem.ItemInventory.ItemAmount;

        if (currItemAmount < nextItemAmount)
        {
            return true;
        }

        return false;
    }

    //==========================================By Type===========================================
    protected virtual bool SortByType(UIInvItem currInvItem, UIInvItem nextInvItem)
    {
        ItemCode currItemCode = currInvItem.ItemInventory.ItemDropSO.ItemCode;
        ItemCode nextitemCode = nextInvItem.ItemInventory.ItemDropSO.ItemCode;

        if ((int)currItemCode < (int)nextitemCode)
        {
            return true;
        }

        return false;
    }

    //===========================================Other============================================
    protected virtual bool SortType(Transform currItemObj, Transform nextItemObj, UIInvItem currInvItem, UIInvItem nextInvItem)
    {
        bool isSorting = false;

        if ((int)this.uiInventoryShow.UIInventorySort == 1)
        {
            isSorting = this.SortByAmount(currInvItem, nextInvItem);
            //Debug.Log(transform.name + ": Sort By Amount", transform.gameObject);
        }

        else if ((int)this.uiInventoryShow.UIInventorySort == 2)
        {
            isSorting = this.SortByType(currInvItem, nextInvItem);
            //Debug.Log(transform.name + ": Sort By Type", transform.gameObject);
        }

        else
        {
            isSorting = false;
            //Debug.Log(transform.name + ": No Sort", transform.gameObject);
        }



        if (isSorting) SwapItem(currItemObj, nextItemObj);
        return isSorting;
    }

    protected virtual void SwapItem(Transform currItemObj, Transform nextItemObj)
    {
        int currIndex = currItemObj.GetSiblingIndex();
        int nextIndex = nextItemObj.GetSiblingIndex();

        currItemObj.SetSiblingIndex(nextIndex);
        nextItemObj.SetSiblingIndex(currIndex);
    }
}
