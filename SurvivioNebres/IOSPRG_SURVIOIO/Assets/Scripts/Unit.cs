using UnityEngine;

public class Unit : MonoBehaviour
{
    protected int maxHealth; // Maximum health of the unit
    protected int currentHealth; // Current health of the unit

 
    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    public int GetMaxHealth()
    {
        return maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        if (currentHealth < 0)
        {
            currentHealth = 0; 
            Die(); 
        }
    }

  
    public bool IsAlive()
    {
        return currentHealth > 0;
    }


    protected virtual void Die()
    {
        
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject); 
    }
}