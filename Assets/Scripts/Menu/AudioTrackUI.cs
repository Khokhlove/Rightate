using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using CustomTimer;
using UnityEngine.Events;

public class AudioTrackUI : MonoBehaviour  
{
    public Text songName;
    public Text artistName;
    public Text year;
    public Text duration;
    public Image image;
    public Image background;
    public UnityEvent<AudioTrack> click;
    private AudioTrack audioTrack;
    private Color startColor;

    void Start()
    {
        startColor = background.color;
    }

    public void SetInfo(AudioTrack audioTrack)
    {
        songName.text = audioTrack.songName;
        artistName.text = audioTrack.artistName;
        year.text = audioTrack.year.ToString();
        duration.text = new CustomTimer.Time(audioTrack.track.length).ToString();
        image.sprite = audioTrack.image;
        this.audioTrack = audioTrack;
    }

    public void SetBackgroundColor(Color color)
    {
        background.color = color;
    }

    public void SetDefaultBackgroundColor()
    {
        background.color = startColor;
    }

    void OnMouseUpAsButton()
    {
        click.Invoke(audioTrack);
    }
}