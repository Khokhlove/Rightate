using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sounds;
    public AudioClip missClick;
    public AudioTrack backgroundMusic;

    CustomTimer.Timer timer;
    private static AudioController instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SetBackgroundMusic(backgroundMusic);
        music.Play();
        timer = CustomTimer.Timer.GetInstance();
        timer.time = music.clip.length;
    }

    public void SetBackgroundMusic(AudioTrack track)
    {
        music.clip = track.track;
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