using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public MusicSelector musicSelector;

    void Start()
    {

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode loadMode) =>
        {
            SceneManager.SetActiveScene(scene);
            AudioController.GetInstance().SetMusic(musicSelector.selected);

            Scene mainMenu = SceneManager.GetSceneByName("Menu");
            SceneManager.UnloadScene(mainMenu);
        };
    }
}