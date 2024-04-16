using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ShootableObjManager
{
    //===================================Shootable Obj Manager====================================
    protected override string GetShootableObjTypeStr()
    {
        return ShootableObjType.Enemy.ToString();
    }
}
