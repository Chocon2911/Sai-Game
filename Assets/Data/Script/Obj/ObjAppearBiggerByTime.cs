using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjAppearBiggerByTime : ObjAppear
{
    [Header("Obj Appear Bigger By Time")]
    [Header("stat")]
    [SerializeField] protected float beginScale;
    [SerializeField] protected float endScale;
    [SerializeField] protected float currScale;
    [SerializeField] protected float appearTimer;
    [SerializeField] protected float appearDuration;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DefaultStat();
    }

    protected virtual void OnEnable()
    {
        this.InitStat();
    }

    //=========================================Obj Appear=========================================
    protected override void Appearing()
    {
        if (this.appearTimer >= this.appearDuration) return;

        this.appearTimer += Time.fixedDeltaTime;
        if (this.appearTimer >= this.appearDuration)
        {
            this.currScale = this.endScale;
            this.Appeared();
            return;
        }

        this.currScale = this.appearTimer / this.appearDuration * this.endScale;
        transform.parent.localScale = new Vector3(this.currScale, this.currScale, this.currScale);
    }

    public override void Appeared()
    {
        base.Appeared();
        transform.parent.localScale = new Vector3(this.endScale, this.endScale, this.currScale);
    }

    //===========================================Other============================================
    protected virtual void InitStat()
    {
        this.currScale = this.beginScale;
        this.appearTimer = 0;
    }

    protected virtual void DefaultStat()
    {
        this.beginScale = 0f;
        this.currScale = beginScale;
        this.endScale = 1;
        this.appearDuration = 0;
        this.appearDuration = 2;
    }
}
