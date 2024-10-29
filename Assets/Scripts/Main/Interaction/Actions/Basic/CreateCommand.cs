using UnityEngine;

public class CreateCommand : Command
{
    [SerializeField] protected GameObject target;
    public override void Perform()
    {
        if (target == null)
            return;

        target.SetActive(true);
    }
}
