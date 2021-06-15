using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    static GameSettings instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
        }

        Application.targetFrameRate = 120;
    }

    public GameSettings GetInstance()
    {
        return instance;
    }
}
