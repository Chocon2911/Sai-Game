using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkManager : HuyMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    [SerializeField] protected JunkRandom junkRandom;
    public JunkRandom JunkRandom => junkRandom;

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints => junkSpawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadJunkRandom();
        this.LoadSpawnPoints();
    }

    //======================================Load Component=========================================
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = transform.GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", transform.gameObject); 
    }

    protected virtual void LoadJunkRandom()
    {
        if (this.junkRandom != null) return;
        this.junkRandom = transform.GetComponent<JunkRandom>();
        Debug.Log(transform.name + ": LoadJunkRandom", transform.gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints = GameObject.Find("JunkSpawnPoints").GetComponent<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }
}
