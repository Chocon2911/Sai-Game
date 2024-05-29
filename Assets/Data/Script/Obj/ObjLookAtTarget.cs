using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjLookAtTarget : HuyMonoBehaviour
{
    [Header("Obj Look At Target")]
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float rotSpeed = 3;

    protected virtual void FixedUpdate()
    {
        this.GetTargetPos();
        this.LookAtTarget();
    }

    //============================================Set=============================================
    public virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }

    //============================================Get=============================================

    protected abstract void GetTargetPos();


    //============================================Look============================================
    protected virtual void LookAtTarget()
    {
        Vector3 dir = this.targetPos - transform.parent.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float rotSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetAngle = Quaternion.Euler(0, 0, angle);
        Quaternion currAngle = Quaternion.Lerp(transform.parent.rotation, targetAngle, rotSpeed);

        transform.parent.rotation = currAngle;
    }
}
