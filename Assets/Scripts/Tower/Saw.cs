using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform target;

    [Header("Tower Setup")]

    public string enemyTag = "Enemy";

    public int damage = 150;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            // Gets the Enemy component
            Enemy enemy = other.GetComponent<Enemy>();
           if (enemy)
           {
                // Enmey takes damage from the enemy script
                enemy.TakeDamage(damage);
           }
        }
    }
}
