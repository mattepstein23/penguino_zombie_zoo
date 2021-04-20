using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    GameObject[] spawnLocations;

    [SerializeField] GameObject enemy;

    private int waveCounter;

    [SerializeField] int[] enemiesPerWave = new int[3];

    [SerializeField] string enemyPrefabName;

    private int currentWaveKills;
    
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawner");
        waveCounter = 0;
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveKills == enemiesPerWave[waveCounter])
        {
            waveCounter++;
            currentWaveKills = 0;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        GameObject newEnemy;
        
        for (int j = 0; j < enemiesPerWave[waveCounter]; j++)
        {
            float offset = Random.Range(0f, 2f);
            newEnemy = GameObject.Instantiate(enemy);
            Vector3 spawnLoc = spawnLocations[Random.Range(0,spawnLocations.Length)].transform.position;
            spawnLoc.x += offset;
            spawnLoc.z += offset;
            spawnLoc.y = 1;
            newEnemy.transform.position = spawnLoc;

            yield return new WaitForSeconds(3);
        }
    }

    public void AddKill()
    {
        currentWaveKills++;
    }
}
