using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_collide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        status playerStatus = other.GetComponent<status>();
        if (playerStatus != null)
        {
            playerStatus.addShield();
            Destroy(this.gameObject);
        }

    }
}
