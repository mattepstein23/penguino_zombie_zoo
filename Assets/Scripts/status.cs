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
    private bool protecting = false;
    private float shield_timer;
    [SerializeField]
    public GameObject shieldBackground;

    private AudioSource audio;

    [SerializeField] public AudioClip hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        _health = 10f;
        _maxHealth = 10f;
        _shield = 0;
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        pauseMenu = GameObject.Find("Tutorial");
        AudioSource[] sources = this.gameObject.GetComponents<AudioSource>();
        for (int i = 0; i < sources.Length; i++)
        {
            if (sources[i].mute)
            {
                audio = sources[i];
                audio.mute = false;
            }
        }
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
        if (_shield <= 0)
        {
            _health -= damage;
            Debug.Log("Health:" + _health);
            audio.clip = hurtSound;
            audio.Play();
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
