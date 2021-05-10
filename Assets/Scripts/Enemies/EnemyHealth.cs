using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int health;

    [SerializeField] public int scoreOnKill;

    [SerializeField] public GameObject vaxEnemy;

    private SpawnController spawnController;
    private AudioSource hitSoundSource;
    private ScoreTracker scoreTracker;

    [SerializeField] public bool disableWaveEffects = false;

    private bool destroyed = false;

    private void Start()
    {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        scoreTracker = GameObject.Find("ScoreAmount").GetComponent<ScoreTracker>();
        hitSoundSource = this.gameObject.GetComponent<AudioSource>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!destroyed)
            {
                destroyed = true;
                StartCoroutine(DestroyEnemy());
                if (!disableWaveEffects)
                {
                    spawnController.AddKill();
                }
                scoreTracker.addScore(scoreOnKill);
            }
        }
        if (this.gameObject.transform.position.y <= -1000)
        {
            this.spawnController.SpawnNewEnemy();
            Destroy(this.gameObject);
        }
    }

    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public void Hit(int damage)
    {
        health = health - damage;
        hitSoundSource.Play();
    }

    public void Vaccinate()
    {
        if (!disableWaveEffects)
        {
            spawnController.AddKill();
        }
        Vector3 pos = this.gameObject.transform.position;
        Destroy(this.gameObject);
        GameObject vaxxed = Instantiate(vaxEnemy);
        vaxxed.transform.position = pos;
    }

    public void SetHealth(){
        health = 0; 
    }
}
