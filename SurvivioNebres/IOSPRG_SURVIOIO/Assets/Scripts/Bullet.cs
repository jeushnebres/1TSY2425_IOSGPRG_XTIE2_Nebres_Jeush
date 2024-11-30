using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    public int damage = 10;
    private Transform target; 

    void Update()
    {
        if (target != null)
        {
            // Move the bullet towards the target
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the bullet has reached the target
            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                HitTarget();
            }
        }
        else
        {
            // Destroy the bullet if there is no target
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Set the target for the bullet
    }

    private void HitTarget()
    {
       
        Unit targetUnit = target.GetComponent<Unit>();
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(damage); // Apply damage to the target
        }

        // Destroy the bullet after hitting the target
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Enemy"))
    {
        Unit targetUnit = collision.GetComponent<Unit>(); 
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(damage); // Apply damage to the enemy
        }

        Destroy(gameObject); // Destroy the bullet after hitting the target
    }
        if (collision.gameObject.CompareTag("Player"))
    {
        Unit targetUnit = collision.GetComponent<Unit>(); 
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(damage); // Apply damage to the player
        }

        Destroy(gameObject); // Destroy the bullet after hitting the target
    }
    }
}