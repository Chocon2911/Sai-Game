using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyManager : HuyMonoBehaviour
{
    [Header("UI Hot Key Manager")]
    private static UIHotKeyManager instance;
    public static UIHotKeyManager Instance => instance;

    [Header("Script")]
    [SerializeField] protected UIHotKeyPress hkPress;
    public UIHotKeyPress HKPress => hkPress;

    [SerializeField] protected List<UIItemSlot> itemSlots;
    public List<UIItemSlot> ItemSlots => itemSlots;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One UIHotKeyManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHKPress();
        this.LoadItemSlots();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadHKPress()
    {
        if (this.hkPress != null) return;
        this.hkPress = transform.GetComponentInChildren<UIHotKeyPress>();
        Debug.LogWarning(transform.name + ": Load HKPress", transform.gameObject);
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        UIItemSlot[] itemSlotArr = transform.GetComponentsInChildren<UIItemSlot>();
        this.itemSlots.AddRange(itemSlotArr);
        Debug.LogWarning(transform.name + ": Load ItemSlots", transform.gameObject);
    }
}

