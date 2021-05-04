using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vac_spider_spawn : MonoBehaviour
{
    [SerializeField] public GameObject spider_vac;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spider_vac, transform.position + transform.forward * 2, transform.rotation);
        Instantiate(spider_vac, transform.position - transform.forward * 2, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
