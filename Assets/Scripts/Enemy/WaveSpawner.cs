using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    #region Singleton
    public static WaveSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int enemiesAlive = 0;
    public int EnemiesAlive
    {
        get
        {
            return enemiesAlive;
        }
        set
        {
            enemiesAlive = value;
        }
    }

    private int waveNum = 0;

    public void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
    }
    private void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

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
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnEnemy()
    {
        GameObject Clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
