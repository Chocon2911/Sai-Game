using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : HuyMonoBehaviour
{
    [SerializeField] protected PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadPlayerManager();
    }

    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.parent.GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }
}
