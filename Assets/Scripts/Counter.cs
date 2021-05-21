using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter
{
    static Counter instance;

    public static Counter GetInstance()
    {
        if (instance == null) instance = new Counter();
        return instance;
    }

    public int Score
    {
        get;
        private set;
    }
    public UnityEvent<int> scoreChanged = new UnityEvent<int>();

    public void Add()
    {
        Score =+ 1;
        scoreChanged?.Invoke(Score);
    }
    public void Sub()
    {
        if (Score != 0)
            Score = -1;
        scoreChanged.Invoke(Score);
    }

}
