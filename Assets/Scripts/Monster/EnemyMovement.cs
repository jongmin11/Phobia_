using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
	[Header("Prtrol Points")]
	public Transform[] patrolPoints;
	private int currentPatrolIndex = -1;
	
	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	public void MoveToPatrolPoint(float speed)
	{
        if (patrolPoints == null)
        {
            return; // 예외처리
        }

		agent.speed = speed;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, patrolPoints.Length);
            }

            while (newIndex == currentPatrolIndex && patrolPoints.Length > 1);

            currentPatrolIndex = newIndex;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
		}
	}
	public void ChasePlayer(Transform player, float speed)
	{
		agent.speed = speed;
		agent.SetDestination(player.position);
	}
}
