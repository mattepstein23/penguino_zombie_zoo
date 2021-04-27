using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    private bool assetsMenuEnabled = false;

    private GameObject assetsMenu;
    private GameObject mainMenu;

    private void Start()
    {
        assetsMenu = GameObject.Find("AssetsMenu");
        mainMenu = GameObject.Find("Main");
        assetsMenu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void toggleAssetsMenu()
    {
        if (assetsMenuEnabled == false)
        {
            mainMenu.SetActive(false);
            assetsMenu.SetActive(true);
            assetsMenuEnabled = true;
        }
        else
        {
            mainMenu.SetActive(true);
            assetsMenu.SetActive(false);
            assetsMenuEnabled = false;
        }
    }
}
