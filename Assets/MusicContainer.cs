using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicContainer : MonoBehaviour
{
    public AudioTrack selected;
    public List<AudioTrack> audioTracks;
    public UnityEvent<AudioTrack> trackChanged;

    static MusicContainer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static MusicContainer GetInstance()
    {
        return instance;
    }

    public void SelectTrack(AudioTrack audioTrack)
    {
        selected = audioTrack;
        trackChanged.Invoke(audioTrack);
    }
}
