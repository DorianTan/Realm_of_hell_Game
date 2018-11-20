using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countdown = 1f;                   //temps avant le début de la première wave

    private int waveIndex = 0;
	
	// Update is called once per frame
	void Update ()
	{
	    if (countdown <= 0f)
	    {
	        StartCoroutine(SpawnWave());
	        countdown = timeBetweenWaves;
	    }

	    countdown -= Time.deltaTime;

	    countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

	}

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStat.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);           //temps pendant une wave entre chaque ennemie
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
