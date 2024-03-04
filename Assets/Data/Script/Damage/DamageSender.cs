using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : HuyMonoBehaviour
{
    [SerializeField] protected float damage;

    //==============================================Public=========================================
    public virtual void Sender(Transform target)
    {
        DamageReceiver damageReceiver;
        damageReceiver = transform.Find("DamageReceiver").GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
    }

    //===============================================Send==========================================
    protected virtual void Sender(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHealth(this.damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
