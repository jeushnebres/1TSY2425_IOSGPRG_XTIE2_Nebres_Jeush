using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float playerSpeed = 10; 
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInputValue = InputManager.Instance.GetJoystickInput();
        HandleMovement(playerInputValue);
    }

    private void HandleMovement(Vector2 playerInputValue)
    {

        rigidBody2D.velocity = playerInputValue * playerSpeed * 10 * Time.deltaTime;
    }
}
