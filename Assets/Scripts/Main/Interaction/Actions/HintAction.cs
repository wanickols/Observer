using UnityEngine;

public class HintAction : Action
{
    [SerializeField] private string text;
    public override void Perform() => DialogueManager.Instance.DisplayHint(text);
}
