using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackInfoUI : MonoBehaviour
{
    public Text text;

    public void SetInfo(AudioTrack track)
    {
        text.text = $"{track.artistName} - {track.songName}";
    }
}
