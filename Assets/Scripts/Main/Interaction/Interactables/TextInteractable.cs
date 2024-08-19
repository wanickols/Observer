using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : ColorInteractable
{

    [SerializeField] private List<string> text;
    [SerializeField] bool isLooping;

    private int currText = 0;

    protected override void Interact()
    {
        if (HasInteracted)
            return;

        DialogueManager.Instance.DisplayMessage(text[currText]);

        if (++currText >= text.Count)
        {
            if (isLooping)
                currText = 0;
            else
                HasInteracted = true;
        }
    }


}
