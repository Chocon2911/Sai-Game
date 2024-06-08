using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarManager : HuyMonoBehaviour
{
    [Header("Hp Bar")]
    [Header("Other")]
    [SerializeField] protected SliderHp sliderHp;
    public SliderHp SliderHp => sliderHp;

    [Header("Script")]
    [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;

    [SerializeField] protected HpBarModify hpBarModify;
    public HpBarModify HpBarModify => hpBarModify;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Other
        this.LoadSliderHp();

        // Script
        this.LoadFollowTarget();
        this.LoadHpBarModify();
    }

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", transform.gameObject);
    }

    // Script
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponentInChildren<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", transform.gameObject);
    }

    protected virtual void LoadHpBarModify()
    {
        if (this.hpBarModify != null) return;
        this.hpBarModify = transform.GetComponentInChildren<HpBarModify>();
        Debug.LogWarning(transform.name + ": LoadHpBarModify", transform.gameObject);
    }
}
