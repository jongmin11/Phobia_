using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float RunSpeed;
    private Vector2 CurInput;

    private Rigidbody _rigidbody;

    [Header("Look")]
    public Transform CameraContainer;
    private float MinXLook;
    private float MaxXLook;
    private float CamCurXRot;
    public float LookSensitivity;
    private Vector2 MouseDelta;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();


        //else if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //if (IsGrounded())
        //    {
        //        //PlayerTransform
        //    }
        //}


        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    //상호작용
        //}

        //else if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //Pause
        //}

        //else if (Input.GetMouseButtonDown(0))
        //{
        //    //Use item
        //}
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = transform.forward * CurInput.y + transform.right * CurInput.x;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dir *= RunSpeed;
        }
        else
        {
            dir *= Speed;
        }

        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
        
    }

    public void OnMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CurInput = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            CurInput = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CurInput = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CurInput = Vector2.right;
        }
        else
        {
            CurInput = Vector2.zero;
        }
    }

    // 대각선이동, normalze
    //public void OnLook()
    //{
    //    MouseDelta = Camera.Screen
    //}
}
