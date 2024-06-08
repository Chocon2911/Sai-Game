using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : HuyMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected virtual void Start()
    {
        this.AddOnChangeEvent();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", transform.gameObject);
    }

    //===========================================Event============================================
    protected virtual void AddOnChangeEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChange);
    }

    protected abstract void OnChange(float newValue);
        
}
