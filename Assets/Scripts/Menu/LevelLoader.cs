using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : Singleton<LevelLoader>
{
    public static void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId, LoadSceneMode.Single);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnGameLevelLoaded;
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