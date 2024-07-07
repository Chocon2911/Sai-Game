using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDragItem : HuyMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI Drag Item")]
    [Header("Other")]
    [SerializeField] protected Transform itemSlotHolder;
    public Transform ItemSlotHolder => itemSlotHolder;

    [SerializeField] protected Image image;
    public Image Image => image;

    [Header("Script")]

    [SerializeField] protected UIItemPressable pressable;
    public UIItemPressable Pressable => pressable;

    [Header("Stat")]
    [SerializeField] protected float backSpeed = 1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        
        //Other
        this.LoadItemSlotHolder();
        this.LoadImage();

        //Script
        this.LoadPressable();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadItemSlotHolder()
    {
        if (this.itemSlotHolder != null) return;
        this.itemSlotHolder = transform.parent;
        Debug.LogWarning(transform.name + ": Load ItemSlotHolder", transform.gameObject);
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.GetComponent<Image>();
        Debug.LogWarning(transform.name + ": Load Image", transform.gameObject);
    }

    //Script
    protected virtual void LoadPressable()
    {
        if (this.pressable != null) return;
        this.pressable = transform.GetComponentInChildren<UIItemPressable>();
        Debug.LogWarning(transform.name + ": Load Pressable", transform.gameObject);
    }

    //============================================Drag============================================
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log(transform.name + ": Begin Drag", transform.gameObject);
        this.image.raycastTarget = false;
        transform.SetParent(UIHotKeyManager.Instance.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log(transform.name + ": On Drag", transform.gameObject);
        this.FollowMouse();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log(transform.name + ": End Drag", transform.gameObject);
        
        this.image.raycastTarget = true;
        this.BackToSlot();
    }

    //===========================================Follow===========================================
    protected virtual void FollowMouse()
    {
        Vector3 mousePos = InputManager.Instance.MousePos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public virtual void BackToSlot()
    {
        Vector3 itemSlotPos = itemSlotHolder.position;
        Vector3 newPos = Vector3.Lerp(transform.position, itemSlotPos, backSpeed * Time.fixedDeltaTime);
        transform.position = newPos;

        float distance = Mathf.Sqrt(Mathf.Pow(newPos.x - itemSlotPos.x, 2) + Mathf.Pow(newPos.y - itemSlotPos.y, 2));
        float error = 0.1f;

        this.ItemSlotLoadThis();

        if (distance > error) Invoke(nameof(BackToSlot), Time.fixedDeltaTime);
        else
        {
            transform.SetParent(itemSlotHolder);
            transform.position = transform.parent.position;
        }
    }

    //============================================Load============================================
    protected virtual void ItemSlotLoadThis()
    {
        UIItemSlot itemSlot = ItemSlotHolder.GetComponent<UIItemSlot>();

        if (itemSlot == null)
        {
            Debug.LogError(transform.name + ": Can't find UIItemSlot", transform.gameObject);
            return;
        }

        itemSlot.SetDragItem(this);
    }

    //============================================Set=============================================
    public virtual void SetItemSlotHolder(Transform itemSlotHolder)
    {
        this.itemSlotHolder = itemSlotHolder;
    }
}
