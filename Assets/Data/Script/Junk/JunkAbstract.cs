using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : HuyMonoBehaviour
{
    [SerializeField] protected JunkManager junkManager;
    public JunkManager JunkManager => junkManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkObjManager();
    }

    protected virtual void LoadJunkObjManager()
    {
        if (this.junkManager != null) return;
        this.junkManager = transform.parent.GetComponent<JunkManager>();
        Debug.Log(transform.name + ": LoadJunkObjManager", transform.gameObject);
    }
}
