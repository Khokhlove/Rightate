using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MusicSelector : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject content;
    public MusicContainer musicContainer;
    public GameObject trackUI;
    public Color selectionColor;

    private List<AudioTrackUI> trackUIs = new List<AudioTrackUI>();
    void Start()
    {
        musicContainer = MusicContainer.GetInstance();
        SetTracks(musicContainer.audioTracks);
    }

    void SetTracks(List<AudioTrack> audioTracks)
    {
        audioTracks.ForEach(e =>
        {
            GameObject instance = Instantiate(trackUI, content.transform);
            AudioTrackUI trackInstance = instance.GetComponent<AudioTrackUI>();
            trackInstance.SetInfo(e);
            trackInstance.click.AddListener(musicContainer.SelectTrack);
            trackInstance.click.AddListener(at => 
            {
                SetDefaultBackgrounds();
                trackInstance.SetBackgroundColor(selectionColor);
                backgroundMusic.clip = at.track;
                backgroundMusic.time = at.warmupTime;
                backgroundMusic.Play();
            });

            trackUIs.Add(trackInstance);
        });
    }

    void SetDefaultBackgrounds()
    {
        trackUIs.ForEach(e => e.SetDefaultBackgroundColor());
    }
}