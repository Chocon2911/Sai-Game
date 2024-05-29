using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : EnemyAbstract, IObjAppearObserver
{
    [Header("Obj Appear Without Shoot")]
    [SerializeField] protected ObjAppear objAppear;
    public ObjAppear ObjAppear => objAppear;
    
    protected virtual void OnEnable()
    {
        this.RegisterAppearEvent();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjAppear();
    }

    //======================================Appear Observer=======================================
    public void OnAppearStart()
    {
        this.enemyManager.ObjShooting.gameObject.SetActive(false);
    }

    public void OnAppearEnd()
    {
        this.enemyManager.ObjShooting.gameObject.SetActive(true);
    }

    //========================================Appear Event========================================
    protected virtual void RegisterAppearEvent()
    {
        this.objAppear.AddObserver(this);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadObjAppear()
    {
        if (this.objAppear != null) return;
        this.objAppear = GetComponent<ObjAppear>();
        Debug.LogWarning(transform.name + ": LoadObjAppear", transform.gameObject);
    }
}
