using UnityEngine;

public class CameraShakeCommand : Command
{

    [SerializeField] private int intensity;
    [SerializeField] private float duration;
    [SerializeField] private CameraManager _cameraManager;
    public override void Perform() => _cameraManager.Shake(intensity, duration);
}
