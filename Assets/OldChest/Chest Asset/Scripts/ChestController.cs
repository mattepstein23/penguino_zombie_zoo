using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private bool alreadyOpened = false; 
    int random; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Open() {
        alreadyOpened = true;
        random = Random.Range(0,3); 
        this.GetComponent<Animation>().Play("ChestAnim");
        Debug.Log("I'm Opening"); 

        if(random == 0){
            Debug.Log("Vaccine Added"); 
        }

        if(random == 1){
            Debug.Log("Ability One activated"); 
        }
        if(random == 2){
            Debug.Log("Ability Two activated"); 
        }
    }
}
