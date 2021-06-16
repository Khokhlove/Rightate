using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{
    public AudioTrack selected;
    public List<AudioTrack> audioTracks;

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
    }
}
