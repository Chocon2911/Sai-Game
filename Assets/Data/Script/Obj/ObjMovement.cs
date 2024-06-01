using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : HuyMonoBehaviour
{
    [Header("ShipMovement")]
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float minDistance = 0f;
    [SerializeField] protected float currDistance;

    protected virtual void FixedUpdate()
    {
        this.GetTargetPos();
        this.GetCurrDistance();
        this.Moving();
    }

    //============================================Set=============================================
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    //============================================Get=============================================
    protected abstract void GetTargetPos();

    protected virtual void GetCurrDistance()
    {
        this.currDistance = Vector2.Distance(transform.parent.position, this.targetPos);
    }

    //==========================================Movement==========================================
    protected virtual void Moving()
    {
        if (this.currDistance <= this.minDistance) return;
        
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed * Time.fixedDeltaTime);
        transform.parent.position = newPos - new Vector3(0, 0, newPos.z);
    }
}
