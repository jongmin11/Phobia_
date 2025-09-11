using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float RunSpeed;
    private float MoveX;
    private float MoveY;
    private Vector3 Mov;

    private Rigidbody _rigidbody;

    [Header("Look")]
    public Transform CameraContainer;
    public float MinXLook;
    public float MaxXLook;
    private float CamCurXRot;
    private float CamCurYRot;
    public float LookSensitivity;
    private Vector3 LookDir;

    [Header("Jump")]
    public float JumpPower;
    public LayerMask GroundLayerMask;


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
        OnLook();
        OnJump();
        //Pause();
        //Interatcion();
        //UseItem();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }

    //입력로직
    public void OnMove()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Mov = new Vector3(MoveX, 0, MoveY);

        
    }

    // 이동로직
    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Mov * Time.deltaTime * RunSpeed);
        }
        else
        {
            this.transform.Translate(Mov * Time.deltaTime * Speed);
        }
    }

    public void OnLook()
    {

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        CamCurXRot += v * LookSensitivity * Time.deltaTime;
        CamCurYRot += h * LookSensitivity * Time.deltaTime;

        CamCurXRot = Mathf.Clamp(CamCurXRot, MinXLook, MaxXLook);


        LookDir = new Vector3(-CamCurXRot, CamCurYRot, 0);
        
    }

    public void Look()
    {
        transform.eulerAngles = LookDir;
    }

    public void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, GroundLayerMask))
            {
                return true;
            }
        }

        return false;
     }


    // ESC눌렀을 때 일시정지
    //public void Pause()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        pause창 등장
    //    }
    //}


    // E키 - 상호작용
    //public void Interatcion()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        상호작용
    //    }
    //}


    //마우스 좌클릭 - 아이템 사용
    //public void UseItem()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        들고있는 아이템 사용
    //    }
    //}
}

