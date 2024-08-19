using UnityEngine;

public class TextInteractable : ColorInteractable
{
    [SerializeField] string text;

    protected override void Interact()
    {
        Debug.Log(text);
    }
}
