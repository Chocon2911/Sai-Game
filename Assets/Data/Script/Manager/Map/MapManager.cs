using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : HuyMonoBehaviour
{
    [SerializeField] protected MapLevel mapLevel;
    public MapLevel MapLevel => mapLevel;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMapLevel();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMapLevel()
    {
        if (this.mapLevel != null) return;
        this.mapLevel = transform.Find("Level").GetComponent<MapLevel>();
        Debug.Log(transform.name + ": LoadMapLevel", transform.gameObject);
    }
}
