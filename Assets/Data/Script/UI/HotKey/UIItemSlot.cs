using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemSlot : HuyMonoBehaviour, IDropHandler
{
    [Header("UI Item Slot")]
    [SerializeField] protected UIDragItem dragItem;
    public UIDragItem DragItem => dragItem;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDragItem();
    }

    //============================================Drop============================================
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount >= 1) return;
        //Debug.Log(transform.name + ": OnDrop", transform.gameObject);
        Transform dropObj = eventData.pointerDrag.transform;
        UIDragItem uiDragItem = dropObj.GetComponent<UIDragItem>();
        uiDragItem.SetItemSlotHolder(transform);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDragItem()
    {
        if (this.dragItem != null) return;
        this.dragItem = transform.GetComponentInChildren<UIDragItem>();
        Debug.LogWarning(transform.name + ": Load DragItem", transform.gameObject);
    }

    //============================================Set=============================================
    public virtual void SetDragItem(UIDragItem dragItem)
    {
        this.dragItem = dragItem;
    }
}
