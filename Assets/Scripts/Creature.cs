﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    int _currentHealth = 10;
    bool _targeted = false;

    public void Kill()
    {
        Debug.Log("Kill the creature!");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Target()
    {
        Debug.Log("Creature has been targeted.");
        _targeted = true;
    }
}
