using UnityEngine;

public class ForceZoomCommand : Command
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private float targetFieldOfView = 20;
    [SerializeField] private float duration = 2.0f;
    [SerializeField] private float speed = 2.0f;


    public override void Perform()
    {
        cameraManager.SetTargetFieldOfView(targetFieldOfView);
        cameraManager.ForceZoom(duration, speed);

    }
}
