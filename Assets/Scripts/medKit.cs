using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        status playerStatus = other.GetComponent<status>();
        if(playerStatus != null)
        {
            playerStatus.heal(2f);
            Destroy(this.gameObject);
        }

    }
}
