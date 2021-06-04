using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MusicSelector : MonoBehaviour
{
    public GameObject content;
    public List<AudioTrack> audioTracks;
    public GameObject trackUI;
    public Color selectionColor;

    public AudioTrack selected;
    private List<AudioTrackUI> trackUIs = new List<AudioTrackUI>();
    void Start()
    {
        selected = audioTracks[0];
        SetTracks(audioTracks);
    }

    void SetTracks(List<AudioTrack> audioTracks)
    {
        audioTracks.ForEach(e =>
        {
            GameObject instance = Instantiate(trackUI, content.transform);
            AudioTrackUI trackInstance = instance.GetComponent<AudioTrackUI>();
            trackInstance.SetInfo(e);
            trackInstance.click.AddListener(SelectTrack);
            trackInstance.click.AddListener(at => 
            {
                SetDefaultBackgrounds();
                trackInstance.SetBackgroundColor(selectionColor);
            });

            trackUIs.Add(trackInstance);
        });
    }

    void SelectTrack(AudioTrack audioTrack)
    {
        selected = audioTrack;
    }

    void SetDefaultBackgrounds()
    {
        trackUIs.ForEach(e => e.SetDefaultBackgroundColor());
    }
}