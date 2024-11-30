using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
    currentHealth -= damage;
    Debug.Log($"{gameObject.name} took {damage} damage! Current health: {currentHealth}");
    
    HealthManager healthManager = FindObjectOfType<HealthManager>();
    if (healthManager != null)
    {
        healthManager.UpdateHealthBar(); 
    }

    if (currentHealth <= 0)
    {
        Die(); 
    }
    }

    
    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        
        Destroy(gameObject); 
    }
}