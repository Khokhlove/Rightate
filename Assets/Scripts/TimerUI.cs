using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomTimer;

public partial class TimerUI : MonoBehaviour
{
    public Text time;
    public Timer timer;

    public void OnTimeChanged(float newTime)
    {
        //time.text = newTime.ToString("0.0");
        CustomTimer.Time t = new CustomTimer.Time(timer.time);
        time.text = t.ToString();
    }
}
