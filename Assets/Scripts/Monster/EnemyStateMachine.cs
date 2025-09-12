using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyStateMachine : MonoBehaviour
{

    public enum EnemyState { Idle, Patrol, Chase, Attack }

    [Header("Monster Speed")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;
    EnemyState enemyState;

    [Header("Patrol")]
    public float minPatrolDistance;
    public float maxPatrolDistance;
    public float minPatrolWaitTime;
    public float maxPatrolWaitTime;

    [Header("ETC")]
    private float playerDistance;
    public float findDistance;
    public float fieldOfView = 120f;
    private Animator animator;
    public Transform Player;
    private SkinnedMeshRenderer[] meshRenderers;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }
    void Start()
    {
        SetState(EnemyState.Patrol);
    }
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, Player.position);
        animator.SetBool("Moving", enemyState != EnemyState.Idle);

        switch (enemyState)
        {
            case EnemyState.Idle:
            case EnemyState.Patrol:
                PassiveUpdate();
                break;
            case EnemyState.Chase:
                ChasingUpdate();
                break;
        }
    }
    public void SetState(EnemyState state)
    {
        enemyState = state;
        switch (enemyState)
        {
            case EnemyState.Idle:
                agent.speed = walkSpeed;
                agent.isStopped = true;
                break;
            case EnemyState.Patrol:
                agent.speed = walkSpeed;
                agent.isStopped = false;
                break;
            case EnemyState.Chase:
                agent.speed = runSpeed;
                agent.isStopped = false;
                break;
        }
        animator.speed = agent.speed / walkSpeed;
    }
    void PassiveUpdate()
    {
        if (enemyState == EnemyState.Patrol && agent.remainingDistance < 0.1f)
        {
            SetState(EnemyState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minPatrolWaitTime, maxPatrolWaitTime));
        }
        if (playerDistance < detectDistance)
        {
            SetState(EnemyState.Chase);
        }
    }
    void WanderToNewLocation()
    {
        if (enemyState != EnemyState.Idle) return;

        SetState(EnemyState.Patrol);
        agent.SetDestination(GetWanderLocation());
    }
    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minPatrolDistance, maxPatrolDistance)), out hit, maxPatrolDistance, NavMesh.AllAreas);
        /* onUnitSphere는 반지름 1인 구. 영역을 범위 NavmeshHit로 가져오기*/

        int i = 0;
        while (Vector3.Distance(transform.position, hit.position) < detectDistance)
        {
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minPatrolDistance, maxPatrolDistance)), out hit, maxPatrolDistance, NavMesh.AllAreas);
            i++;
            if (i == 30) break;
        }
        return hit.position;
    }
    void ChasingUpdate()
    {
        if (playerDistance < findDistance && IsPlayerInFieldOfView())
        {
            animator.speed = 1;
            animator.SetBool("Running", enemyState != EnemyState.Patrol);
            agent.SetDestination(Player.position);
        }
        else
        {
            if (playerDistance < detectDistance)
            {
                agent.isStopped = false;
                NavMeshPath path = new NavMeshPath();
                if (agent.CalculatePath(Player.position, path))
                {
                    agent.SetDestination(Player.position);
                }
                else
                {
                    agent.SetDestination(transform.position);
                    agent.isStopped = true;
                    SetState(EnemyState.Patrol);
                }
            }
            else
            {
                agent.SetDestination(transform.position);
                agent.isStopped = true;
                SetState(EnemyState.Patrol);
                animator.SetBool("Running", enemyState != EnemyState.Patrol);
            }
        }
    }

    bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = Player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < fieldOfView * 0.5f;
    }
}

