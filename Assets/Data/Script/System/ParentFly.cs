using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HuyMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 dir = Vector3.right;

    protected void FixedUpdate()
    {
        transform.parent.Translate(this.moveSpeed * dir * Time.fixedDeltaTime);
    }
}
