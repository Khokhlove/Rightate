using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioTrack,", menuName = "AudioTrack")]
public class AudioTrack : ScriptableObject
{ 
    public AudioClip track;
    public float warmupTime;
}