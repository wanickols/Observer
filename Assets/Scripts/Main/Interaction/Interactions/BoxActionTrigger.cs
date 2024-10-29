using System.Collections.Generic;
using UnityEngine;

public class BoxActionTrigger : MonoBehaviour
{
    [SerializeField] protected bool moreThanOneTrigger = false;
    [SerializeField] protected List<Action> actions;

    /// Unity
    private void Awake()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) => Interact();


    ///Children
    protected void Interact()
    {
        foreach (var action in actions)
            action.Perform();


        if (!moreThanOneTrigger)
            Destroy(gameObject);
    }
}
