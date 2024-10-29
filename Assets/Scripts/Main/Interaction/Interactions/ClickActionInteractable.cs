using System.Collections.Generic;
using UnityEngine;

public class ClickActionInteractable : MonoBehaviour, IInteractable
{

    //Actions
    [SerializeField] protected List<Action> actions;

    //Mats
    [SerializeField] protected Material hoverMaterial;
    protected Material originalMaterial;

    ///Unity
    protected virtual void Start() => originalMaterial = GetComponent<Renderer>().material;

    ///Interface
    public void OnInteract() => Interact();
    public void OnReset() => ResetInteractable();
    public void OnHoverEnter() => GetComponent<Renderer>().material = hoverMaterial;
    public void OnHoverExit() => GetComponent<Renderer>().material = originalMaterial;

    ///Children
    protected void Interact()
    {
        foreach (var action in actions)
            action.Perform();
    }

    protected virtual void ResetInteractable()
    {
        foreach (var action in actions)
            action.Reset();
    }




}
