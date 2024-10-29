using UnityEngine;

public class DestroyAction : Action
{
    [SerializeField] protected GameObject target;
    public override void Perform()
    {
        if (target == null)
            return;

        target.SetActive(false);
    }
}
