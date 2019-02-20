using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float timeCounter = 2f;
    private int waveIndex = 0;


    void Update()
    {
        if(timeCounter <= 0f)
        {
            StartCoroutine(SpawnWave());
            timeCounter = timeBetweenWaves;
        }

        timeCounter -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
