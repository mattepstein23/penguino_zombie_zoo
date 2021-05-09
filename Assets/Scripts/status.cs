using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    private float _health;
    private float _maxHealth;
    private SpawnController spawnController;
    [SerializeField]
    public GameObject dieText;
    private int _shield;
    private GameObject pauseMenu;
    private bool ended = false;

    // Start is called before the first frame update
    void Start()
    {
        _health = 10f;
        _maxHealth = 10f;
        _shield = 0;
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        pauseMenu = GameObject.Find("Tutorial");
    }

    private void Update()
    {
        if (_health <= 0)
        {
            if (ended == false)
            {
                pauseMenu.GetComponent<PauseMenu>().toggle();
                dieText.SetActive(true);
                spawnController.StopGame();
                ended = true;
            }
        }
    }

    // Update is called once per frame
    public float getHealth()
    {
        return _health;
    }

    public void Hurt(float damage)
    {
        if(_shield <= 0)
        {
            _health -= damage;
            Debug.Log("Health:" + _health);
        }
        else
        {
            _shield--;
        }
    }

    public void heal(float healing)
    {
        float h = _health + healing;
        if(h > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health = h;
        }
    }

    public float getMaxHealth()
    {
        return _maxHealth;
    }

    public int getShield()
    {
        return _shield;
    }

    public void addShield()
    {
        _shield++;
    }
}
