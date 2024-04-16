
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "SO/Junk")]
public class JunkSO : ScriptableObject
{
    public string JunkName = "Junk";
    public float MaxHealth = 2;
    public List<DropRate> DropList = new List<DropRate>();
}
