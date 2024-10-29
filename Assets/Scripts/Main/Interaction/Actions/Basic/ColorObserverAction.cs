using UnityEngine;

public class ColorObserverAction : Command
{
    [SerializeField] private string materialToChangeTo;
    public override void Perform() => ColorManager.Instance.ChangeColor(materialToChangeTo);
}
