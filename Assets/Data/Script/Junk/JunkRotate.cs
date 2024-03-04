using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    //=========================================Rotate==============================================
    protected virtual void Rotating()
    {
        Vector3 dir = Vector3.forward;
        this.junkObjManager.Model.Rotate(dir * this.speed * Time.fixedDeltaTime);
    }
}
