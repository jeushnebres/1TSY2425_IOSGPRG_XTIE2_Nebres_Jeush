using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public Player player;
    public float speed = 2f;
    public float raycastDistance = 3f;

    private bool isStopped = false;
    public int currentScore = 0;
    public ScoreDisplay scoreDisplay;


    private void Start()
    {
        player = GetComponent<Player>();
      
    }

    private void Update()
    {
        // Move the player up
        if (!isStopped)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        // Check if there is an enemy in front of the player
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.2f, LayerMask.GetMask("Enemies"));

        if (hits.Length > 0)
        {
            // Stop the player
            isStopped = true;

            // Get the enemy script
            Enemy enemy = hits[0].gameObject.GetComponent<Enemy>();

            // Get the arrow direction and color
            ArrowType arrowDirection = enemy.Type;
            EnemyType enemyColor = enemy.EnemyTypeProperty;

            Destroy(enemy.gameObject); // Destroy the enemy
            ScoreIncrease();

        }
    }


    public Enemy GetCurrentTarget()
    {
        // Create a raycast from the player's position
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.up;

        // Cast the ray
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);

        // Log the raycast result
        Debug.Log("Raycast result: " + hit.collider);

        // Check if the ray hit an enemy
        if (hit.collider != null)
        {
            // Get the enemy script
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            // Log the enemy
            Debug.Log("Enemy found: " + enemy);

            // Return the enemy
            return enemy;
        }

        // Return null if no enemy was found
        return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Stop the player
            isStopped = true;

            // Get the enemy script
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // Get the arrow direction and color
            ArrowType arrowDirection = enemy.Type;
            EnemyType enemyColor = enemy.EnemyTypeProperty;

            player.TakeDamage(50, collision.gameObject);
   
        }
    }
    private void ScoreIncrease()
    {
        currentScore += 1; // Increase the score
        Debug.Log("Current Score: " + currentScore); // Log the current score
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score updated: " + currentScore); // Confirm score update
    }

    public void StartMoving()
    {
        isStopped = false;
    }
}
