using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 10;
    //Jed...Calling Nav Mesh
    private NavMeshAgent agent;
    //Jed...The detection Radius
    public float lookRadius = 1f;
    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        //Jed...Moves Enemy to Target
        float distance = Vector3.Distance(target.position, transform.position);

        //Jed...Calls the New Player Manager Script in order to Target the Player
        target = PlayerManager.instance.player.transform;
        //Jed...Calls the NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Jed...Checks if player is in the lookRadius

        if (distance <= lookRadius)
        {
            //Jed...Moves Enemy to Target
            agent.SetDestination(target.position);
        }
        else if(distance > lookRadius)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }


    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    //Jed...The Detection Radius visualised
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
