using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class JunkObjManager : HuyMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => junkSO;

    [Header("Script")]
    [SerializeField] protected JunkFly junkFly;
    public JunkFly JunkFly => junkFly;

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;

    [SerializeField] protected JunkRotate junkRotate;
    public JunkRotate JunkRotate => junkRotate;

    [SerializeField] JunkDamageReceiver junkDamageReceiver;
    public JunkDamageReceiver JunkDamageReceiver => junkDamageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadJunkSO();
        //Script
        this.LoadJunkFly();
        this.LoadJunkDespawn();
        this.LoadJunkRotate();
        this.LoadJunkDamageReceiver();
    }

    //========================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", transform.gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string pathSO = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(pathSO);
        Debug.LogWarning(transform.name + ": LoadJunkSO", transform.gameObject);
    }

    //Script
    protected virtual void LoadJunkFly()
    {
        if (this.junkFly != null) return;
        this.junkFly = transform.Find("JunkFly").GetComponent<JunkFly>();
        Debug.Log(transform.name + ": LoadJunkFly", transform.gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.Find("Despawn").GetComponent<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", transform.gameObject);
    }

    protected virtual void LoadJunkRotate()
    {
        if (this.junkRotate != null) return;
        this.junkRotate = transform.Find("JunkRotate").GetComponent<JunkRotate>();
        Debug.Log(transform.name + ": LoadJunkRotate", transform.gameObject);
    }

    protected virtual void LoadJunkDamageReceiver()
    {
        if (this.junkDamageReceiver != null) return;
        this.junkDamageReceiver = transform.Find("DamageReceiver").GetComponent<JunkDamageReceiver>();
        Debug.Log(transform.eulerAngles + ": LoadJunkDamageReceiver", transform.gameObject);
    }
}
