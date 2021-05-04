using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_little : MonoBehaviour
{
    [SerializeField] public GameObject little_spider;

    private EnemyHealth health;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0)
        {
            if (spawned == false)
            {
                Instantiate(little_spider, transform.position + transform.forward * 2, transform.rotation);
                Instantiate(little_spider, transform.position - transform.forward * 2, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                Instantiate(little_spider, transform.position + transform.right * 2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                Instantiate(little_spider, transform.position - transform.right * 2, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
                spawned = true;
            }
        }
    }
}
