using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameDebug : MonoBehaviour
{
    public bool enableOnStart = false;
    public int counter = 0;
    public int debugerOpenThreshold = 10;

    public GameObject background;

    public Button backgroundButton;
    public Button postProcessing;
    public Button fpsCounterButton;

    public Material startBackground;
    public Material targetBackground;

    Text backText;
    Text postProcessingText;
    Volume volume;

    void Start()
    {
        gameObject.SetActive(enableOnStart);

        //Background
        backText = backgroundButton.GetComponentInChildren<Text>();
        backText.text = $"Background: {background.activeSelf}";
        backgroundButton.onClick.AddListener(() =>
        {
            background.SetActive(background.activeSelf ? false : true);
            backText.text = $"Background: {background.activeSelf}";
        });

        //PostProcessing
        volume = Camera.main.GetComponent<Volume>();
        postProcessingText = postProcessing.GetComponentInChildren<Text>();
        postProcessingText.text = $"PP: {volume.enabled}";

        postProcessing.onClick.AddListener(() =>
        {
            volume.enabled = volume.enabled ? false : true;
            postProcessing.GetComponentInChildren<Text>().text = $"PP: {volume.enabled}";
        });

        //FPSCounter
        fpsCounterButton.onClick.AddListener(() =>
        {
            FPSCounterUI fpsCounterUI = FPSCounter.GetInstance().gameObject.GetComponent<FPSCounterUI>();
            fpsCounterUI.enabled = fpsCounterUI.enabled ? false : true;
        });
    }

    public void InrCounter()
    {
        counter += 1;
        if (counter == debugerOpenThreshold)
        {
            ChangeActive();
            counter = 0;
        }
    }

    public void ChangeActive()
    {
        gameObject.SetActive(gameObject.activeSelf ? false : true);
    }
}
