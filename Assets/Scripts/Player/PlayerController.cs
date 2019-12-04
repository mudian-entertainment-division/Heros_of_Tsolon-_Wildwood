using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //Uses playerMotor script for movement
        motor = GetComponent<PlayerMotor>();
    }

    public Vector3 GetHitPoint()
    {
        //Uses the mouse position to place location for player movement
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Uses right mouse button for player movement.
        if (Input.GetMouseButton(1))
        {
            Vector3 hitPoint = GetHitPoint();
            if (hitPoint.magnitude > 0)
            {
                motor.MoveToPoint(hitPoint);
            }
        }
    }
}
