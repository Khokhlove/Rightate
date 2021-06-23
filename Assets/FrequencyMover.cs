using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesBackground))]
[RequireComponent(typeof(AudioSource))]
public class FrequencyMover : MonoBehaviour
{
    
    public int offset = 90;
    [Range(1, 100)]
    public float aplifier = 10f;
    public float lerp;
    public List<float> spectrum;
    public FFTWindow fFTWindow;
    AudioSource audio;
    CubesBackground cb;

    private void Start()
    {
        cb = GetComponent<CubesBackground>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float[] tempSpectrum = new float[1024];
        audio.GetSpectrumData(tempSpectrum, 0, fFTWindow);

        spectrum = tempSpectrum.ToList().GetRange(offset, offset + 100);
        Move(spectrum);
    }

    void Move(List<float> spectrum)
    {
        for (int i = 0; i < cb.cubes.Count; i++)
        {
            Transform t = cb.cubes[i].transform;
            Vector3 oldPos = t.localPosition;
            Vector3 newPos = new Vector3(oldPos.x, spectrum[i] * aplifier, oldPos.z);
            Vector3 targetPos = Vector3.Lerp(oldPos, newPos, lerp);
            t.localPosition = targetPos;
        }
    }
}