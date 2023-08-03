using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {
        //For Override
    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void OnEnable()
    {
        //For Override
    }
    protected virtual void Start()
    {
        //For Override
    }
}
