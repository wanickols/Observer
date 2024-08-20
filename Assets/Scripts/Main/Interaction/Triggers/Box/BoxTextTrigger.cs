using System.Collections.Generic;
using UnityEngine;

public class BoxTextTrigger : BoxColliderTrigger
{
    [SerializeField] private List<string> text;

    protected override void Interact()
    {
        DialogueManager.Instance.StartMessage(text.ToArray());

        if (!moreThanOneTrigger)
            GameObject.Destroy(gameObject);
    }
}
