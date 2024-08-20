using UnityEngine;

public class DestroyerInteractable : ColorInteractable
{
    [SerializeField] private GameObject target;

    protected override void Interact()
    {
        if (target == null)
            return;

        target.SetActive(false);
    }
}

