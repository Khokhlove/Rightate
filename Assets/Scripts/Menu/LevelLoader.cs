using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public MusicSelector musicSelector;

    public static void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId, LoadSceneMode.Single);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += LoadGameLevel;
    }

    void LoadGameLevel(Scene scene, LoadSceneMode loadMode)
    {
        SceneManager.SetActiveScene(scene);
        AudioController.GetInstance().SetMusic(musicSelector.selected);

        Scene mainMenu = SceneManager.GetSceneByName("Menu");
        SceneManager.UnloadScene(mainMenu);

        SceneManager.sceneLoaded -= LoadGameLevel;
    }
}