using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{

    private UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject.GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
    }
}
