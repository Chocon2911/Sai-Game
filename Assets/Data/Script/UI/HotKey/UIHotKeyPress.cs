using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyPress : UIHotKeyAbstract
{
    protected virtual void Update()
    {
        this.CheckHKPress();
    }

    //==========================================Checker===========================================
    protected virtual void CheckHKPress()
    {
        int hk = 0;

        if (InputHKManager.Instance.HK1 == 1) hk = 1;
        if (InputHKManager.Instance.HK2 == 1) hk = 2;
        if (InputHKManager.Instance.HK3 == 1) hk = 3;
        if (InputHKManager.Instance.HK4 == 1) hk = 4;
        if (InputHKManager.Instance.HK5 == 1) hk = 5;
        if (InputHKManager.Instance.HK6 == 1) hk = 6;
        if (InputHKManager.Instance.HK7 == 1) hk = 7;

        if (hk <= 0) return;
        this.Press(hk);
    }

    //===========================================Press============================================
    protected virtual void Press(int hk)
    {
        if (hk <= 0) return;

        UIDragItem dragItem = this.Manager.ItemSlots[hk - 1].DragItem;

        if (dragItem == null) return; 
        UIItemPressable itemPressable = dragItem.Pressable;

        if (itemPressable == null) return;
        itemPressable.Pressed();
    }
}
