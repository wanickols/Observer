using System.Collections.Generic;
using UnityEngine;

public class ZoomFCommandTrigger : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private List<FCommand> fCommands;

    private bool canZoom = false;

    private void Awake()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        cameraManager.zoomed += onZoomed;
    }
    private void onZoomed(float val)
    {
        if (!canZoom)
            return;

        foreach (var fCommand in fCommands)
            fCommand.checkVal(val);
    }

    private void OnTriggerEnter() => canZoom = true;
    private void OnTriggerExit() => canZoom = false;
    private void OnDestroy() => cameraManager.zoomed -= onZoomed;

}
