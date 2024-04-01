using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawner
{
    [SerializeField] protected float disLimit = 50f;
    [SerializeField] protected float currDis = 0f;

    protected override void FixedUpdate()
    {
        this.DistanceBtwObjNCamera();
        base.FixedUpdate();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //======================================Load Component=========================================

    //=========================================Despawn=============================================
    protected override bool CanDespawn()
    {
        if (this.currDis >= this.disLimit) return true;
        return false;
    }

    protected virtual void DistanceBtwObjNCamera()
    {
        float objX = transform.position.x;
        float objY = transform.position.y;
        float camX = GameManager.Instance.transform.position.x;
        float camY = GameManager.Instance.transform.position.y;
        this.currDis = Mathf.Sqrt(Mathf.Pow(objX - camX, 2f) + Mathf.Pow(objY - camY, 2f));
    }
}
