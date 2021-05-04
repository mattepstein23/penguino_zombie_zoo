using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    public Slider h;
    private int maxHealth;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<Slider>();
        h.maxValue = GetComponentInParent<EnemyHealth>().maxHealth;
        h.value = GetComponentInParent<EnemyHealth>().health;
    }

    // Update is called once per frame
    void Update()
    {
        h.value = GetComponentInParent<EnemyHealth>().health;
    }
}
