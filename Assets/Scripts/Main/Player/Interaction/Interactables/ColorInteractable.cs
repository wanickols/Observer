using UnityEngine;

public abstract class ColorInteractable : MonoBehaviour, IInteractable
{
    ///Mats
    [SerializeField] protected Material hoverMaterial;
    protected Material originalMaterial;

    ///Unity
    protected virtual void Start() => originalMaterial = GetComponent<Renderer>().material;

    ///Interface
    public void OnInteract() => Interact();
    public void OnHoverEnter() => GetComponent<Renderer>().material = hoverMaterial;
    public void OnHoverExit() => GetComponent<Renderer>().material = originalMaterial;

    ///Children
    protected abstract void Interact();
}

