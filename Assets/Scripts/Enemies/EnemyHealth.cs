using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health;

    private SpawnController spawnController;

    private void Start()
    {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            spawnController.AddKill();
        }
    }

    public void Hit(int damage)
    {
        health = health - damage;
    }
}
