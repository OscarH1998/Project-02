using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth { get; private set; } = 20;
    public int currentHealth { get; private set; } = 20;

    [SerializeField] AudioSource PlayerDamaged = null;



    public GameObject GameOverScreen = null;
    public GameObject Button1 = null;
    public GameObject Button2 = null;
    public GameObject GameOverBlock = null;

    public event Action<int> HealthChanged = delegate { };

    public void Awake()
    {
        GameOverScreen.SetActive(false);
        GameOverBlock.SetActive(false);
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        HealthChanged.Invoke(currentHealth);
        Debug.Log("Current Health: " + currentHealth);
        PlayerDamaged.Play();
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentHealth = data.health;
        HealthChanged.Invoke(currentHealth);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    { 
        GameOverScreen.SetActive(true);
        GameOverBlock.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
    } 
}
