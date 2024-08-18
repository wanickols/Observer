using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField]
    private float moveSpeed = 20f;

    [SerializeField]
    private float lookSpeed = 100f;

    [SerializeField]
    private Rigidbody rb;

    private PlayerInputActions inputActions;
    private InputAction movement;
    private InputAction mouseMovement;
    private InputAction look;

    private Vector2 rotation = Vector2.zero;


    private bool isLooking = false;

    // Unity Functions
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = inputActions.Observer.Movement;
        movement.Enable();

        mouseMovement = inputActions.Observer.Mouse;
        mouseMovement.Enable();

        inputActions.Observer.Interact.performed += DoInteraction;
        inputActions.Observer.Interact.Enable();

        look = inputActions.Observer.Look;
        look.performed += StartLooking;
        look.canceled += StopLooking;
        look.Enable();
    }


    private void OnDisable()
    {
        movement.Disable();
        mouseMovement.Disable();

        look.performed -= StartLooking;
        look.canceled -= StopLooking;
        look.Disable();

        inputActions.Observer.Interact.performed -= DoInteraction;
        inputActions.Observer.Interact.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (isLooking)
            Look();
    }


    // Actions
    private void Move()
    {
        Vector2 inputDir = movement.ReadValue<Vector2>();

        if (inputDir.magnitude <= 0)
            return;

        // Adjust based on facing position
        Vector3 moveDir = transform.forward * inputDir.y + transform.right * inputDir.x;


        rb.AddForce(moveDir * moveSpeed, ForceMode.Acceleration);
    }

    private void Look()
    {
        Vector2 lookInput = mouseMovement.ReadValue<Vector2>();

        rotation.x += lookInput.x * lookSpeed * Time.deltaTime;
        rotation.y -= lookInput.y * lookSpeed * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0f);
    }

    private void DoInteraction(InputAction.CallbackContext context)
    {
        Debug.Log("Interactin' brother");
    }

    private void StartLooking(InputAction.CallbackContext context) => isLooking = true;
    private void StopLooking(InputAction.CallbackContext context) => isLooking = false;
}
