using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyAbstract : HuyMonoBehaviour
{
    [Header("UI Hot Key Abstract")]
    [SerializeField] protected UIHotKeyManager manager;
    public UIHotKeyManager Manager => manager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<UIHotKeyManager>();
        Debug.LogWarning(transform.name + ": LoadManager", transform.gameObject);
    }
}
