using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public Player player; 

    void Start()
    {
        if (player != null)
        {
            UpdateHealthBar(); 
        } 
    }

     void Update()
    {
        if (player.GetCurrentHealth() <= 0)
        {
            SceneManager.LoadScene("GameOver"); 
        }
    }

     public void UpdateHealthBar() 
    {
        if (player != null) 
        {
            float healthPercentage = (float)player.GetCurrentHealth() / player.GetMaxHealth(); // Calculate health percentage
            healthBar.fillAmount = healthPercentage; // Update health bar fill amount

            // Change color based on health percentage
            healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        }
    }
}