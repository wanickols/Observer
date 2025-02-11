using UnityEngine;

public class ForceZoomCommand : Command
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private float targetFieldOfView = 20;


    public override void Perform()
    {
        cameraManager.SetTargetFieldOfView(targetFieldOfView);
        cameraManager.ZoomToTarget();
    }
}
