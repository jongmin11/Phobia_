using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerCondition playerCondition;
    [SerializeField] private ConditionUI conditionUI;
    Condition Stamina { get { return conditionUI.Stamina; } }
    Condition Mentality { get { return conditionUI.Mentality; } }

    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float RunSpeed;

    [Header("Look")]
    public Transform CameraContainer;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        if (playerCondition == null) playerCondition = GetComponent<PlayerCondition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        Interatcion();
        UseItem();
        DropItem();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }


    // 이동로직
    public void Move()
    {
        if (playerInput.Run() && playerCondition.TryConsumeStamina(Stamina.PassiveValue))
        {
            this.transform.Translate(playerInput.Mov * Time.deltaTime * RunSpeed);
        }
        else if(Mentality.CurValue == 0)
        {
            this.transform.Translate(playerInput.Mov * Time.deltaTime * Speed * 0.8f);
        }
        else
        {
            this.transform.Translate(playerInput.Mov * Time.deltaTime * Speed);
        }
    }



    public void Look()
    {
        transform.eulerAngles = playerInput.LookDir;
    }


    public void Pause()
    {
        if (playerInput.OnPause())
        {
            
        }
    }


    
    public void Interatcion()
    {
        if (playerInput.OnInteratcion())
        {
            
        }
    }


    
    public void UseItem()
    {
        if (playerInput.OnUseItem())
        {
            
        }
    }

    
    public void DropItem()
    {
        if (playerInput.OnDropItem())
        {
            
        }
    }
}
