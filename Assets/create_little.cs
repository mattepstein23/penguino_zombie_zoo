using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_little : MonoBehaviour
{
    public GameObject little_spider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            Instantiate(little_spider, transform.position + transform.forward*2, transform.rotation);
            Instantiate(little_spider, transform.position - transform.forward * 2, transform.rotation*Quaternion.Euler(0f,180f,0f));
            Instantiate(little_spider, transform.position + transform.right * 2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
            Instantiate(little_spider, transform.position - transform.right * 2, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
        }
    }
}
