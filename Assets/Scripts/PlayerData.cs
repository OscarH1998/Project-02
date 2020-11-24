﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData { 
    public int health;

    public PlayerData (Health player)
    {
        health = player.currentHealth;
    }
}
