using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public Player player; 

    void Start()
    {
        if (player != null)
        {
            UpdateHealthBar(); 
        } // Added closing brace for Start method
    }

    void Update()
    {
        if (player.GetCurrentHealth() <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void UpdateHealthBar() 
    {
        if (player != null) 
        {
            healthBar.fillAmount = player.GetCurrentHealth() / player.GetMaxHealth();
        }
    }
}