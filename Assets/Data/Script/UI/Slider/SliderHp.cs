using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    [SerializeField] protected float maxHp = 10;
    [SerializeField] protected float currHp = 10;

    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }

    //========================================Base Slider=========================================
    protected override void OnChange(float newValue)
    {
        
    }

    //===========================================Slider===========================================
    protected virtual void HpShowing()
    {
        float hpPercent = this.currHp / maxHp * 100;
        this.slider.value = hpPercent;
    }

    //=============================================Hp=============================================
    public virtual void SetMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
    }

    public virtual void SetCurrHp(float currHp)
    {
        this.currHp = currHp;
    }
}
