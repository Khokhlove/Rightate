using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sounds;
    public AudioClip missClick;
    public AudioTrack backgroundMusic;
    public CustomTimer.Timer timer;
    public CustomTimer.Timer warmupTimer;

    private static AudioController instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        #if UNITY_EDITOR
            SetMusic(backgroundMusic);
        #endif
    }

    public void SetMusic(AudioTrack track)
    {
        SetBackgroundMusic(track);
        music.Play();
        //timer = CustomTimer.Timer.GetInstance();
        warmupTimer.time = track.warmupTime;
        timer.time = music.clip.length - track.warmupTime;
    }

    void SetBackgroundMusic(AudioTrack track)
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

    public void SetTrackPos(float position)
    {
        music.time = position;
    }
    public void PlayMissClick()
    {
        sounds.clip = missClick;
        sounds.Play();
    }

}