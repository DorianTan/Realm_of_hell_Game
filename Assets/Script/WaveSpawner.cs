using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    private float countdown = 1f;                   //temps avant le début de la première wave
    private int waveIndex = 0;

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public GameObject winGameUI;

    // Update is called once per frame
    void Update ()
	{
	    if (countdown <= 0f)
	    {
	        StartCoroutine(SpawnWave());
	        countdown = timeBetweenWaves;
	        return;
	    }
	    countdown -= Time.deltaTime;
	    countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
	}

    IEnumerator SpawnWave()
    {       
        PlayerStat.Money += waveIndex * 10 + 15;
        PlayerStat.Rounds++;
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);           //temps pendant une wave entre chaque ennemie
        }
    }
    void WinGame()
    {
        winGameUI.SetActive(true);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
