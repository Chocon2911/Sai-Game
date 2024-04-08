using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : HuyMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;
    
    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    //==============================================Follow=========================================
    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector2.Lerp(transform.position, target.position, this.speed * Time.fixedDeltaTime);
    }
}
