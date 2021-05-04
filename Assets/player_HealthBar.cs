using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HealthBar : MonoBehaviour
{
    public Slider h;
    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<Slider>();
        GameObject player = GameObject.Find("Player");
        float health = player.GetComponent<status>().getHealth();
        float max = player.GetComponent<status>().getMaxHealth();
        h.maxValue = max;
        h.value = health;
    }
        // Update is called once per frame
        void Update()
        {
        h = GetComponent<Slider>();
        GameObject player = GameObject.Find("Player");
        float health = player.GetComponent<status>().getHealth();
        float max = player.GetComponent<status>().getMaxHealth();
        h.maxValue = max;
        h.value = health;
    }
    }

