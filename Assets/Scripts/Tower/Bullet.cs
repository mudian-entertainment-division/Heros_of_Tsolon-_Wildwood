using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 150;
    public void Seek(Transform _target)
    {
        // Bullet finds the targets position
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        // if there is no target.. nothing happens
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Gets the excat position for the bullet toc spawn
        Vector3 dir = target.position - transform.position;
        // Measures the speed for the bullet to travel
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Gets the Enemy component
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy)
        {
            // Enmey takes damage from the enemy script
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}