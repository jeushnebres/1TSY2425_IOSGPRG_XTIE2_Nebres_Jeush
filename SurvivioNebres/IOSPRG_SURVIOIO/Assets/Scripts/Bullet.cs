using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public int damage = 20; // Damage dealt by the bullet
    private Transform target; // The target the bullet will move towards

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
        // Handle hitting the target (e.g., apply damage)
        Unit targetUnit = target.GetComponent<Unit>(); // Assuming the target has a Unit component
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(damage); // Apply damage to the target
        }

        // Destroy the bullet after hitting the target
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with players or enemies
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            // If the bullet hits a player or enemy, apply damage
            Unit targetUnit = collision.GetComponent<Unit>(); // Assuming both Player and Enemy have a Unit component
            if (targetUnit != null)
            {
                targetUnit.TakeDamage(damage); // Apply damage to the target
            }

            // Destroy the bullet after hitting the target
            Destroy(gameObject);
        }
    }
}