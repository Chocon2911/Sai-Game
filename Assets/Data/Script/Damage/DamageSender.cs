using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : HuyMonoBehaviour
{
    [SerializeField] protected float damage = 1f;

    //==========================================Sender============================================
    public virtual void SendByObj(Transform obj)
    {
        DamageReceiver damageReceiver;
        damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendByReceiver(damageReceiver);
    }

    public virtual void SendByReceiver(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    //============================================Object==========================================
    protected virtual void DestroyObj()
    {
        Destroy(transform.parent.gameObject);
    }
}
