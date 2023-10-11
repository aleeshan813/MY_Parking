using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Vehicles_Engine : MonoBehaviour
{
    [SerializeField] GameObject PATH;
    private int currentWaypointIndex = 0;


    private Transform[] waypoints;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Get all the child transforms of PATH GameObject and store them as waypoints
        waypoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = PATH.transform.GetChild(i);
        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
