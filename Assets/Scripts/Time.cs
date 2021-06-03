using UnityEngine;

namespace CustomTimer
{
    public class Time
    {
        public float minutes;
        public float seconds;
        public Time(float seconds)
        {
            minutes = Mathf.Floor(seconds / 60);
            this.seconds = seconds - minutes * 60;
        }

        public override string ToString()
        {
            return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
        }
    }
}
