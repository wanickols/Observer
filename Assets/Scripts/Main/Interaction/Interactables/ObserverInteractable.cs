using UnityEngine;

public class ObserverInteractable : ColorInteractable
{



    [SerializeField] private string materialToChangeTo;

    protected override void Interact()
    {
        ColorManager.Instance.ChangeColor(materialToChangeTo);
    }
}
