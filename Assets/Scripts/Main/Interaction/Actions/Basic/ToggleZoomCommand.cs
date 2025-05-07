using UnityEngine;

public class ToggleZoomCommand : Command
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private bool enableZoom = false;

    public override void Perform()
    {
        cameraManager.SetZoomEnabled(enableZoom);
    }

    public override void Undo()
    {
        cameraManager.SetZoomEnabled(!enableZoom);
    }
}
