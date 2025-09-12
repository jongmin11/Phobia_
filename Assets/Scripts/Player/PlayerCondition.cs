using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public ConditionUI conditionUI;

    Condition Stamina { get { return conditionUI.Stamina; } }
    Condition Mentality { get { return conditionUI.Mentality; } }


    [Header("Stamina")]
    [SerializeField] private float GetStaminaDelay = 1f;
    private float Standard = 0.0001f;

    private float LastStaminaValue;
    private float StableTimer;
    private bool CanGetStamina;

    private void Awake()
    {
        LastStaminaValue = Stamina.CurValue;
        StableTimer = 0f;
        CanGetStamina = false;
    }


    private void Update()
    {
        Mentality.Subtract(Mentality.PassiveValue * Time.deltaTime);

        float CurStamina = Stamina.CurValue;
        bool Changed = LastStaminaValue - CurStamina < 0;

        // 스태미너를 회복할 조건이 아니면(기준 : 스태미너를 소모안한지 GetStaminaDelay(1초)만큼 지났는가?)
        if (!CanGetStamina)
        {
            // StableTimer는 스태미너 값이 변동하면 무조건 0, 변동이 아니면 GetStaminaDelay가 될때까지 시간을 더)
            StableTimer = Changed ? 0f : (StableTimer + Time.deltaTime);

            // GetStaminaDelay가 넘으면 스태미너 회복 가능 모드로 변환
            if (CurStamina < Stamina.MaxValue && StableTimer > GetStaminaDelay)
            {
                CanGetStamina = true;
            }
        }
        else
        {
            // 만약 스태미너를 사용하면 스태미너 회복 불가능 모드, stableTimer = 0
            if(CurStamina+Standard < LastStaminaValue)
            {
                CanGetStamina = false;
                StableTimer = 0f;
            }

            else
            {
                Stamina.Add(Stamina.PassiveValue * Time.deltaTime);

                if( CurStamina >= Stamina.MaxValue)
                {
                    CanGetStamina = false;
                    StableTimer = 0f;
                }
            }
            
        }
        LastStaminaValue = Stamina.CurValue;
    }

    public void Die()
    {
        Debug.Log("You Die");
    }

    public bool TryConsumeStamina(float PassiveValue)
    {
        if (Stamina.CurValue == 0) return false;

        Stamina.Subtract(Stamina.PassiveValue*Time.deltaTime);
        return true;
    }
}

