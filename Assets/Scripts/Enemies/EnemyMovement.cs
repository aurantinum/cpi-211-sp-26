using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    enum MovementTypes
    {
        Chase, 
        Patrol,
        Wander
    }
    MovementTypes CurrentMovementType
    {
        get
        { return c_movement; }
        set
        {

            c_movement = value;
            switch (CurrentMovementType)
            {
                case MovementTypes.Chase: StartCoroutine(nameof(FindPlayer)); break;
                case MovementTypes.Patrol: StartCoroutine(nameof(Patrol)); break;

            }
        }
    }
    MovementTypes c_movement;

    GameObject target;
    [SerializeField] GameObject player;
    NavMeshAgent agent;
    float refreshTargetRate = 0.3f;
    Vector3 patrolStartPosition, patrolEndPosition;
    [SerializeField]
    float modelOriginOffsetY = 1;
    [SerializeField]
    Transform lineOfSight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(nameof(FindPlayer));
        CurrentMovementType = MovementTypes.Patrol;
        patrolStartPosition = transform.position;
        Physics.Raycast(transform.position + (Vector3.forward * 10) + (Vector3.up * 1000), Vector3.down, out var hit);
        patrolEndPosition = hit.point;
        StartCoroutine(nameof(Patrol));
    }
    
    void Update()
    {
        if(Physics.Raycast(lineOfSight.position, transform.forward,out var hit, 5))
        {
            if(hit.collider.tag == "Player" && CurrentMovementType == MovementTypes.Patrol)
            {
                CurrentMovementType = MovementTypes.Chase;
                StartCoroutine(nameof(FindPlayer));
            }
        }
    }
    
    IEnumerator Patrol()
    {
        //Tell agent to go to the end position
        agent.SetDestination(patrolEndPosition);
        //wait until we near the end position
        while (Vector3.Distance(agent.transform.position, patrolEndPosition) > (0.5f + modelOriginOffsetY))
        {
            yield return null;
            if (CurrentMovementType != MovementTypes.Patrol) //if we ever change our movement type, leave this coroutine
            {
                yield break;
            }
        }

        //look around at the end point
        float amountTurned = 0;
        while(amountTurned < 90)
        {
            transform.Rotate(Vector3.up, 1);
            amountTurned += 1;
            yield return null;
            if (CurrentMovementType != MovementTypes.Patrol) //if we ever change our movement type, leave this coroutine
            {
                yield break;
            }
        }
        while(amountTurned > -90)
        {
            transform.Rotate(Vector3.up, -1);
            amountTurned -= 1;
            yield return null;
            if (CurrentMovementType != MovementTypes.Patrol) //if we ever change our movement type, leave this coroutine
            {
                yield break;
            }
        }
        //successfully reached the end, switch the start and end patrol points
        Vector3 tmp = patrolStartPosition;
        patrolStartPosition = patrolEndPosition;
        patrolEndPosition = tmp;
        StartCoroutine(nameof(Patrol));
        yield return null;
    }

    IEnumerator FindPlayer()
    {
        while (true)
        {
            agent.SetDestination(player.transform.position);
            yield return new WaitForSeconds(refreshTargetRate);
        }
    }
}
