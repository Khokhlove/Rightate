using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
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

}