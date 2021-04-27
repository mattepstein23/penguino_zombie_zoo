﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.Events; 

public class Interactable : MonoBehaviour
{
    public bool isInRange; 
    public KeyCode interactKey; 
    public UnityEvent interactAction; 

    void Update(){
        if(isInRange){
            if (Input.GetKeyDown(interactKey)){
                interactAction.Invoke(); 
            }
        }
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = true; 
            Debug.Log("Player is in range"); 
        }
    }

    private void OnTriggerExit(Collider collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = false; 
            Debug.Log("Player is not in range now"); 
        }
    }

}
