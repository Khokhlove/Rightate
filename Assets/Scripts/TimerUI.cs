using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text time;
    public Timer timer;

    public Time ConvertToMinutes()
    {
        return new Time(timer.time);
    }

    public void OnTimeChanged(float newTime)
    {
        //time.text = newTime.ToString("0.0");
        Time t = ConvertToMinutes();
        time.text = $"{t.minutes}:{t.seconds.ToString("00")}";
    }
    
    public class Time
    {
        public float minutes;
        public float seconds;
        public Time(float seconds)
        {
            minutes = Mathf.Floor(seconds / 60);
            this.seconds = seconds - minutes * 60;

        }
    }
}
