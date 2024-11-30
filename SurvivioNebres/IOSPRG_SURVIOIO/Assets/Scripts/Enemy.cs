using UnityEngine;

public class Enemy : Unit
{
    void Start()
    {
        maxHealth = 100; // Set maximum health for the enemy
        currentHealth = maxHealth; // Initialize current health
    }
}
