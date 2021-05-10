using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medKit : MonoBehaviour
{

    private AudioSource source;

    [SerializeField] public AudioClip pickupSound;

    private bool pickedUp = false;

    private void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        source.clip = pickupSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            status playerStatus = other.GetComponent<status>();
            if (playerStatus != null)
            {
                playerStatus.heal(2f);
                source.Play();
                StartCoroutine(DestroyBox());
            }
        }

    }

    private IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
