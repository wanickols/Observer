using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles all input for the player
/// Will expose actions and a few functions to enable use
/// </summary>
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    ///Actions
    //Observer
    public event Action OnLookStarted;
    public event Action OnLookCanceled;
    public event Action OnZoom;

    //Interactions
    public event Action OnClick;
    public event Action OnBack;
    public event Action OnOpenJournal;


    ///Delegates
    //Observer
    private Action<InputAction.CallbackContext> lookStartedCallback;
    private Action<InputAction.CallbackContext> lookCanceledCallback;
    private Action<InputAction.CallbackContext> zoomCallback;

    //Interactions
    private Action<InputAction.CallbackContext> clickCallback;
    private Action<InputAction.CallbackContext> backCallback;
    private Action<InputAction.CallbackContext> journalCallback;

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

        initializeCallbacks();
    }

    private void OnEnable()
    {
        linkInputsToActions();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        unlinkInputsFromActions();
        inputActions.Disable();
    }

    ///Public Functions
    public Vector2 GetMovementVector() => inputActions.Observer.Movement.ReadValue<Vector2>();

    public Vector2 GetMouseDelta() => inputActions.Observer.Mouse.ReadValue<Vector2>();
    public float GetScrollDelta() => inputActions.Observer.Zoom.ReadValue<float>();


    ///Private Functions
    private void linkInputsToActions()
    {
        //Observer
        var observer = inputActions.Observer;

        observer.Look.performed += lookStartedCallback;
        observer.Look.canceled += lookCanceledCallback;
        observer.Zoom.performed += zoomCallback;

        //Interactor
        var interactor = inputActions.Interactor;

        interactor.Click.performed += clickCallback;
        interactor.Back.performed += backCallback;
        interactor.Journal.performed += journalCallback;
    }

    private void unlinkInputsFromActions()
    {
        //Observer
        var observer = inputActions.Observer;

        observer.Look.performed -= lookStartedCallback;
        observer.Look.canceled -= lookCanceledCallback;
        observer.Zoom.performed -= zoomCallback;

        //Interactor
        var interactor = inputActions.Interactor;

        interactor.Click.performed -= clickCallback;
        interactor.Back.performed -= backCallback;
        interactor.Journal.performed -= journalCallback;
    }


    private void initializeCallbacks()
    {
        lookStartedCallback = ctx => OnLookStarted?.Invoke();
        lookCanceledCallback = ctx => OnLookCanceled?.Invoke();
        zoomCallback = ctx => OnZoom?.Invoke();

        clickCallback = ctx => OnClick?.Invoke();
        backCallback = ctx => OnBack?.Invoke();
        journalCallback = ctx => OnOpenJournal?.Invoke();
    }

}
