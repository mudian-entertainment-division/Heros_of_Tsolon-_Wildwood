using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class MinionController : MonoBehaviour
{
    public LayerMask movementMask;

    public int health = 100;
    public int damage = 10;
    public bool Damage = false;

    public Transform EnemyPos;

    Camera cam;
    PlayerMotor motor;


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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            print("working ");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
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