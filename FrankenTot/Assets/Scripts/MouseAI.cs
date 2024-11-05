using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseAI : MonoBehaviour
{
    public NavMeshAgent mouse;

    public GameObject player;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    //Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    //Running Away
    public float detectionRange;
    public bool playerInDetectionRange;

    private void Start()
    {
        mouse = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, whatIsPlayer);

        if (playerInDetectionRange )
        {
            RunningAway();
        }
        if (!playerInDetectionRange )
        {
            Patroling();
        }
    }

    private void Patroling()
    { 
        if (!walkPointSet) { SearchWalkPoint(); }

        if (walkPointSet)
        {
            mouse.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = mouse.transform.position - walkPoint;

        //WalkPoint reached
        if(distanceToWalkPoint.magnitude < 1f )
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range (-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(mouse.transform.position.x + randomX, mouse.transform.position.y, mouse.transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -mouse.transform.up, 2f, whatIsGround))
        { walkPointSet = true; }
    }


    private void RunningAway()
    {
        Vector3 dirToPlayer = transform.position - player.transform.position;

        Vector3 newPos = transform.position + dirToPlayer;

        mouse.SetDestination(newPos);
        walkPointSet = false;
    }
}
