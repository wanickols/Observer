using UnityEngine;

public class BoxDestroyerTrigger : BoxColliderTrigger
{
    [SerializeField] private GameObject target;

    protected override void Interact()
    {
        if (target == null)
            return;

        target.SetActive(false);
    }
}

