using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject magicPrefab;

    public float magicForce = 20f;
    public float expireTime = 1f;

    public PlayerController player;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 direction = player.GetHitPoint() - transform.position;
            direction.y = 0f;
            Shoot(direction);
        }  
    }
    void Shoot(Vector3 direction)
    {
        GameObject disintigration = Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = disintigration.GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * magicForce, ForceMode.Impulse);
    }
    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
