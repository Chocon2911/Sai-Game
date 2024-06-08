using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Ability Warp")]
    protected Vector4 keyDirection;
    [SerializeField] protected float warpSpeed = 1;
    [SerializeField] protected float warpDistance = 1;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    //============================================Warp============================================
    protected virtual void Warping()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;
        if (this.warpDirection == Vector4.zero) return;

        Debug.Log(transform.name + ": Warping", transform.gameObject);
        Debug.Log(this.keyDirection, transform.gameObject);

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }

    protected virtual void WarpFinish()
    {
        // Spawn FX
        Transform newFXPrefab = FXSpawner.Instance.Spawn(FXSpawner.Instance.Impact_1, this.GetFXPos(), this.GetFXRot());
        if (newFXPrefab == null) Debug.LogError(transform.name + ": Can't spawn FX", transform.gameObject);
        else newFXPrefab.gameObject.SetActive(true);

        // Warp Obj
        this.WarpObj();

        Debug.Log("<b>Warp Finish</b>");

        // Refresh Ability
        this.warpDirection.Set(0, 0, 0, 0);
        this.isWarping = false;
        this.RestartCooldownAbility();
    }

    protected virtual void WarpObj()
    {
        Transform prefab = this.abilitites.AbilityObjManager.transform;
        Vector3 newPos = prefab.position;
        Vector4 warpRoad = this.warpDirection * warpDistance;

        newPos.x -= warpRoad.x;
        newPos.x += warpRoad.y;
        newPos.y += warpRoad.z;
        newPos.y -= warpRoad.w;

        prefab.position = newPos;
    }

    //=========================================Direction==========================================
    protected virtual void CheckWarpDirection()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;
        if (this.keyDirection == Vector4.zero) return;

        this.warpDirection = this.keyDirection;
    }

    //=============================================FX=============================================
    protected virtual Vector3 GetFXPos()
    {
        Vector3 fxPos = this.abilitites.AbilityObjManager.transform.position;
        return fxPos;
    }

    protected virtual Quaternion GetFXRot()
    {
        float left = this.warpDirection.x;
        float right = this.warpDirection.y;
        float front = this.warpDirection.z;
        float down = this.warpDirection.w;
        float angle = 0;
        Quaternion fxRot = this.abilitites.AbilityObjManager.transform.rotation;

        if (left == 1) angle = 180;
        if (right == 1) angle = 0;
        if (front == 1) angle = 90;
        if (down == 1) angle = -90;

        if (left == 1 && front == 1) angle = 135;
        if (left == 1 && down == 1) angle = -135;
        if (right == 1 && front == 1) angle = 45;
        if (right == 1 && down == 1) angle = -45;

        fxRot = Quaternion.Euler(fxRot.x, fxRot.y, fxRot.z + angle);
        return fxRot;
    }
}