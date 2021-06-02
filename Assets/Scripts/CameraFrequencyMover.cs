using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CameraFrequencyMover : MonoBehaviour
{
    public AudioSource music;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float[] spectrum = new float[256];
        music.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        List<float> tempSpectrum = spectrum.ToList().GetRange(0, 100);
        Debug.Log($"{spectrum[1]} {spectrum[2]} {spectrum[3]} {spectrum[4]}");
        ShakeCamera(tempSpectrum[1]);
    }

    void ShakeCamera(float value)
    {
        transform.position = new Vector3(0, startPos.y + value, startPos.z - value / 3);
    }
}