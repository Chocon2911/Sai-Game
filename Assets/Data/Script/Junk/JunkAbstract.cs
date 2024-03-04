using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : HuyMonoBehaviour
{
    protected JunkObjManager junkObjManager;
    public JunkObjManager JunkObjManager => junkObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkObjManager();
    }

    protected virtual void LoadJunkObjManager()
    {
        if (this.junkObjManager != null) return;
        this.junkObjManager = transform.parent.GetComponent<JunkObjManager>();
        Debug.Log(transform.name + ": LoadJunkObjManager", transform.gameObject);
    }
}
