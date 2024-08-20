using UnityEngine;

public class SceneShiftInteractable : ColorInteractable
{
    [SerializeField] bool playNext = false;
    [SerializeField] Scenes desiredScene = Scenes.SceneOne;
    protected override void Interact()
    {
        if (playNext)
            Loader.LoadNextScene();
        else
            Loader.LoadSceneByIndex(desiredScene);
    }
}
