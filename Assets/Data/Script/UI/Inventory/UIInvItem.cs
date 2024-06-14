using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInvItem : HuyMonoBehaviour
{
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Image itemIcon;
    public Image ItemIcon => itemIcon;

    [SerializeField] protected TextMeshProUGUI itemAmountTxt;
    public TextMeshProUGUI ItemAmountTxt => itemAmountTxt;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemIcon();
        this.LoadItemAmountTxt();
    }
    //=======================================Load Component=======================================
    protected virtual void LoadItemIcon()
    {
        if (this.itemIcon != null) return;
        this.itemIcon = transform.Find("ItemIcon").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadItemIcon", transform.gameObject);
    }

    protected virtual void LoadItemAmountTxt()
    {
        if (this.itemAmountTxt != null) return; 
        this.itemAmountTxt = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadItemAmountTxt", transform.gameObject);
    }

    //============================================Set=============================================
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    //===========================================Update===========================================
    public virtual void UpdateInvItem()
    {
        if (this.itemInventory == null)
        {
            Debug.LogError(transform.name + ": No ItemInventory", transform.gameObject);
            return;
        }

        this.itemIcon.sprite = this.itemInventory.ItemDropSO.ItemIcon;
        this.itemAmountTxt.text = this.itemInventory.ItemAmount.ToString();
    }
}
