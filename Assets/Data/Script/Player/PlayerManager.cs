using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    [Header("PlayerManager")]
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    [Header("Script")]
    [SerializeField] protected ShipManager currShip;
    public ShipManager CurrShip => currShip;

    [SerializeField] protected PlayerLooter playerLooter;
    public PlayerLooter PlayerLooter => playerLooter;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError(transform.name + ": One PlayerManager Only", transform.gameObject);
        instance = this;
        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadPlayerLooter();
    }

    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadPlayerLooter()
    {
        if (this.playerLooter != null) return;
        this.playerLooter = transform.Find("Looter").GetComponent<PlayerLooter>();
        Debug.Log(transform.name + ": LoadPlayerLooter", transform.gameObject);
    }
}
