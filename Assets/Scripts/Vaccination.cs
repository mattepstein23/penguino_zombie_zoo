using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccination : MonoBehaviour
{

    private EnemyHealth enemy;

    public bool vaccinating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (vaccinating)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.tag == "Enemy")
            {
                enemy = collision.gameObject.GetComponent<EnemyHealth>();
                enemy.Vaccinate();
            }
        }
    }
}
