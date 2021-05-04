using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_timer : MonoBehaviour
{
    public float lifeTime;
    public float remainTime;
    // Start is called before the first frame update
    void Start()
    {
        remainTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainTime -= Time.deltaTime;
        if(remainTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
