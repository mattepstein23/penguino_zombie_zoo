using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour
{
    [SerializeField]
    public int speedUp;

    [SerializeField]
    public int rotSpeed;

    [SerializeField]
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = this.transform.position;
        float newY = Mathf.Sin(Time.time * speedUp);
        currentPos.y = currentPos.y + (newY * height);
        this.transform.position = currentPos;
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
