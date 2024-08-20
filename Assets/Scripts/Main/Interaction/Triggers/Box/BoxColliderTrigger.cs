using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BoxColliderTrigger : MonoBehaviour
{
    [SerializeField] protected bool moreThanOneTrigger = false;

    private void Awake()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) => Interact();

    protected abstract void Interact();
}
