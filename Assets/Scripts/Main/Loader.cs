using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public static void LoadSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
        else
            Debug.LogError("Scene name is null or empty.");
    }

    public static void LoadSceneByIndex(Scenes scene)
    {
        int sceneIndex = (int)scene;
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(sceneIndex);
        else
            Debug.LogError("Scene index is out of range.");
    }

    public static void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextSceneIndex);
        else
            Debug.LogError("There is no next scene to load.");
    }

    public static void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0)
            SceneManager.LoadScene(previousSceneIndex);
        else
            Debug.LogError("There is no previous scene to load.");
    }
}

