using System;
using UnityEngine;

/// <summary>
/// Handles all input for the player
/// Will expose actions and a few functions to enable use
/// </summary>
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    ///Actions
    //Look
    public event Action OnLookStarted;
    public event Action OnLookCanceled;

    ///Local
    private PlayerInputActions inputActions;


    ///Unity Functions
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Observer.Look.performed += ctx => OnLookStarted?.Invoke();
        inputActions.Observer.Look.canceled += ctx => OnLookCanceled?.Invoke();
    }

    ///Public Functions
    public Vector2 GetMovementVector() => inputActions.Observer.Movement.ReadValue<Vector2>();

    public Vector2 GetMouseDelta() => inputActions.Observer.Mouse.ReadValue<Vector2>();




    ///Private Functions


}
