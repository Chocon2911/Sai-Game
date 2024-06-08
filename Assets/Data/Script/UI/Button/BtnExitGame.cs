using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitGame : BaseBtn
{
    //========================================Base Button=========================================
    protected override void OnClick()
    {
        Debug.Log(transform.name + ": Exit", transform.gameObject);
    }
}
