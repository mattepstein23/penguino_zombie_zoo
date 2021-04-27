using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health;

    [SerializeField] public int scoreOnKill;

    [SerializeField] public GameObject vaxEnemy;

    private SpawnController spawnController;
    private AudioSource hitSoundSource;
    private ScoreTracker scoreTracker;

    private void Start()
    {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        scoreTracker = GameObject.Find("ScoreValue").GetComponent<ScoreTracker>();
        hitSoundSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            spawnController.AddKill();
            scoreTracker.addScore(scoreOnKill);
        }
    }

    public void Hit(int damage)
    {
        health = health - damage;
        hitSoundSource.Play();
    }

    public void Vaccinate()
    {
        spawnController.AddKill();
        Vector3 pos = this.gameObject.transform.position;
        Destroy(this.gameObject);
        GameObject vaxxed = Instantiate(vaxEnemy);
        vaxxed.transform.position = pos;
    }
}
