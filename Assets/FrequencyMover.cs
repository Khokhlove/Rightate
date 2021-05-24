using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesBackground))]
[RequireComponent(typeof(AudioSource))]
public class FrequencyMover : MonoBehaviour
{
    
    public int offset = 90;
    [Range(1, 10)]
    public float aplifier = 10f;

    AudioSource audio;
    CubesBackground cb;

    private void Start()
    {
        cb = GetComponent<CubesBackground>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float[] spectrum = new float[1024];
        audio.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        List<float> tempSpectrum = spectrum.ToList().GetRange(offset, offset + 100);
        Move(tempSpectrum);
    }

    void Move(List<float> spectrum)
    {
        for (int i = 0; i < cb.cubes.Count; i++)
        {
            Transform t = cb.cubes[i].transform;
            Vector3 oldPos = t.localPosition;
            Vector3 newPos = new Vector3(oldPos.x, spectrum[i] * aplifier, oldPos.z);
            t.localPosition = newPos;
        }
    }
}