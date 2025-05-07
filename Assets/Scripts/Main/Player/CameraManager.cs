using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{

    ///Actions
    public Action<float> zoomed;

    ///Visible Variables
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Header("Zoom")]
    [SerializeField] private bool zoomEnabled = true;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float maxFieldOfView = 50f;
    [SerializeField] private float minFieldOfView = 20f;

    ///Private 
    private CinemachineBasicMultiChannelPerlin noise;

    private Coroutine shakeCoroutine;
    private Coroutine zoomCoroutine;

    private bool canForceZoom = true;

    private PlayerInputActions inputActions;
    private InputAction zoom;
    private float targetFieldOfView;
    private bool _isForced = false;

    ///Unity Functions
    private void Awake()
    {
        inputActions = new PlayerInputActions();

        zoom = inputActions.Observer.Zoom;
        zoom.performed += Zoom;
        zoom.Enable();

        targetFieldOfView = virtualCamera.m_Lens.FieldOfView;

        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    ///Public Functions
    public void Shake(int intensity, float duration)
    {

        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);

        shakeCoroutine = StartCoroutine(CO_Shake(intensity, duration));
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        if (!zoomEnabled)
            return;

        float zoomVal = zoom.ReadValue<float>();

        if (zoomVal < 0f)
            targetFieldOfView += 5;
        else if (zoomVal > 0f)
            targetFieldOfView -= 5f;

        ZoomToTarget();
    }

    public void ZoomFreeze(float duration) { }

    public void StopZoom() => StopCoroutine(zoomCoroutine);

    public void ForceZoom(float duration, float speed) => StartCoroutine(CO_ForceZoom(duration, speed));

    ///Private Functions
    private IEnumerator CO_Shake(float intensity, float duration)
    {
        noise.m_AmplitudeGain = intensity;

        yield return new WaitForSeconds(duration);

        noise.m_AmplitudeGain = 0f;
    }

    private IEnumerator CO_ForceZoom(float duration = 1f, float speed = 2f)
    {
        float timeElapsed = 0f;
        float startFOV = virtualCamera.m_Lens.FieldOfView;
        float endFOV = Mathf.Clamp(targetFieldOfView, minFieldOfView, maxFieldOfView);

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOV, endFOV, t * speed);
            zoomed?.Invoke(virtualCamera.m_Lens.FieldOfView);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        virtualCamera.m_Lens.FieldOfView = endFOV;
        zoomed?.Invoke(virtualCamera.m_Lens.FieldOfView);
    }



    private void ZoomToTarget()
    {
        targetFieldOfView = Mathf.Clamp(targetFieldOfView, minFieldOfView, maxFieldOfView);

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, targetFieldOfView, Time.deltaTime * zoomSpeed);

        zoomed?.Invoke(virtualCamera.m_Lens.FieldOfView);
    }

    public void SetTargetFieldOfView(float val) => targetFieldOfView = val;
    public void SetZoomEnabled(bool enabled) => zoomEnabled = enabled;
}
