using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    public Text score;
    
    void Start()
    {
        Counter counter = Counter.GetInstance();
        counter.scoreChanged.AddListener(OnScoreChanged);
    }

    private void OnScoreChanged(int newScore)
    {
        score.text = newScore.ToString();
    }
    private void OnDestroy()
    {
        Counter.GetInstance().scoreChanged.RemoveListener(OnScoreChanged);
    }
}
