using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BaseBtn : HuyMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button btn;

    protected virtual void Start()
    {
        this.AddOnClickEvent(this.OnClick);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBtn();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBtn()
    {
        if (this.btn != null) return;
        this.btn = transform.GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadBtn", transform.gameObject);
    }

    //===========================================Event============================================
    protected virtual void AddOnClickEvent(UnityAction onClickEvent)
    {
        this.btn.onClick.AddListener(onClickEvent);
    }

    protected abstract void OnClick();
}
