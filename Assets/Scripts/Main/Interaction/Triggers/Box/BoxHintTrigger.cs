using UnityEngine;

public class BoxHintTrigger : BoxColliderTrigger
{
    [SerializeField] private string text;

    protected override void Interact()
    {
        DialogueManager.Instance.DisplayHint(text);

        if (!moreThanOneTrigger)
            GameObject.Destroy(gameObject);
    }
}
