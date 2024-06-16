using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHKManager : HuyMonoBehaviour
{
    [Header("Input Hot Key Manager")]
    private static InputHKManager instance;
    public static InputHKManager Instance => instance;

    [Header("Other")]
    [SerializeField] protected int hk1;
    public int HK1 => hk1;

    [SerializeField] protected int hk2;
    public int HK2 => hk2;

    [SerializeField] protected int hk3;
    public int HK3 => hk3;

    [SerializeField] protected int hk4;
    public int HK4 => hk4;

    [SerializeField] protected int hk5;
    public int HK5 => hk5;

    [SerializeField] protected int hk6;
    public int HK6 => hk6;

    [SerializeField] protected int hk7;
    public int HK7 => hk7;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One InputHKManager Only", transform.gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }

    protected virtual void Update()
    {
        this.GetHotKey();
    }
    
    //============================================Get=============================================
    protected virtual void GetHotKey()
    {
        this.hk1 = Input.GetKeyDown(KeyCode.Alpha1) ? 1 : 0;
        this.hk2 = Input.GetKeyDown(KeyCode.Alpha2) ? 1 : 0;
        this.hk3 = Input.GetKeyDown(KeyCode.Alpha3) ? 1 : 0;  
        this.hk4 = Input.GetKeyDown(KeyCode.Alpha4) ? 1 : 0;
        this.hk5 = Input.GetKeyDown(KeyCode.Alpha5) ? 1 : 0;
        this.hk6 = Input.GetKeyDown(KeyCode.Alpha6) ? 1 : 0;
        this.hk7 = Input.GetKeyDown(KeyCode.Alpha7) ? 1 : 0;

        // if (hk1 == 1) Debug.Log("Input HK1");
        // if (hk2 == 1) Debug.Log("Input HK2");
        // if (hk3 == 1) Debug.Log("Input HK3");
        // if (hk4 == 1) Debug.Log("Input HK4");
        // if (hk5 == 1) Debug.Log("Input HK5");
        // if (hk6 == 1) Debug.Log("Input HK6");
        // if (hk7 == 1) Debug.Log("Input HK7");
    }
}