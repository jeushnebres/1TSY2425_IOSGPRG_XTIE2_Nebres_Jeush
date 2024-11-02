using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerInput playerInput;

    private void Awake()
    {
        Instance = this;
        playerInput= new PlayerInput();
    }

    private void Update()
    {
        //Debug.Log(playerInput.TouchControl.Move.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerInput.Enable();

    }


    private void OnDisable()
    {
        playerInput.Disable();
    }

    public Vector2 GetJoystickInput()
    {
        return playerInput.TouchControl.Move.ReadValue<Vector2>();
    }
}
