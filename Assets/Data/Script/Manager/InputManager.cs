using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos => mousePos;

    protected Vector4 direction;
    public Vector4 Direction => direction;

    [SerializeField] protected bool isFiring;
    public bool IsFiring => isFiring;

    [SerializeField] protected bool isIdle;
    public bool IsIdle => isIdle;

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError(transform.name + ": One Instance only", transform.gameObject);
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMousePos();
        this.GetSpaceDown();
        this.GetShiftDown();
        this.GetDirectionByKeyDown();
    }

    //========================================Input===============================================
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

    protected virtual void GetShiftDown()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift)) this.isIdle = true;
        else this.isIdle = false;
    }

    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;

        //if (this.direction.x == 1) Debug.Log(transform.name + "Pressed A", transform.gameObject);
        //else if (this.direction.y == 1) Debug.Log(transform.name + ": Pressed D", transform.gameObject);
        //else if (this.direction.z == 1) Debug.Log(transform.name + ": Pressed W", transform.gameObject);
        //else if (this.direction.w == 1) Debug.Log(transform.name + ": Pressed S", transform.gameObject);
    }
}
