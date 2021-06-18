using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackInfoUI : MonoBehaviour
{
    public Text text;

    void Start()
    {
        MusicContainer.GetInstance().trackChanged.AddListener(SetInfo);
    }

    void OnDestroy()
    {
        MusicContainer.GetInstance().trackChanged.RemoveListener(SetInfo);
    }

    public void SetInfo(AudioTrack track)
    {
        text.text = $"{track.artistName} - {track.songName}";
    }
}
