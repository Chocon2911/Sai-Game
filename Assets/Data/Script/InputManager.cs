using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos => mousePos;

    [SerializeField] protected bool isFiring;
    public bool IsFiring => isFiring;

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError(transform.name + ": One Instance only", transform.gameObject);
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMousePos();
        this.GetSpaceDown();
    }

    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetSpaceDown()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
        {
            this.isFiring = true;
        }
        else
        {
            this.isFiring = false;
        }
    }
}
