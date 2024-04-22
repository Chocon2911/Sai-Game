using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class JunkManager : ShootableObjManager
{
    [Header("JunkManager")]
    [Header("Script")]
    [SerializeField] protected JunkFly junkFly;
    public JunkFly JunkFly => junkFly;

    [SerializeField] protected JunkRotate junkRotate;
    public JunkRotate JunkRotate => junkRotate;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadJunkFly();
        this.LoadJunkRotate();
    }

    //========================================Load Component=======================================
    //Script
    protected virtual void LoadJunkFly()
    {
        if (this.junkFly != null) return;
        this.junkFly = transform.Find("JunkFly").GetComponent<JunkFly>();
        Debug.Log(transform.name + ": LoadJunkFly", transform.gameObject);
    }

    protected virtual void LoadJunkRotate()
    {
        if (this.junkRotate != null) return;
        this.junkRotate = transform.Find("JunkRotate").GetComponent<JunkRotate>();
        Debug.Log(transform.name + ": LoadJunkRotate", transform.gameObject);
    }

    //===================================Shootable Obj Manager====================================
    protected override string GetShootableObjTypeStr()
    {
        return ShootableObjType.Junk.ToString();
    }
}
