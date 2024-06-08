using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseTxt : HuyMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI txt;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadText()
    {
        if (this.txt != null) return;
        this.txt = transform.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", transform.gameObject);
    }
}
