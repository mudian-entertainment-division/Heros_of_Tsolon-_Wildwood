using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotateToCamera : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    private void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        if (agent)
        {
            agent.updateRotation = false;
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
