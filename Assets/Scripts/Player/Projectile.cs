using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 50;
    public GameObject hitEffect;
    private void OnTriggerEnter(Collider collider)
    {
        // Try getting Enemy Component from Collision
        Enemy enemy = collider.GetComponent<Enemy>();
        // If enemy 
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
    }
}
