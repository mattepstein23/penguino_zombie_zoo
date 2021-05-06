using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* public class Grenade : MonoBehaviour
{
    public float delay = 3f; 
    public float blastRadius = 10f; 
    public float force = 700f; 
    float countdown; 
    bool hasExploded  = false;

    public GameObject explosionEffect; 

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay; 
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime; 
        if (countdown <= 0f && hasExploded == false){
            Explode(); 
            hasExploded = true; 
        }
    }

    void Explode(){
        //Show effect 
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Get nearby objects 
            //Add force
            Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
            foreach (Collider nearbyObject  in colliders){
                Rigidbody rb = nearbyObject.GetComponent <Rigidbody>();   
                if (rb != null){
                    rb.AddExplosionForce(force, transform.position, blastRadius); 
                }            
            }

            //Damage 

        // Destroy Grenade
        Destroy(gameObject); 
        Debug.Log("Boom"); 
    }
}

*/