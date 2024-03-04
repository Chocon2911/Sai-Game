using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class JunkFly : ParentFly
{
    [SerializeField] protected float randomRange = 10;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 1f;
    }

    protected virtual void OnEnable()
    {
        this.GetFlyDirection();
    }
    
    //=============================================Fly=============================================
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameManager.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x = Random.Range(-this.randomRange, this.randomRange);

        Vector3 dir = (camPos - objPos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
        Debug.DrawLine(objPos, camPos + dir * 0.5f, Color.red, Mathf.Infinity);
    }
}
