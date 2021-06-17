using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackInfoUI : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        AudioTrack track = MusicContainer.GetInstance().selected;
        SetInfo(track);
    }

    public void SetInfo(AudioTrack track)
    {
        text.text = $"{track.artistName} - {track.songName}";
    }
}
