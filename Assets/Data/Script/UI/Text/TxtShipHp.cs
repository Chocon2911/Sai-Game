using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TxtShipHp : BaseTxt
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHp();
    }

    //===========================================Update===========================================
    protected virtual void UpdateShipHp()
    {
        float hp = PlayerManager.Instance.CurrShip.ShootableObjDamageReceiver.Health;
        float maxHp = PlayerManager.Instance.CurrShip.ShootableObjDamageReceiver.MaxHealth;

        this.txt.SetText(hp + "/" + maxHp);
    }
}
