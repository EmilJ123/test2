using UnityEngine;
using UnityEngine.AI;

public class Patrols : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
    
}
