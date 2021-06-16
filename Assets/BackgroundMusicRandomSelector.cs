using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicRandomSelector : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public MusicContainer container;

    void Start()
    {
        SetRandomTrack();
    }

    void SetRandomTrack()
    {
        int trackId = Random.Range(0, container.audioTracks.Count);
        AudioTrack track = container.audioTracks[trackId];
        container.SelectTrack(track);
        backgroundMusic.clip = track.track;
        backgroundMusic.Play();
    }
}
