using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shieldB : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image =GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.3f;
        image.color = tempColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
