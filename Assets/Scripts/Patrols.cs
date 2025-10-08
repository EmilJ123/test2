using UnityEngine;
using UnityEngine.AI;

public class Patrols : MonoBehaviour
{


    public Transform[] patrolPoints;
    private int currentPoint = 0;
    public float speed = 2f;

    void Update()
    {
        Transform target = patrolPoints[currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
    
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    

}