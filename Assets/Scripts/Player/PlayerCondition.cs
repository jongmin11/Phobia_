using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public ConditionUI conditionUI;

    Condition Stamina { get { return conditionUI.Stamina; } }
    Condition Mentality { get { return conditionUI.Mentality; } }

    private void Update()
    {
        Mentality.Subtract(Mentality.PassiveValue * Time.deltaTime);
    }

    public void Die()
    {
        Debug.Log("¿Ø¥Ÿ»Ò");
    }
}

