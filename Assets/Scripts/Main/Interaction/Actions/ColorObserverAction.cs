using UnityEngine;

public class ColorObserverAction : Action
{
    [SerializeField] private string materialToChangeTo;
    public override void Perform() => ColorManager.Instance.ChangeColor(materialToChangeTo);
}
