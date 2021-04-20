using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log('1');
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log('2');
            collision.gameObject.GetComponent<EnemyHealth>().Hit(damage);
        }
    }
}
