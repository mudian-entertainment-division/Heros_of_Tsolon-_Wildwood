using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 150;
    public float detectionRadius = 10f;
    public LayerMask enemyLayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Try getting Enemy Component from Collision
            Enemy enemy = collider.GetComponent<Enemy>();
            // If enemy 
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    Collider GetNearestHit(Collider[] hits)
    {
        float minDistance = float.PositiveInfinity;
        Collider nearest = null;
        foreach (var hit in hits)
        {
            float distance = Vector3.Distance(hit.transform.position, transform.position);
            if (distance < minDistance)
            {
                nearest = hit;
                minDistance = distance;
            }
        }
        return nearest;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
            Collider nearest = GetNearestHit(enemies);
            if (nearest)
            {
                Enemy enemy = nearest.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}
