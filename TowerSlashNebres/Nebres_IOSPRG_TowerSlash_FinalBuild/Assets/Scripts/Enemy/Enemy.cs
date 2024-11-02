using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ArrowType
{
    RIGHT = 0,
    DOWN = 1,
    LEFT = 2,
    UP = 3,
}

public enum EnemyType
{
    GREEN,
    RED,
    ROTATING,
}

public class Enemy : MonoBehaviour
{
    [SerializeField] public ArrowType type;
    [SerializeField] public EnemyType enemyType;
    [SerializeField] SpriteRenderer arrowObj;
    [SerializeField] Sprite[] arrow;

    [SerializeField] bool isSwipable = false;
    public float speed = 2.0f;
    private PlayerBehavior playerBehavior;

    // Start is called before the first frame update
    void Start()
    {
        // Randomly choose an enemy type (Green or Red)
        enemyType = (EnemyType)Random.Range(0, 2);

        // Randomly choose an arrow direction
        type = (ArrowType)Random.Range(0, 4);

        // Set the initial arrow sprite
        arrowObj.sprite = arrow[(int)type];

        // Set the color of the arrow based on the enemy type
        if (enemyType == EnemyType.GREEN)
        {
            arrowObj.color = Color.green;
        }
        else if (enemyType == EnemyType.RED)
        {
            arrowObj.color = Color.red;
        }

        Debug.Log("Assigned sprite: " + arrow[(int)type].name);
        Debug.Log("Assigned color: " + arrowObj.color);
    }
    

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public ArrowType Type { get { return type; } }
    public EnemyType EnemyTypeProperty { get { return enemyType; } }

    public void CheckSwipe(Vector3 swipeDirection)
    {
        if (enemyType == EnemyType.GREEN)
        {
            // Green Arrow - Swipe in the given direction
            if (swipeDirection == GetDirectionFromArrowType(type))
            {
                Destroy(gameObject);
                
            }
        }
        else if (enemyType == EnemyType.RED)
        {
            // Red Arrow - Swipe in the opposite direction
            if (swipeDirection == -GetDirectionFromArrowType(type))
            {
              
                Destroy(gameObject);
          
            }
        }
    }

    private Vector3 GetDirectionFromArrowType(ArrowType type)
    {
        switch (type)
        {
            case ArrowType.RIGHT:
                return Vector3.right;
            case ArrowType.DOWN:
                return Vector3.down;
            case ArrowType.LEFT:
                return Vector3.left;
            case ArrowType.UP:
                return Vector3.up;
            default:
                return Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player collision (e.g., damage the player)
            // You might want to destroy the enemy here as well
            Destroy(gameObject); // Destroy the enemy
        }
    }
}



