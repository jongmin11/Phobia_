using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    public Condition Stamina;
    public Condition Mentality;


    void Start()
    {
        Manager.PlayerManager.Player.Condition.conditionUI = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
