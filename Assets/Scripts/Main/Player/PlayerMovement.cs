using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    ///Visible Variables

    [Header("Options")]
    [SerializeField] private bool xMovementEnabled = true;
    [SerializeField] private bool yMovementEnabled = true;
    [SerializeField] private bool camerMovementEnabled = true;

    [Header("Movement and Camera")]
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float lookSpeed = 100f;

    [Header("Player")]


    ///Private
    private Rigidbody rb;

    //Trackers
    private Vector2 rotation = Vector2.zero;


    private bool isLooking = false;

    //Input Management
    private PlayerInputActions inputActions;
    private InputAction movement;
    private InputAction mouseMovement;
    private InputAction look;


    /// Unity Functions
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();

    }
    private void OnEnable()
    {
        movement = inputActions.Observer.Movement;
        movement.Enable();

        mouseMovement = inputActions.Observer.Mouse;
        mouseMovement.Enable();

        look = inputActions.Observer.Look;
        look.performed += StartLooking;
        look.canceled += StopLooking;
        look.Enable();
    }

    private void Update()
    {
        if (isLooking)
            Look();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        movement.Disable();
        mouseMovement.Disable();

        look.performed -= StartLooking;
        look.canceled -= StopLooking;
        look.Disable();
    }


    /// Actions
    private void Move()
    {
        Vector2 inputDir = movement.ReadValue<Vector2>();

        if (inputDir.magnitude <= 0) return;
        if (!yMovementEnabled) inputDir.y = 0;
        if (!xMovementEnabled) inputDir.x = 0;

        // Adjust based on facing position
        Vector3 moveDir = transform.forward * inputDir.y + transform.right * inputDir.x;


        rb.AddForce(moveDir * moveSpeed, ForceMode.Acceleration);
    }

    private void Look()
    {
        if (!camerMovementEnabled)
            return;

        Vector2 lookInput = mouseMovement.ReadValue<Vector2>();

        rotation.x += lookInput.x * lookSpeed * Time.deltaTime;
        rotation.y -= lookInput.y * lookSpeed * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0f);
    }


    private void StartLooking(InputAction.CallbackContext context) => isLooking = true;
    private void StopLooking(InputAction.CallbackContext context) => isLooking = false;
}
