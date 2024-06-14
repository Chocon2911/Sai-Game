using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagBtn : BaseBtn
{
    //========================================Base Button=========================================
    protected override void OnClick()
    {
        UIInventoryManager.Instance.InvShow.Toggle();
    }
}
