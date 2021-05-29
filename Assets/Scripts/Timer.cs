using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float time;

    public UnityEvent<float> timeChanged;
    public UnityEvent timeIsUp;

    void FixedUpdate()
    {
        DcrTime();
    }
    private void DcrTime()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
            timeIsUp.Invoke();
        }
        timeChanged.Invoke(time);
    }
    public void AddTime(float t)
    {
        time += t;
        timeChanged.Invoke(time);
    }
    public void SubTime(float t)
    {
        time -= t;
        timeChanged.Invoke(time);
    }

}
