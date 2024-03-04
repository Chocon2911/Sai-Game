using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : HuyMonoBehaviour
{
    [SerializeField] protected JunkManager junkManager;
    public JunkManager JunkManager => junkManager;

    protected virtual void Start()
    {
        this.JunkSpawning();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkManager();
    }

    //===================================Load Component============================================
    protected virtual void LoadJunkManager()
    {
        if (this.junkManager != null) return;
        this.junkManager = transform.GetComponent<JunkManager>();
        Debug.Log(transform.name + ": LoadJunkManager", transform.gameObject);
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = this.junkManager.JunkSpawnPoints.GetRandom().position;
        Quaternion rot = this.junkManager.JunkSpawnPoints.GetRandom().rotation;
        Transform prefab = this.junkManager.JunkSpawner.Spawn(JunkSpawner.Instance.JunkOne, pos, rot);
        prefab.gameObject.SetActive(true);
        Debug.Log(transform.name + ": Spawn Junk", transform.gameObject);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
