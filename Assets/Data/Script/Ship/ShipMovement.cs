using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipMovement : HuyMonoBehaviour
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
        this.LookAtTarget();
        this.Moving();
    }

    //============================================Get=============================================
    protected abstract void GetTargetPos();

    protected virtual void GetCurrDistance()
    {
        this.currDistance = Vector2.Distance(transform.parent.position, this.targetPos);
    }

    //==========================================Movement==========================================
    protected virtual void LookAtTarget()
    {
        Vector3 dir = this.targetPos - transform.parent.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected virtual void Moving()
    {
        if (this.currDistance <= this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed * Time.fixedDeltaTime);
        transform.parent.position = newPos;
    }
}
