using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDamageReceiver : ShootableObjDamageReceiver
{
    //=======================================DamageReceiver=======================================
    protected override void OnDead()
    {
        SceneManager.LoadScene(0);
    }
}
