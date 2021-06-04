using System.Collections;
using UnityEngine;

public class WarmupController : MonoBehaviour
{
    public GameObject warmupUI;
    public GameObject gameUI;
    // public AudioController audioController;
    public bool warmup = true;

    static WarmupController instance;

    public static WarmupController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }
    public void StartGame()
    {
        warmupUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        Counter.GetInstance().SetScore(0);
        AudioController audioController = AudioController.GetInstance();
        audioController.SetTrackPos(audioController.backgroundMusic.warmupTime);
        warmup = false;
    }
}