using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float delay;
    public float timer = 0;

    protected virtual void OnEnable()
    {
        this.ResetTimer();
    }

    //========================================Time================================================
    protected virtual void ResetTimer()
    {
        this.timer = 0f;
    }

    //=======================================Despawn==============================================
    protected override bool CanDespawn()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return false;
        return true;
    }

}
