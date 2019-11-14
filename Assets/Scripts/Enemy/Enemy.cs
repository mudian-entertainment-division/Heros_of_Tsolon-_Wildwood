using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Health;
    public bool Damage;
    public Vector3 enemyPosition;

    public GameObject scoreText;
    public int Score;

    public GameObject Coins;

    

    // Update is called once per frame
    private void Update()
    {
        EnemyPos();

        if (Health <= 0)
        {
            Instantiate(Coins, enemyPosition, Quaternion.identity);
            ScoreManager.hordeScore += 1;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Damage = true;
            Health -= 55;
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public void EnemyPos()
    {
        enemyPosition = transform.position;
    }

  
}
