using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 distancePoint;

    public float swipeThreshold = 50f; // Minimum distance to consider a swipe

    private PlayerBehavior playerBehavior;


    void Start()
    {
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        Debug.Log("PlayerBehavior reference: " + playerBehavior);
    }

    void Update()
    {
#if UNITY_EDITOR
        MouseInput();
#elif UNITY_ANDROID
        TouchInput();
#else
        MouseInput();
#endif
    }

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            distancePoint = endPosition - startPosition;
            HandleSwipe();
        }
    }

    void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:  //Input.GetMouseButtonDown(0)
                    startPosition = touch.position;
                    break;
                case TouchPhase.Ended:  //Input.GetMouseButtonUp(0)
                    endPosition = touch.position;
                    distancePoint = endPosition - startPosition;
                    HandleSwipe();
                    break;
            }
        }
    }

    void TouchHandler()
    {

    }

    private void HandleSwipe()
    {
        // Check if the swipe distance exceeds the threshold using magnitude
        if (distancePoint.magnitude < swipeThreshold)
        {
            return; // Not a valid swipe
        }

        // Determine swipe direction based on the swipeDelta vector
        float x = distancePoint.x;
        float y = distancePoint.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            // Horizontal swipe
            if (x > 0)
                OnSwipeRight();
            else
                OnSwipeLeft();
        }
        else
        {
            // Vertical swipe
            if (y > 0)
                OnSwipeUp();
            else
                OnSwipeDown();
        }
    }

    private void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
        SwipeDirection(ArrowType.RIGHT);
    }

    private void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
        SwipeDirection(ArrowType.LEFT);
    }

    private void OnSwipeUp()
    {
        Debug.Log("Swipe Up");
        SwipeDirection(ArrowType.UP);
    }

    private void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
        SwipeDirection(ArrowType.DOWN);
    }

    private void SwipeDirection(ArrowType swipeDirection)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (enemy.EnemyTypeProperty == EnemyType.GREEN)
            {
                if (swipeDirection == enemy.Type)
                {
                    Destroy(enemy.gameObject);
                    playerBehavior.AddScore(10);
                    Debug.Log("Score added for destroying enemy.");
                    playerBehavior.StartMoving(); 
                }
                else
                {
                    if (playerBehavior != null)
                    {
                        Destroy(playerBehavior.gameObject);
                    }
                }
            }
            else if (enemy.EnemyTypeProperty == EnemyType.RED)
            {
                if (swipeDirection != enemy.Type)
                {
                    Destroy(enemy.gameObject);
                    playerBehavior.AddScore(10);
                    Debug.Log("Score added for destroying enemy.");
                    playerBehavior.StartMoving(); 
                }
                else
                {
                    if (playerBehavior != null)
                    {
                        Destroy(playerBehavior.gameObject);
                    }
                }
            }
        }
    }
}