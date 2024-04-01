using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 1f;

    private void FixedUpdate()
    {
        this.GetTargetPos(InputManager.Instance.MousePos);
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPos(Vector3 pos)
    {
        this.targetPos = pos;
        this.targetPos.z = 0f;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 dir = this.targetPos - transform.parent.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected virtual void Moving()
    {
        if (InputManager.Instance.IsIdle) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed * Time.fixedDeltaTime);
        transform.parent.position = newPos;
    }
}
