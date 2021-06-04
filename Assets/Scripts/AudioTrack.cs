using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioTrack,", menuName = "AudioTrack")]
public class AudioTrack : ScriptableObject
{ 
    public AudioClip track;
    public float warmupTime;
    public string songName;
    public string artistName;
    public int year;
    public Sprite image;
}