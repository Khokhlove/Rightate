using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : Singleton<LevelLoader>
{
    public static void LoadLevel(int levelId)
    {
        GetInstance().StartCoroutine(_LoadLevel(levelId));
    }

    private static IEnumerator _LoadLevel(int levelId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelId, LoadSceneMode.Single);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void LoadLevel()
    {
        SceneManager.sceneLoaded += OnGameLevelLoaded;
        StartCoroutine(_LoadGameLevel());
    }

    IEnumerator _LoadGameLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    void OnGameLevelLoaded(Scene scene, LoadSceneMode loadMode)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(scene);
        AudioController.GetInstance().SetMusic(MusicContainer.GetInstance().selected);
        SceneManager.UnloadScene(currentScene);
        SceneManager.sceneLoaded -= OnGameLevelLoaded;
    }
}