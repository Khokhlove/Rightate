using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundMusicRandomSelector : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public UnityEvent trackLoaded;
    Vanisher vanisher;

    void Start()
    {
        vanisher = Vanisher.GetInstance();
        vanisher.cassette.SetActive(false);
        vanisher.InstantHide();
        trackLoaded.AddListener(OnTrackLoaded);
        StartCoroutine(SetRandomTrack());
    }

    IEnumerator SetRandomTrack()
    {
        MusicContainer container = MusicContainer.GetInstance();
        int trackId = Random.Range(0, container.audioTracks.Count);
        AudioTrack track = container.audioTracks[trackId];
        track.track.LoadAudioData();
        backgroundMusic.clip = track.track;
        backgroundMusic.Play();

        while (track.track.loadState == AudioDataLoadState.Loading)
        {
            yield return new WaitForEndOfFrame();
        }

        container.SelectTrack(track);
        trackLoaded.Invoke();
        
    }

    void OnTrackLoaded() 
    { 
        vanisher.Show(() => { });
    }
}
