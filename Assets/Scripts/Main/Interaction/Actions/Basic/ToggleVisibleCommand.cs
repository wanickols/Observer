using UnityEngine;

public class ToggleVisibleCommand : Command
{
    [SerializeField] protected MeshRenderer renderer;
    public override void Perform()
    {
        if (renderer == null)
            return;

        renderer.enabled = !renderer.enabled;
    }
}
