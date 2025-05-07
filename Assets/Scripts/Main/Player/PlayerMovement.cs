using UnityEngine;

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



    /// Unity Functions
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }
    private void OnEnable()
    {
        InputManager.Instance.OnLookStarted += StartLooking;
        InputManager.Instance.OnLookCanceled += StopLooking;
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
        InputManager.Instance.OnLookStarted -= StartLooking;
        InputManager.Instance.OnLookCanceled -= StopLooking;
    }



    /// Actions
    private void Move()
    {
        Vector2 inputDir = InputManager.Instance.GetMovementVector();

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

        Vector2 lookInput = InputManager.Instance.GetMouseDelta();

        rotation.x += lookInput.x * lookSpeed * Time.deltaTime;
        rotation.y -= lookInput.y * lookSpeed * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0f);
    }


    private void StartLooking() => isLooking = true;
    private void StopLooking() => isLooking = false;
}
