using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text time;
    public Timer timer;

    public void OnTimeChanged(float newTime)
    {
        time.text = newTime.ToString("0.0");
    }
}
