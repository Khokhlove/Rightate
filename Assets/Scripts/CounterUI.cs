using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    public Text score;
    public Counter counter;

    void Start()
    {
        counter.scoreChanged.AddListener(OnScoreChanged);
    }

    private void OnScoreChanged(int newScore)
    {
        score.text = newScore.ToString();
    }
    private void OnDestroy()
    {
        counter.scoreChanged.RemoveListener(OnScoreChanged);
    }
}
