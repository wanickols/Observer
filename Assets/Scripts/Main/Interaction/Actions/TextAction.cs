using System.Collections.Generic;
using UnityEngine;

public class TextAction : Action
{
    [SerializeField] private List<string> text;

    public override void Perform()
    {
        if (HasInteracted)
        {
            DialogueManager.Instance.DialogueInteract();
            return;
        }

        DialogueManager.Instance.StartMessage(text.ToArray());

        HasInteracted = true;
    }

    public override void Reset()
    {
        base.Reset();
        HasInteracted = false;
    }
}
