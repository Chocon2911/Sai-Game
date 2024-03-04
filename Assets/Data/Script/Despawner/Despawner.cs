using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Despawner : HuyMonoBehaviour
{
    protected virtual void Update()
    {
        this.CanDespawn();
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected abstract bool CanDespawn();

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
        Debug.Log("Object is despawned", transform.gameObject);
    }
}
