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

    public event Action<int> HealthChanged = delegate { };

    public void TakeDamage(int damage)
    {
  
        currentHealth -= damage;
        HealthChanged.Invoke(currentHealth);
        Debug.Log("Current Health: " + currentHealth);
        //PlayerDamaged.Play();
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(3);
            Debug.Log("Current Health: " + currentHealth);
        }
    }
}
