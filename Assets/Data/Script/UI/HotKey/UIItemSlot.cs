using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemSlot : HuyMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount >= 1) return;
        Debug.Log(transform.name + ": OnDrop", transform.gameObject);
        Transform dropObj = eventData.pointerDrag.transform;
        UIDragItem uiDragItem = dropObj.GetComponent<UIDragItem>();
        uiDragItem.SetItemSlotHolder(transform);
    }
}
