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
        // Gets the Main camera component
        cam = Camera.main;
        // Gets the NazMesh component
        agent = GetComponent<NavMeshAgent>();
        if (agent)
        {
            // Gets rid of its starting rotaion
            agent.updateRotation = false;
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        // Transform of the object always looks at the camera
        transform.LookAt(cam.transform);
    }
}
