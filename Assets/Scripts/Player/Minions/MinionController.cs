using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class MinionController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;


    // Start is called before the first frame update
    void Start()
    {
        //Has sprites always facing camera
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves seperate minions based on their team
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
    }
    public void MoveMinion(string tag)
    {
        //Moves minion teams to mouse postion 
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