using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    public MusicSelector musicSelector;
    static LevelLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static LevelLoader GetInstance()
    {
        return instance;
    }

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