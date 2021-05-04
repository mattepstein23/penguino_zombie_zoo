using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    private GameObject pauseMenu;
    private bool gameStarted;
    private bool toggled;

    // Start is called before the first frame update
    void Start()
    {
        toggled = true;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public bool getStart()
    {
        return gameStarted;
    }

    public void startGame()
    {
        gameStarted = true;
    }

    public bool getToggle()
    {
        return toggled;
    }
    
    public void toggle()
    {
        if (toggled)
        {
            toggled = false;
            this.gameObject.SetActive(false);
        }
        else
        {
            toggled = true;
            this.gameObject.SetActive(true);
        }
    }
}
