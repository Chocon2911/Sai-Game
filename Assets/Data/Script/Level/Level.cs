using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : HuyMonoBehaviour
{
    [Header("Level")]
    [Header("Stat")]
    [SerializeField] protected int currLevel = 0;
    public int CurrLevel => currLevel;
    [SerializeField] protected int maxLevel = 99;
    public int MaxLevel => maxLevel;

    //===========================================Public===========================================
    public virtual void LevelUp()
    {
        if (this.IsLimitLevel()) return;
        this.currLevel++;
    }

    //============================================Set=============================================
    public virtual void SetCurrLevel(int currLevel)
    {
        if (this.IsLimitLevel())
        {
            Debug.LogError(transform.name + ": Your set Level is too high", transform.gameObject);
            return;
        }
        this.currLevel = currLevel;
    }

    //===========================================Level============================================
    protected virtual bool IsLimitLevel()
    {
        if (currLevel < 0) this.currLevel = 0;
        if (this.currLevel >= this.maxLevel)
        {
            this.currLevel = this.maxLevel;
            return true;
        }

        return false;
    }
}
