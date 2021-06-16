using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameDebug : MonoBehaviour
{
    public bool enableOnStart = false;
    public GameObject background;

    public Button backgroundButton;
    public Button backgroundMaterialButton;
    public Button backgroundLightProbeButton;
    public Button postProcessing;

    public Material startBackground;
    public Material targetBackground;

    MeshRenderer backgroundMeshRenderer;
    GameObject lightProbe;

    Text backText;
    Text backMatText;
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

        //Background material
        backgroundMeshRenderer = background.GetComponent<MeshRenderer>();
        backMatText = backgroundMaterialButton.GetComponentInChildren<Text>();
        bool name = backgroundMeshRenderer.material.name == "Default-Diffuse (Instance)" ? true : false;
        backMatText.text = $"Back. mat.: {name}";

        backgroundMaterialButton.onClick.AddListener(() =>
        {
            name = backgroundMeshRenderer.material.name == "Default-Diffuse (Instance)" ? true : false;
            backgroundMeshRenderer.material = name ? startBackground : targetBackground;
            backgroundMaterialButton.GetComponentInChildren<Text>().text = $"Back. mat.: {name}";
        });

        //LightProbe
        lightProbe = background.transform.Find("Light Probe Group").gameObject;

        backgroundLightProbeButton.onClick.AddListener(() =>
        {
            lightProbe.SetActive(lightProbe.activeSelf ? false : true);
            backgroundLightProbeButton.GetComponentInChildren<Text>().text = $"Light probe: {lightProbe.activeSelf}";
        });

        //PostProcessing
        volume = Camera.main.GetComponent<Volume>();
        postProcessingText = backgroundLightProbeButton.GetComponentInChildren<Text>();
        postProcessingText.text = $"PP: {volume.enabled}";

        postProcessing.onClick.AddListener(() =>
        {
            volume.enabled = volume.enabled ? false : true;
            backgroundLightProbeButton.GetComponentInChildren<Text>().text = $"PP: {volume.enabled}";
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeActive()
    {
        gameObject.SetActive(gameObject.activeSelf ? false : true);
    }
}
