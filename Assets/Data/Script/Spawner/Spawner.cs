using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HuyMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holderTrans;
    [SerializeField] protected List<Transform> holders;
    [SerializeField] protected List<Transform> prefabs;

    [Header("Stat")]
    [SerializeField] protected int spawnCount;
    public int SpawnCount => spawnCount;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolderTrans();
        this.LoadHolders();
        this.LoadPrefabs();
    }

    //=================================Load Component==============================================
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabTrans = transform.Find("Prefabs");
        if (prefabTrans == null)
        {
            Debug.LogWarning(transform.name + ": No Prefabs Object", transform.gameObject);
            return;
        }

        foreach (Transform obj in prefabTrans)
        {
            this.prefabs.Add(obj);
        }
        Debug.Log(transform.name + ": LoadPrefabs", transform.gameObject);

        this.HidePrefabs();
    }

    protected virtual void LoadHolders()
    {
        if (this.holders.Count > 0) return;

        Transform holderTrans = transform.Find("Holder");
        if (holderTrans == null) 
        { 
            Debug.LogError(transform.name + ": No Holder Object", transform.gameObject);
            return;
        }

        foreach(Transform obj in holderTrans)
        {
            this.holders.Add(obj);
        }

        if (this.holders.Count <= 0) return;

        Debug.Log(transform.name + ": LoadHolders", transform.gameObject);
    }

    protected virtual void LoadHolderTrans()
    {
        if (this.holderTrans != null) return;
        this.holderTrans = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHoldertrans", transform.gameObject);
    }

    //====================================public====================================================
    public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning("No prefab has name: " + prefabName, transform.gameObject);
            return null;
        }

        return Spawn(prefab, pos, rot);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(pos, rot);
        newPrefab.parent = this.holderTrans;
        this.spawnCount++;
        return newPrefab;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual void Despawn(Transform obj)
    {

        this.holders.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }
    
    //=================================Other Func==================================================
    protected virtual void HidePrefabs()
    {
        foreach (Transform obj in this.prefabs)
        {
            obj.gameObject.SetActive(false);
        }
        Debug.Log(transform.name + ": HidePrefabs", transform.gameObject);
    }

    protected virtual Transform GetPrefabByName(string name)
    {
        foreach(Transform obj in this.prefabs)
        {
            if (name == obj.name)
            {
                return obj;
            }
        }
        return null;
    }

    protected virtual Transform GetObjFromPool(Transform obj)
    {
        foreach(Transform prefab in this.holders)
        {
            if (prefab.name == obj.name + "(Clone)")
            {
                this.holders.Remove(prefab);
                //Debug.Log(transform.name + ": Get Obj from Pool", transform.gameObject);
                return prefab;
            }
        }

        Transform newPrefab = Instantiate(obj);
        //Debug.Log(transform.name + ": Clone new Obj", transform.gameObject);
        return newPrefab;
    }
}
