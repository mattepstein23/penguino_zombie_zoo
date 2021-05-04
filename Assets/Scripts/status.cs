using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    private float _health;
    private float _maxHealth;
    private SpawnController spawnController;
    private UnityEngine.UI.Text dieText;
    private int _shield;

    // Start is called before the first frame update
    void Start()
    {
        _health = 5f;
        _maxHealth = 10f;
        _shield = 0;
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        dieText = GameObject.Find("DieText").GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            dieText.text = "You have died, RIP Penguino";
            spawnController.StopGame();
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
