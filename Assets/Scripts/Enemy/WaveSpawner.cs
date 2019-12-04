using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public static int enemiesAlive = 0;

    private int waveNum = 0;

    public void Start()
    {
        //Gives a path for the engine to find the enemy prefab
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
    }
    private void Update()
    {
        //If there are eneimies alive then dont start next wave
        if(enemiesAlive > 0)
        {
            return;
        }
        //If all enemies are dead then start countdown to next wave
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        //Increase the number of enemies in the wave each round
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnEnemy()
    {
        //Spwan enemy at the begining of each round
        GameObject Clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
