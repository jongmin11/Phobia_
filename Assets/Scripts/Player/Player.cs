using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public PlayerCondition Condition;

    private void Awake()
    {
        Manager.PlayerManager.Player = this;
        Controller = GetComponent<PlayerController>();
        Condition = GetComponent<PlayerCondition>();
    }
}
