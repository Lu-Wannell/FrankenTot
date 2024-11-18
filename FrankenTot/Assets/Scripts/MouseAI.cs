using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Code developed using Two videos

// Title: Unity Navmesh AI Tutorial : Flee from Enemy
// Author: Jayanam
// Date: 5 November 2024
// 1.0
// Availability: https://www.youtube.com/watch?v=Zjlg9F3FRJs

// Title: FULL 3D ENEMY AI in 6 MINUTES! || Unity Tutorial
// Author: Dave / GameDevelopment
// Date: 5 November 2024
// 1.0
// Availability: https://www.youtube.com/watch?v=UjkSFoLxesw


public class MouseAI : MonoBehaviour
{
    public NavMeshAgent mouse;

    public GameObject player;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    //Patrolling
    public Vector3 walkPoint;
    [SerializeField]
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
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) 
        { 
            mouse.SetDestination(walkPoint);
           // StartCoroutine(resetWalkPoint());
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
        walkPointSet = true; 
    }


    private void RunningAway()
    {
         float random = Random.Range(1f, 20f);

        if (9f < random && random < 10f)
        {
            Patroling();
        }
        else
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            walkPoint = transform.position + dirToPlayer;

            

            mouse.SetDestination(walkPoint);
            walkPointSet = false;
        }

    }

    private IEnumerator resetWalkPoint()
    {
        yield return new WaitForSecondsRealtime(7f);
        walkPointSet = false;
    }
}
