using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_vac : MonoBehaviour
{
    private float _health;
    private float _maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        _health = 5f;
        _maxHealth = 5f;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    public float getHealth()
    {
        return _health;
    }

    public void Hurt(float damage)
    {
        _health -= damage;
        Debug.Log("Health:" + _health);
    }

    public void heal(float healing)
    {
        float h = _health + healing;
        if (h > _maxHealth)
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
}

