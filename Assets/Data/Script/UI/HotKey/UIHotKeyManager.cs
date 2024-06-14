using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyManager : HuyMonoBehaviour
{
    private static UIHotKeyManager instance;
    public static UIHotKeyManager Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One UIHotKeyManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
    
