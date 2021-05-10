using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    GameObject[] spawnLocations;

    [SerializeField] GameObject enemy;

    [SerializeField] GameObject spider;

    private int waveCounter;

    [SerializeField] int[] enemiesPerWave = new int[3];

    [SerializeField] string enemyPrefabName;

    private int currentWaveKills;

    private UnityEngine.UI.Text waveLabel;

    private UnityEngine.UI.Text winText;

    private UnityEngine.UI.Text newWave;

    private PauseMenu pauseMenu;

    private bool enabled = true;

    private int enemyRequirement;

    private bool gameStarted;

    void Start()
    {
        pauseMenu = GameObject.Find("Tutorial").GetComponent<PauseMenu>();
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawner");
        waveLabel = GameObject.Find("WaveCounter").GetComponent<UnityEngine.UI.Text>();
        winText = GameObject.Find("WinText").GetComponent<UnityEngine.UI.Text>();
        newWave = GameObject.Find("NewWave").GetComponent<UnityEngine.UI.Text>();
    }

    private void delayedStart()
    {
        waveCounter = 0;
        waveLabel.text = (waveCounter + 1).ToString();
        enemyRequirement = enemiesPerWave[waveCounter];
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (pauseMenu.getStart())
            {
                delayedStart();
                gameStarted = true;
            }
        }
        if (enabled)
        {
            if (currentWaveKills >= enemyRequirement)
            {
                waveCounter++;
                if (waveCounter == enemiesPerWave.Length)
                {
                    winText.text = "You have defeated all the zombies. Congrats!";
                }
                else
                {
                    waveLabel.text = (waveCounter + 1).ToString();
                    currentWaveKills = 0;
                    enemyRequirement = enemiesPerWave[waveCounter];
                    StartCoroutine(SpawnWave());
                }
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        GameObject newEnemy;
        newWave.text = "Wave " + (waveCounter + 1).ToString();
        yield return new WaitForSeconds(2);
        newWave.text = "";

        GameObject newSpider = GameObject.Instantiate(spider);
        Vector3 spawnLoc = spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position;
        spawnLoc.y = 1;
        newSpider.transform.position = spawnLoc;

        for (int j = 0; j < enemiesPerWave[waveCounter]; j++)
        {
            float offset = Random.Range(0f, 2f);
            newEnemy = GameObject.Instantiate(enemy);
            Vector3 spawnLoc2 = spawnLocations[Random.Range(0,spawnLocations.Length)].transform.position;
            spawnLoc2.x += offset;
            spawnLoc2.z += offset;
            spawnLoc2.y = 1;
            newEnemy.transform.position = spawnLoc2;

            yield return new WaitForSeconds(3);
        }


    }

    public void AddEnemy()
    {
        enemyRequirement++;
    }

    public void AddKill()
    {
        currentWaveKills++;
    }

    public void StopGame()
    {
        enabled = false;
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] goodList = GameObject.FindGameObjectsWithTag("Good");
        for (int i = 0; i < enemyList.Length; i++)
        {
            Destroy(enemyList[i]);
        }
        for (int i = 0; i < goodList.Length; i++)
        {
            if (goodList[i].name != "Player")
            {
                Destroy(goodList[i]);
            }
        }
    }

    public void SpawnNewEnemy()
    {
        float offset = Random.Range(0f, 2f);
        GameObject newEnemy = GameObject.Instantiate(enemy);
        Vector3 spawnLoc2 = spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position;
        spawnLoc2.x += offset;
        spawnLoc2.z += offset;
        spawnLoc2.y = 1;
        newEnemy.transform.position = spawnLoc2;
    }
}
