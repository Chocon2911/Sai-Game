using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObj", menuName = "SO/ShootableObj")]
public class ShootableObjSO : ScriptableObject
{
    public string ShootableObjName = "ShootableObj";
    public ShootableObjType ShootableObjType;
    public int MaxHealth = 2;
    public List<DropRate> DropList;
}
