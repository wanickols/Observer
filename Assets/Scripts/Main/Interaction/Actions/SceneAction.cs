using UnityEngine;

public class SceneAction : Action
{
    [SerializeField] bool playNext = false;
    [SerializeField] Scenes desiredScene = Scenes.SceneOne;
    public override void Perform()
    {
        if (playNext)
            Loader.LoadNextScene();
        else
            Loader.LoadSceneByIndex(desiredScene);
    }
}
