using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 Mov;
    private float CamCurXRot;
    private float CamCurYRot;
    public float LookSensitivity;
    public Vector3 LookDir;
    public float MinXLook;
    public float MaxXLook;



    private void Update()
    {
        OnMove();
        OnLook();
        OnPause();
        OnInteratcion();
        OnUseItem();
        OnDropItem();
    }

    public void OnMove()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Mov = new Vector3(MoveX, 0, MoveY);
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


    public bool OnPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }

        return false;
    }


    //E키 - 상호작용
    public bool OnInteratcion()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }
        return false;
    }


    //마우스 좌클릭 - 아이템 사용
    public bool OnUseItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    //마우스 좌클릭 - 아이템 버리기
    public bool OnDropItem()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            return true;
        }
        return false;
    }

    public bool Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        return false;
    }
}
