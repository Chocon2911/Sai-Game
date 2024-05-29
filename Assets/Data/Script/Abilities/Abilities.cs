using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : HuyMonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjManager abilityObjManager;
    public AbilityObjManager AbilityObjManager => abilityObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityObjManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadAbilityObjManager()
    {
        if (this.AbilityObjManager != null) return;
        this.abilityObjManager = transform.parent.GetComponent<AbilityObjManager>();
        Debug.LogWarning(transform.name + ": LoadAbilityObjManager", transform.gameObject);
    }
}
