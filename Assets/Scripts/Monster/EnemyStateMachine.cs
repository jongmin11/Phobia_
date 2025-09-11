using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    public enum EnemyState { Idle, Patrol, Chase, Attack }
    EnemyState enemyState;

    [Header("Monster Speed")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;


    public Transform player;
    private float playerDistance;
    private Animator animator;
    private EnemyMovement movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<EnemyMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerDistance = Vector3.Distance(transform.position, player.position);
        }

        animator.SetBool("Moving", enemyState != EnemyState.Idle);

        switch (enemyState)
        {
            case EnemyState.Idle:
                HandleIdle();
                break;
            case EnemyState.Patrol:
                HandlePatrol();
                break;
            case EnemyState.Chase:
                HandleChase();
                break;
            case EnemyState.Attack:
                HandleIdle();
                break;
        }
        CheckStateTransition();
    }
    void HandleIdle() { }
    void HandlePatrol() { movement.MoveToPatrolPoint(walkSpeed); }
    void HandleChase() { movement.ChasePlayer(player, runSpeed); }
    void HandleAttack() { }

    void CheckStateTransition()
    {
        if (playerDistance < 2f) enemyState = EnemyState.Attack;
        else if (playerDistance < 8f) enemyState = EnemyState.Chase;
        else enemyState = EnemyState.Patrol;
    }
}
