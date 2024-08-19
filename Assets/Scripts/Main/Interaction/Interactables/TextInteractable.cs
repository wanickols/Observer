using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : ColorInteractable
{

    [SerializeField] private List<string> text;

    protected override void Interact()
    {
        if (HasInteracted)
        {
            DialogueManager.Instance.DialogueInteract();
            return;
        }

        DialogueManager.Instance.StartMessage(text.ToArray());

        HasInteracted = true;
    }


}
