using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryManager : HuyMonoBehaviour
{
    [Header("UI Inventory")]
    private static UIInventoryManager instance;
    public static UIInventoryManager Instance => instance;

    [Header("Other")]
    [SerializeField] protected Transform contentTrans;
    public Transform ContentTrans => contentTrans;

    [Header("Script")]
    [SerializeField] protected BtnCloseUIInventory btnCloseUIInv;
    public BtnCloseUIInventory BtnCloseUIInv => btnCloseUIInv;

    [SerializeField] protected UIInventoryShow invShow;
    public UIInventoryShow InvShow => invShow;

    [SerializeField] protected UIInvItemSpawner uiInvItemSpawner;
    public UIInvItemSpawner UIInvItemSpawner => uiInvItemSpawner;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One UIInventory only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadContentTrans();
        //Script
        this.LoadBtnCloseUIInv();
        this.LoadInvShow();
        this.LoadUIInvItemSpawner();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadContentTrans()
    {
        if (this.contentTrans != null) return;
        this.contentTrans = transform.Find("UI").Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadContentTrans", transform.gameObject);
    }

    //Script
    protected virtual void LoadBtnCloseUIInv()
    {
        if (this.btnCloseUIInv != null) return;

        Transform btnParent = transform.Find("UI");
        this.btnCloseUIInv = btnParent.GetComponentInChildren<BtnCloseUIInventory>();
        Debug.LogWarning(transform.name + ": LoadBtnCloseUIInv", transform.gameObject);
    }

    protected virtual void LoadInvShow()
    {
        if (this.invShow != null) return;
        this.invShow = transform.GetComponentInChildren<UIInventoryShow>();
        Debug.LogWarning(transform.name + ": LoadInvShow", transform.gameObject);
    }

    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.uiInvItemSpawner != null) return;
        this.uiInvItemSpawner = GetComponentInChildren<UIInvItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInvItemSpawner", transform.gameObject);
    }

    //===========================================Tester===========================================
    //protected virtual void SpawnTest()
    //{
    //    string itemName = this.uiInvItemSpawner.ItemOne;
    //    Vector3 itemPos = Vector3.zero;
    //    Quaternion itemRot = Quaternion.identity;

    //    Transform newPrefab = this.uiInvItemSpawner.Spawn(itemName, itemPos, itemRot);

    //    if (newPrefab == null) return;

    //    newPrefab.localScale = new Vector3(1, 1, 1);
    //    newPrefab.gameObject.SetActive(true);
    //}
}
