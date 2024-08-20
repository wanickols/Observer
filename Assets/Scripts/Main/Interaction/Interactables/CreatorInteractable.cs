using UnityEngine;

public class CreatorInteractable : ColorInteractable
{
    [SerializeField] private GameObject target;
    protected override void Interact() => target.SetActive(true);
}
