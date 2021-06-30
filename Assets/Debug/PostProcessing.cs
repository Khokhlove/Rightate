using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using System;

public class PostProcessing : MonoBehaviour
{
    public Bloom bloom;
    public PostProcessLayer postProcessLayer;
    public PostProcessVolume postProcessVolume;
    public GameObject cubes;

    public InputField intensityField;
    public InputField thresholdField;
    public InputField softKneeField;
    public InputField clampField;
    public InputField diffusionField;
    public InputField anamorphicRatioField;
    public Toggle fastModeField;
    public Toggle bloomField;
    public Toggle postProccesingField;
    public Toggle postProcessVolumeField;
    public Toggle cubesField;

    void Start()
    {
        bloom = GetComponent<PostProcessLayer>().GetSettings<Bloom>();
        intensityField.onEndEdit.AddListener((value) => Intensity = Convert.ToSingle(value));
        thresholdField.onEndEdit.AddListener((value) => Threshold = Convert.ToSingle(value));
        softKneeField.onEndEdit.AddListener((value) => SoftKnee = Convert.ToSingle(value));
        clampField.onEndEdit.AddListener((value) => Clamp = Convert.ToSingle(value));
        diffusionField.onEndEdit.AddListener((value) => Diffusion = Convert.ToSingle(value));
        anamorphicRatioField.onEndEdit.AddListener((value) => AnamorphicRatio = Convert.ToSingle(value));
        fastModeField.onValueChanged.AddListener((value) => FastMode = value);
        bloomField.onValueChanged.AddListener((value) => Bloom = value);
        postProcessVolumeField.onValueChanged.AddListener((value) => PostProccesingVolume = value);
        postProccesingField.onValueChanged.AddListener((value) => PostProccesingLayer = value);
        cubesField.onValueChanged.AddListener((value) => Cubes = value);
    }

    public float Intensity
    {
        get { return bloom.intensity; }
        set { bloom.intensity = new FloatParameter { value = value }; }
    }

    public float Threshold
    {
        get { return bloom.threshold; }
        set { bloom.threshold = new FloatParameter { value = value }; }
    }

    public float SoftKnee
    {
        get { return bloom.softKnee; }
        set { bloom.softKnee = new FloatParameter { value = value }; }
    }

    public float Clamp
    {
        get { return bloom.clamp; }
        set { bloom.clamp = new FloatParameter { value = value }; }
    }

    public float Diffusion
    {
        get { return bloom.diffusion; }
        set { bloom.diffusion = new FloatParameter { value = value }; }
    }
    public float AnamorphicRatio
    {
        get { return bloom.anamorphicRatio; }
        set { bloom.anamorphicRatio = new FloatParameter { value = value }; }
    }
    public bool FastMode
    {
        get { return bloom.fastMode; }
        set { bloom.fastMode = new BoolParameter { value = value }; }
    }
    public bool Bloom
    {
        get { return bloom.enabled; }
        set { bloom.enabled = new BoolParameter { value = value }; }
    }
    public bool PostProccesingVolume
    {
        get { return postProcessVolume.enabled; }
        set { postProcessVolume.enabled = new BoolParameter { value = value }; }
    }
    public bool PostProccesingLayer
    {
        get { return postProcessLayer.enabled; }
        set { postProcessLayer.enabled = new BoolParameter { value = value }; }
    }
    public bool Cubes
    {
        get { return cubes.activeSelf; }
        set { cubes.SetActive(value); }
    }
}