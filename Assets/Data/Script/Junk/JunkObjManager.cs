using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkObjManager : HuyMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    //========================================Load Component=======================================
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", transform.gameObject);
    }
}
