using UnityEngine;

public class CreateAction : Action
{
    [SerializeField] protected GameObject target;
    public override void Perform()
    {
        if (target == null)
            return;

        target.SetActive(true);
    }
}
