using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthTrack : MonoBehaviour
{
    private Text hb;
    // Start is called before the first frame update
    void Start()
    {
        hb = GetComponent<Text>();
        GameObject player = GameObject.Find("Player");
        float h = player.GetComponent<status>().getHealth();
        float m = player.GetComponent<status>().getMaxHealth();
        string s = "Health: ";
        s += h.ToString();
        s += "/";
        s += m.ToString();
        hb.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        float h = player.GetComponent<status>().getHealth();
        float m = player.GetComponent<status>().getMaxHealth();
        string s = "Health: ";
        s += h.ToString();
        s += "/";
        s += m.ToString();
        hb.text = s;
    }
}
