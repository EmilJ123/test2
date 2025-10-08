using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemypatrol : MonoBehaviour
{
    public Transform[] wayPoints;
    public int targetPoint;

    public float moveSpeed;

    float waitTime;
    [SerializeField] float startWaitTime;
    public bool isWaiting;

    void Start()
    {
        targetPoint= 0;
        waitTime = startWaitTime;
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[targetPoint].position, moveSpeed * Time.deltaTime);

        if (transform.position == wayPoints[targetPoint].position)
        {
            if (waitTime <= 0)
            {
                targetPoint++;
                if(targetPoint >= wayPoints.Length) targetPoint = 0;
                waitTime = startWaitTime;
                isWaiting = false;
            }
            else
            {
                waitTime -= Time.deltaTime;
                isWaiting = true;
            }
        }
            
    }
    
}

