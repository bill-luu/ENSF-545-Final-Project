using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform[] waypoints;

    private int index = 0;
    public float agentSpeed = 0.5f;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool shouldLog = false;
    public float stoppingDistance = 2.0f;
    private Vector3 distanceToWaypoint;

    void Start()
    {
        distanceToWaypoint = Vector3.zero;
        GetComponent<Rigidbody>().freezeRotation = true;
    }
    void FixedUpdate ()
    {
        //get the vector from your position to current waypoint
        distanceToWaypoint = waypoints[index].transform.position - transform.position;
        //check our stoppingDistance to the current waypoint, Are we near enough?
        Debug.Log(distanceToWaypoint.magnitude);
        Debug.Log(distanceToWaypoint);
        if(distanceToWaypoint.magnitude < stoppingDistance)
        {
            if(index < waypoints.Length-1) //switch to the nex waypoint if exists
            {
                index++;
            }
            else //begin from new if we are already on the last waypoint
            {
                index = 0;
            }
        }
        Vector3 dir = distanceToWaypoint.normalized * agentSpeed;

        GetComponent<Rigidbody>().MovePosition(transform.position + dir);
    }
}
