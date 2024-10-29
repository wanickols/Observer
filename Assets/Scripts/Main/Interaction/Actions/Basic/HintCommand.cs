using UnityEngine;

public class HintCommand : Command
{
    [SerializeField] private string text;
    public override void Perform() => DialogueManager.Instance.DisplayHint(text);
}
