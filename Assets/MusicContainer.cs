using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicContainer : Singleton<MusicContainer>
{
    public AudioTrack selected;
    public List<AudioTrack> audioTracks;
    public UnityEvent<AudioTrack> trackChanged;

    public void SelectTrack(AudioTrack audioTrack)
    {
        selected = audioTrack;
        trackChanged.Invoke(audioTrack);
    }
}
