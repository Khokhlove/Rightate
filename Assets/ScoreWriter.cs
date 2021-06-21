using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWriter : MonoBehaviour
{
    public CustomTimer.Timer timer;

    private void Start()
    {
        timer.timeIsUp.AddListener(OnTimeIsUp);
    }

    private void OnDestroy()
    {
        timer.timeIsUp.RemoveListener(OnTimeIsUp);
    }

    public void OnTimeIsUp()
    {
        SetScore(Counter.GetInstance().Score);
    }
    public void SetScore(int value)
    {
        MusicContainer mc = MusicContainer.GetInstance();
        if (value > mc.selected.HighScore)
        {
            mc.selected.HighScore = value;
        }
    }
}
