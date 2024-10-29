using UnityEngine;

public class DestroyCommand : Command
{
    [SerializeField] protected GameObject target;
    public override void Perform()
    {
        if (target == null)
            return;

        target.SetActive(false);
    }
}
