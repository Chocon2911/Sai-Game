using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppear : HuyMonoBehaviour
{
    [Header("Obj Appear")]
    [SerializeField] protected List<IObjAppearObserver> observers = new List<IObjAppearObserver>();
    public List<IObjAppearObserver> Observers => observers;

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected virtual void Start()
    {
        this.OnAppearStart();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //===========================================Apeear===========================================
    protected abstract void Appearing();

    public virtual void Appeared()
    {
        this.OnAppearEnd();
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearEnd()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearEnd();
        }
    }

    //==========================================Observer==========================================
    public virtual void AddObserver(IObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }

    //===========================================Other============================================
}
