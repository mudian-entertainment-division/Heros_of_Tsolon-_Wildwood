using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
public class MinionController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    private Transform target;

    //Jed...Calling Nav Mesh
    private NavMeshAgent agent;
    //Jed...The detection Radius
    public float lookRadius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveMinion("RedTeam");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            MoveMinion("BlueTeam");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            MoveMinion("GreenTeam");
        }
        //Jed...Moves Enemy to Target
        float distance = Vector3.Distance(target.position, transform.position);

        //Jed...Calls the New Player Manager Script in order to Target the Player
        target = EnemyManager.instance.enemy.transform;
        //Jed...Calls the NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Jed...Checks if player is in the lookRadius

        if (distance <= lookRadius)
        {
            //Jed...Moves Enemy to Target
            agent.SetDestination(target.position);
        }
    }
    public void MoveMinion(string tag)
    {
        if (gameObject.tag == tag)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }
    }
}