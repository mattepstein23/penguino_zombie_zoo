using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    GameObject[] spawnLocations;

    [SerializeField] GameObject enemy;

    [SerializeField] int waves = 3;
    private int waveCounter;

    [SerializeField] int enemiesPerSpawner = 3;

    
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawner");
        waveCounter = 1;
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnWave()
    {
        GameObject newEnemy;
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            for (int j = 0; j < enemiesPerSpawner; j++)
            {
                float offset = Random.Range(0, 2);
                newEnemy = GameObject.Instantiate(enemy);
                Vector3 spawnLoc = spawnLocations[i].transform.position;
                spawnLoc.x += offset;
                spawnLoc.z += offset;
                spawnLoc.y = 1;
                newEnemy.transform.position = spawnLoc;

                yield return new WaitForSeconds(2);
            }
        }
    }
}
