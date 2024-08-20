using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool debugOn = false;

    //Input
    private PlayerInputActions inputActions;
    private InputAction clickAction;
    private InputAction backAction;

    private IInteractable currentInteractable;

    /// Unity Functions
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Update()
    {
        HandleHover();
    }

    private void OnEnable()
    {

        clickAction = inputActions.Interactor.Click;
        clickAction.performed += OnClick;
        clickAction.Enable();

        backAction = inputActions.Interactor.Back;
        backAction.performed += OnBack;
        backAction.Enable();
    }

    private void OnDisable()
    {
        clickAction.performed -= OnClick;
        clickAction.Disable();

        backAction.performed -= OnClick;
        backAction.Disable();
    }


    ///Main Interactions
    private void OnClick(InputAction.CallbackContext context)
    {
        AudioManager.Instance.PlaySFX("Click");

        if (debugOn)
            DebugClick();
        else
            NormalClick();
    }


    private void OnBack(InputAction.CallbackContext context)
    {
        DialogueManager.Instance.DialogueInteract();
    }



    private void HandleHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.OnHoverExit();
                    }
                    currentInteractable = interactable;
                    currentInteractable.OnHoverEnter();
                }
            }
            else if (currentInteractable != null)
            {
                currentInteractable.OnHoverExit();
                currentInteractable = null;
            }
        }
        else if (currentInteractable != null)
        {
            currentInteractable.OnHoverExit();
            currentInteractable = null;
        }
    }

    ///Helper Functions
    private void NormalClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
    }
    private void DebugClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f); // 100 units long, lasts for 2 seconds

        if (Physics.Raycast(ray, out hit))
        {
            // Draw a sphere at the hit point for debugging
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 2f); // Draw only up to the hit point
            Debug.DrawLine(ray.origin, hit.point, Color.blue, 2f); // Line from the origin to the hit point
            Debug.Log($"Hit: {hit.collider.name}");

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    }

}
