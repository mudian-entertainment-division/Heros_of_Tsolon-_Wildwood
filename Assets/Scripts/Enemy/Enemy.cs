using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Xml.Serialization;
using System.Xml;

public class EnemyData
{
    [XmlAttribute("Enemy Variables")]
    public int Health;
    public bool Damage;
    [XmlElement("Position")]
    public Vector3 enemyPosition;
}

public class Enemy : MonoBehaviour
{
    public int Health;
    public bool Damage;
    public Vector3 enemyPosition;

    public Text scoreText;

    public GameObject Coins;

    // Update is called once per frame
    private void Update()
    {
        EnemyPos();

        if (Health <= 0)
        {
            Instantiate(Coins, enemyPosition, Quaternion.identity);
            ScoreManager.Instance.AddScore(1, ScoreType.Horde);
            ScoreManager.Instance.AddScore(1, ScoreType.Player);

            WaveSpawner.Instance.EnemiesAlive--;

            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Damage = true;
            Health -= 20;
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
