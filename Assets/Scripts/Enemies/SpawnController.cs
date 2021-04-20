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

    private UnityEngine.UI.Text waveLabel;

    private UnityEngine.UI.Text winText;

    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawner");
        waveLabel = GameObject.Find("WaveCounter").GetComponent<UnityEngine.UI.Text>();
        winText = GameObject.Find("WinText").GetComponent<UnityEngine.UI.Text>();
        waveCounter = 0;
        waveLabel.text = (waveCounter + 1).ToString();
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveKills == enemiesPerWave[waveCounter])
        {
            waveCounter++;
            if (waveCounter == enemiesPerWave.Length)
            {
                winText.text = "You have defeated all the zombies with your bare Penguin hands";
            }
            else
            {
                waveLabel.text = (waveCounter + 1).ToString();
                currentWaveKills = 0;
                StartCoroutine(SpawnWave());
            }
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
