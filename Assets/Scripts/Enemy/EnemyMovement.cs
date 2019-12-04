using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public Waypoints path;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        // Get Random Path
        path = WaypointManager.Instance.GetRandomPath();
        // Get First Point of Path
        target = path.GetFirstPoint();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= path.points.Length - 1)
        {
            WaveSpawner.Instance.EnemiesAlive--;
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = path.points[waypointIndex];
    }
}
