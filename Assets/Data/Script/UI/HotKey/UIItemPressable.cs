using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemPressable : HuyMonoBehaviour
{
    public virtual void Pressed()
    {
        Debug.Log(transform.name + ": Is Pressed", transform.gameObject);
    }
}
