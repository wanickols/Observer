using UnityEngine;

public class BoxCreatorTrigger : BoxColliderTrigger
{
    [SerializeField] private GameObject target;

    protected override void Interact() => target.SetActive(true);
}
