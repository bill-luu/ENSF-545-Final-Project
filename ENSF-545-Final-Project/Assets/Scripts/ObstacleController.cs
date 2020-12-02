using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float patrolTime = 10f;
    public Transform[] waypoints;

    private int index;
    private float agentSpeed;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool shouldLog = false;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if(agent != null)
        {
            agentSpeed = agent.speed;
        }

        index = Random.Range(0, waypoints.Length);

        InvokeRepeating("Tick", 0.0f, 2.0f);
        if(waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, patrolTime);
        }
    }

    void Patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }

    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed;
        if(shouldLog)
        {
            Debug.Log(agent.destination);
        }
    }
}
