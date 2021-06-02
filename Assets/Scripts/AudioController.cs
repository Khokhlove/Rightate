using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sounds;
    public AudioClip missClick;
    Timer timer;
    private static AudioController instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timer = Timer.GetInstance();
        timer.time = music.clip.length;
    }
    public static AudioController GetInstance()
    {
        return instance;
    }

    public void ShiftTrack(float position = 2)
    {
        music.time = music.time + position;
    }
    public void PlayMissClick()
    {
        sounds.clip = missClick;
        sounds.Play();
    }

}