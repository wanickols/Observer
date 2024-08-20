using UnityEngine;

public class BoxSceneTrigger : BoxColliderTrigger
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

