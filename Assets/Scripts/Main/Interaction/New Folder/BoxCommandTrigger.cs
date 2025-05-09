using System.Collections.Generic;
using UnityEngine;

public class BoxCommandTrigger : MonoBehaviour
{
    [SerializeField] protected bool moreThanOneTrigger = false;
    [SerializeField] protected List<Command> actions;

    /// Unity
    private void Awake()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) => Interact();

    private void OnTriggerExit(Collider other) => ReverseInteract();

    ///Children
    virtual protected void Interact()
    {
        foreach (var action in actions)
            action.Perform();


        if (!moreThanOneTrigger)
            Destroy(gameObject);
    }

    virtual protected void ReverseInteract()
    {
        foreach (var action in actions)
            action.Undo();
    }
}
