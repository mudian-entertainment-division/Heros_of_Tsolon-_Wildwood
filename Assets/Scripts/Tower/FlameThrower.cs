using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Tower
{
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public float range = 15f;
    public Transform partToRotate;
    public float turnSpeed = 8;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        // Uses the UpdateTarget function repeatively
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // enemeies finds enemyTag
        GameObject[] enemeies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Finds the closest enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemeies)
        {
            // Uses the range of the object to find and rotate to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        // Finds and targets the nearest enemy transform
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        // Makes fireCountdown uses ingame seconds
        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        // Clones the bullet prefab at a certain point
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Gets the BulletGO component
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            // Bullet targets target
            bullet.Seek(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
